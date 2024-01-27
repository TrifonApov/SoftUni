<<<<<<< HEAD
﻿using System.Text;
using Invoices.Data.Models;
using Invoices.Extensions;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
=======
﻿namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
    using Invoices.Data;
    using Invoices.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
<<<<<<< HEAD
            StringBuilder result = new StringBuilder();

            // Deserialize Info From XML
            var clientsDTOs = xmlString.DeserializeFromXml<ImportClientDTO[]>("Clients");
            
            // Collection with entities to add in DB
            var clientsToAdd = new List<Client>();


            foreach (ImportClientDTO clientDto in clientsDTOs)
            {
                if (!IsValid(clientDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var clientToAdd = new Client
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (ImportAddressDTO addressDto in clientDto.Address)
                {
                    if (IsValid(addressDto))
                    {
                        clientToAdd.Addresses.Add( new Address
                        {
                            StreetName = addressDto.StreetName,
                            StreetNumber = addressDto.StreetNumber,
                            PostCode = addressDto.PostCode,
                            City = addressDto.City,
                            Country = addressDto.Country
                        });
                    }
                    else
                    {
                        result.AppendLine(ErrorMessage);
                    }
                }
                clientsToAdd.Add(clientToAdd);
                result.AppendLine(string.Format(SuccessfullyImportedClients, clientDto.Name));
            }

            context.AddRange(clientsToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
=======
            throw new NotImplementedException();

>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
<<<<<<< HEAD
            StringBuilder result = new StringBuilder();

            var ImportInvoicesDTOs = jsonString.DeserializeFromJson<ImportInvoiceDTO[]>();
            var invoicesToAdd = new List<Invoice>();
            var clientsIds = context.Clients.Select(c => c.Id).ToArray();



            foreach (ImportInvoiceDTO importInvoicesDTO in ImportInvoicesDTOs)
            {
                

                if (!IsValid(importInvoicesDTO) 
                    || importInvoicesDTO.DueDate < importInvoicesDTO.IssueDate
                    || !clientsIds.Contains(importInvoicesDTO.ClientId))
                {
                    result.AppendLine(ErrorMessage);
                }
                else
                {
                    var newInvoice = new Invoice
                    {
                        Number = importInvoicesDTO.Number,
                        IssueDate = importInvoicesDTO.IssueDate,
                        DueDate = importInvoicesDTO.DueDate,
                        Amount = importInvoicesDTO.Amount,
                        CurrencyType = importInvoicesDTO.CurrencyType,
                        ClientId = importInvoicesDTO.ClientId
                    };

                    invoicesToAdd.Add(newInvoice);
                    result.AppendLine(string.Format(SuccessfullyImportedInvoices, newInvoice.Number));
                }
            }

            context.AddRange(invoicesToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
=======
            throw new NotImplementedException();
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
<<<<<<< HEAD
            StringBuilder result = new StringBuilder();

            var productDTOs = jsonString.DeserializeFromJson<ImportProductDTO[]>();
            
            var productsToAdd = new List<Product>();
            var clientsIds = context.Clients.Select(c => c.Id).ToArray();

            foreach (ImportProductDTO productDTO in productDTOs)
            {
                if (!IsValid(productDTO))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newProduct = new Product
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    CategoryType = productDTO.CategoryType,
                };

                foreach (int clientId in productDTO.Clients.Distinct())
                {
                    if (clientsIds.Contains(clientId))
                    {
                        newProduct.ProductsClients.Add(new ProductClient
                        {
                            ClientId = clientId
                        });
                    }
                    else
                    {
                        result.AppendLine(ErrorMessage);
                    }
                }

                productsToAdd.Add(newProduct);
                result.AppendLine(string.Format(SuccessfullyImportedProducts, newProduct.Name,
                    newProduct.ProductsClients.Count));
            }
            
            context.Products.AddRange(productsToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
=======


            throw new NotImplementedException();
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
