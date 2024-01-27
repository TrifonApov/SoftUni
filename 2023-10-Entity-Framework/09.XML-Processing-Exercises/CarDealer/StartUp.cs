using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string importSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, importSuppliers));

            //string importParts = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, importParts));

            //string importCars = File.ReadAllText(@"../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, importCars));

            //string importCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, importCustomers));

            //string importSales = File.ReadAllText(@"../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, importSales));

            //Console.WriteLine(GetCarsWithDistance(context));

            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //Console.WriteLine(GetLocalSuppliers(context));

            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            Mapper mapper = GetMapper();

            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarsWithDistance>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistance[])
                , new XmlRootAttribute("cars"));

            var xmlNS = new XmlSerializerNamespaces();
            xmlNS.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            using (StringWriter sw = new StringWriter(result))
            {
                xmlSerializer.Serialize(sw, cars, xmlNS);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            Mapper mapper = GetMapper();

            var bmws = context.Cars
                .Where(c => c.Make.ToLower() == "bmw")
                .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBWMs>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBWMs[]), new XmlRootAttribute("cars"));

            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            using (StringWriter sw = new StringWriter(result))
            {
                xmlSerializer.Serialize(sw, bmws, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            Mapper mapper = GetMapper();

            var suppliers = context.Suppliers
                .Where(s=>!s.IsImporter)
                .ProjectTo<ExportLocalSuppliers>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliers[]), new XmlRootAttribute("suppliers"));

            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            using (StringWriter sw = new StringWriter(result))
            {
                xmlSerializer.Serialize(sw,suppliers, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            Mapper mapper = GetMapper();

            var cars = context.Cars
                .Select(c=> new ExportCarsWithParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    Parts = c.PartsCars
                        .Select(p=> new ExportCarParts
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList(),
                })
                .OrderByDescending(c=>c.TraveledDistance)
                    .ThenBy(c=>c.Model)
                .Take(5)
                .ToArray();
            Console.WriteLine();
            return "";
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            throw new NotImplementedException();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            throw new NotImplementedException();
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]),
                new XmlRootAttribute("Suppliers"));

            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDTO[] importSupplierDTOs = (ImportSupplierDTO[])xmlSerializer.Deserialize(reader);

            Mapper mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(importSupplierDTOs);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDTO[]),
                new XmlRootAttribute("Parts"));

            using StringReader reader = new StringReader(inputXml);
            ImportPartDTO[] importPartDTOs = (ImportPartDTO[])xmlSerializer.Deserialize(reader);

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            Mapper mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(importPartDTOs.Where(p => supplierIds.Contains(p.SupplierId)));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDTO[]),
               new XmlRootAttribute("Cars"));
            using StringReader reader = new StringReader(inputXml);
            ImportCarDTO[] importCarDTOs = (ImportCarDTO[])xmlSerializer.Deserialize(reader);

            Mapper mapper = GetMapper();
            List<Car> cars = new List<Car>();

            foreach (var carDTO in importCarDTOs)
            {
                Car car = mapper.Map<Car>(carDTO);
                int[] carPartsIds = carDTO.PartsIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                List<PartCar> carParts = new List<PartCar>();

                foreach (int partId in carPartsIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }


            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]),
                new XmlRootAttribute("Customers"));

            using StringReader reader = new StringReader(inputXml);
            ImportCustomerDTO[] importCustomerDTOs = (ImportCustomerDTO[])xmlSerializer.Deserialize(reader);

            Mapper mapper = GetMapper();
            Customer[] customers = mapper.Map<Customer[]>(importCustomerDTOs);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDTO[]),
               new XmlRootAttribute("Sales"));

            using StringReader reader = new StringReader(inputXml);
            ImportSaleDTO[] importSaleDTOs = (ImportSaleDTO[])xmlSerializer.Deserialize(reader);

            int[] carIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            Mapper mapper = GetMapper();
            Sale[] sales = mapper.Map<Sale[]>(importSaleDTOs.Where(s => carIds.Contains(s.CarId)));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }
    }
}