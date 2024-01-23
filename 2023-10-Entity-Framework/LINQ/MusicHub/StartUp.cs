namespace MusicHub
{
    using System;
    using System.Diagnostics.Metrics;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            // DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 120));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producerAlbums = context.Producers
                .Include(p => p.Albums)
                .ThenInclude(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .First(p => p.Id == producerId)
                .Albums.
                    Select(a => new
                    {
                        a.Name,
                        a.ReleaseDate,
                        ProducerName = a.Producer.Name,
                        AlbumSongs = a.Songs
                            .Select(s => new
                            {
                                s.Name,
                                s.Price,
                                WriterName = s.Writer.Name
                            })
                            .OrderByDescending(s => s.Name)
                            .ThenBy(s => s.WriterName)
                            .ToList(),
                        a.Price
                    })
                    .OrderByDescending(a => a.Price)
                    .ToList();

            
            StringBuilder result = new();
            foreach (var album in producerAlbums) 
            { 
                string albumName = $"-AlbumName: {album.Name}";
                string releaseDate = $"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}";
                string producerName = $"-ProducerName: {album.ProducerName}";
                result.AppendLine(albumName);
                result.AppendLine(releaseDate);
                result.AppendLine(producerName);
                result.AppendLine("-Songs:");

                int counter = 1;
                foreach(var song in album.AlbumSongs)
                {
                    string songNum = $"---#{counter++}";
                    string songName = $"---SongName: {song.Name}";
                    string price = $"---Price: {song.Price:F2}";
                    string writer = $"---Writer: {song.WriterName}";

                    result.AppendLine(songNum);
                    result.AppendLine(songName);
                    result.AppendLine(price);
                    result.AppendLine(writer);

                }
                string albumPrice = $"-AlbumPrice: {album.Price:F2}";
                result.AppendLine(albumPrice);
            }
            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.Album).ThenInclude(a => a.Producer)
                .Include(s => s.SongPerformers).ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Where(s => s.Duration > new TimeSpan(0,0,duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performers = s.SongPerformers
                        .Select(sp=>new
                        {
                            PerformerName = sp.Performer.FirstName + " " + sp.Performer.LastName,
                        })
                        .Select(p => p.PerformerName)
                        .OrderBy(p => p)
                        .ToList(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duradion = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.Writer)
                .ToList();
            
            StringBuilder result = new();
            
            int counter = 1;
            
            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{counter++}");
                result.AppendLine($"---SongName: {song.SongName}");
                result.AppendLine($"---Writer: {song.Writer}");
                foreach (var performer in song.Performers)
                {
                    result.AppendLine($"---Performer: {performer}");
                }
                
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duradion}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
