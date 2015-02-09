using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.CSharp
{
    
    class DeepVsShallowCopy
    {
        internal class Product
        {
            public int Id { get; set; }
            public ProductSpec Specification { get; set; }
            public List<string> Properties { get; set; }

            public Product Clone()
            {
                return (Product)this.MemberwiseClone();
                
            }
        }

        internal class ProductSpec
        {
            public string Name { get; set; }
        }

        public static void Implementation()
        {
            var p1 = new Product();
            p1.Id = 5;
            p1.Specification = new ProductSpec();
            p1.Specification.Name = "Testing";
            p1.Properties = new List<string> { "a", "b", "b" };

            var p2 = p1.Clone();
            p2.Specification.Name = "Verfieid";
            p2.Properties.RemoveAt(0);

        }
                
    }
}
