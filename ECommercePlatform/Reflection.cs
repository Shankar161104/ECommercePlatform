using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    public class ReflectionExample
    {
        public void LoadAndInvoke()
        {
           
            Type productType = Type.GetType("ECommercePlatform.Product");

            if (productType != null)
            {
                
                object productInstance = Activator.CreateInstance(productType, 1, "Laptop", "Electronics", 1200.00m, 10);

               
                PropertyInfo nameProperty = productType.GetProperty("Name");
                PropertyInfo priceProperty = productType.GetProperty("Price");

                if (nameProperty != null && priceProperty != null)
                {
                    
                    nameProperty.SetValue(productInstance, "Gaming Laptop");
                    priceProperty.SetValue(productInstance, 1500.00m);

                    
                    string name = (string)nameProperty.GetValue(productInstance);
                    decimal price = (decimal)priceProperty.GetValue(productInstance);

                    Console.WriteLine($"Product Name: {name}");
                    Console.WriteLine($"Product Price: {price}");
                }

                
                MethodInfo validateMethod = productType.GetMethod("Validate", BindingFlags.NonPublic | BindingFlags.Instance);
                if (validateMethod != null)
                {
                    validateMethod.Invoke(productInstance, null);
                    Console.WriteLine("Product validated successfully.");
                }
            }
            else
            {
                Console.WriteLine("Product type not found.");
            }
        }
    }
}
