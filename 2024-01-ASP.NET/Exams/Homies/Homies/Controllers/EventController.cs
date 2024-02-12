using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext data;

        public EventController(HomiesDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateEventViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEventViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateTimeFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
                Start = start,
                End = end
            };

            await data.Events.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await data.Events.FindAsync(id);

            if (e == null)
            {
                BadRequest();
            }
            var userId = GetUserId(); 
            if (e.OrganiserId != userId)
            {
                return Unauthorized();
            }

            var model = new CreateEventViewModel()
            {
                Description = e.Description,
                Name = e.Name,
                Start = e.Start.ToString(DataConstants.DateTimeFormat),
                End = e.End.ToString(DataConstants.DateTimeFormat),
                TypeId = e.TypeId
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateEventViewModel model, int id)
        {
            var e = await data.Events.FindAsync(id);

            if (e == null)
            {
                BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateTimeFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            e.Start = start;
            e.End = end; 
            e.Description = model.Description;
            e.TypeId = model.TypeId;
            e.Name = model.Name;

            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }
       
        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName))
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var eventToJoin = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (eventToJoin == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!eventToJoin.EventsParticipants.Any(p => p.HelperId == userId))
            {
                eventToJoin.EventsParticipants.Add(new EventsParticipants()
                {
                    EventId = eventToJoin.Id,
                    HelperId = userId
                });

            }

            await data.SaveChangesAsync();
            return RedirectToAction(nameof(Joined));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            string userId = GetUserId();

            var eventToLeave = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (eventToLeave == null)
            {
                return BadRequest();
            }

            var ep = eventToLeave.EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            eventToLeave.EventsParticipants.Remove(ep);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();
            var joined = await data.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new EventInfoViewModel(
                    ep.EventId,
                    ep.Event.Name,
                    ep.Event.Start,
                    ep.Event.Type.Name,
                    ep.Event.Organiser.UserName))
                .ToListAsync();

            return View(joined);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            var model = await data.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.DateTimeFormat),
                    End = e.End.ToString(DataConstants.DateTimeFormat),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateTimeFormat),
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await data.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
