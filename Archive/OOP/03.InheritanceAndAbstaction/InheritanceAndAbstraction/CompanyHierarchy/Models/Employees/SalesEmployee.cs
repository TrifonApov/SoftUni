namespace CompanyHierarchy.Models.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Interfaces;
    using Sales;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private ICollection<Product> setOfProduct;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department) : base(id, firstName, lastName, salary, department)
        {
            this.SetOfProduct = new List<Product>();
        }


        public ICollection<Product> SetOfProduct
        {
            get { return this.setOfProduct; }
            set { this.setOfProduct = value; }
        }

        public void AddProduct(Product product)
        {
            this.SetOfProduct.Add(product);
        }

        public void AddProducts(Product[] products)
        {
            foreach (Product product in products)
            {
                this.SetOfProduct.Add(product);
            }
        }   

        public void RemoveProduct(Product product)
        {
            this.SetOfProduct.Remove(this.SetOfProduct.First(p => p.Equals(product)));
        }

        public void RemoveProducts(Product[] products)
        {
            foreach (Product product in products)
            {
                this.SetOfProduct.Remove(this.SetOfProduct.First(p => p.Equals(product)));
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine("---Products:");
            foreach (var product in this.SetOfProduct)
            {
                output.AppendLine("-----" + product.ToString());
            }
            return output.ToString();
        }
    }
}