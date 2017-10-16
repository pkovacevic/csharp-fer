using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo01_ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            // # 1
            
            // We want to give a special discount to our customers that 
            // decided to buy "The Timeless Art of Seduction" painting.
            
            // This is the target product we are looking to find in the customer's cart:
            var targetProductv1 = new Productv1()
            {
                Id = 1, Name = "The Timeless Art of Seduction"
            };
            
            // Get the cart and check if it contains the target product.
            var cartv1 = GetShoppingCartv1();
            Console.WriteLine(cartv1.Contains(targetProductv1));
            
            // Something's off!
            // We clearly have "The Timeless Art of Seduction" product in customer's cart.
            // Product ID matches, name of the product matches. But contains returns false...

            // What is happening here? Contains method internally uses Equals() method to figure out if the two object are equal.
            // Every object has Equals method and the default implementation says - if they live in the same address, they are equal.
            // This clearly wont do it for us since we'd like to acknowledge equality 
            // even if the object live in different memory locations (like in our case).
            // It would be far better if Equals compared product ID.
            
            // Fortunately, there is a way to override the default implementation.
            
            // #2
            
            // Developer prepared a new product class implementation. 
            // v2 product overrides the default equals method. 
            var targetProductv2 = new Productv2()
            {
                Id = 1, Name = "The Timeless Art of Seduction"
            };
            
            var cartv2 = GetShoppingCartv2();
            Console.WriteLine(cartv2.Contains(targetProductv2));
            
            // Seems good enough... but then we kick into a different issue.
            // We got a new business case where we want to get all cart products different from the target product,
            // We want to split the discount only among them.
            
            // We use convenient .NET method "Except" that returns the difference between two lists.
            // Result we are expecting: list of cart products except the target product. 
            var cartExceptTargetProductv2 = cartv2.Except(new List<Productv2>(){ targetProductv2});
            Console.WriteLine(cartExceptTargetProductv2.Contains(targetProductv2));

            // Something's off again. Resulting list still contains our target product, why?
            
            // Reason: certain .NET methods use a different comparer to check for object equality. 
            //     ## The big rule when playing equality in .NET is: if two objects are equal, they should have the same hash code.
            //     ## When you decide to override Equals() method, you are required to change the GetHashCode() as well!
            // Lots of methods in .NET take this rule seriously, and so should you. 
            // Their equality comparer first checks if the hash codes of the two objects are the same (GetHashCode() call).
            // If they are not equal, comparer wont even bother checking Equals()! 
            // This is why Except() operator is not working for us. We didn't override the GetHashCode method.
            
            // # 3
            
            // Our developer updated the product implementation and implemented the GetHashCode.
            var targetProductv3 = new Productv3()
            {
                Id = 1, Name = "The Timeless Art of Seduction"
            };
            
            var cartv3 = GetShoppingCartv3();
            Console.WriteLine(cartv3.Contains(targetProductv3));
            
            var cartExceptTargetProductv3 = cartv3.Except(new List<Productv3>(){ targetProductv3});
            Console.WriteLine(cartExceptTargetProductv3.Contains(targetProductv3));
            
            // Looks good now.
        }


        static List<Productv1> GetShoppingCartv1()
        {
            return new List<Productv1>()
            {
                new Productv1()
                {
                    Id = 2, Name = "Mug - The #1 Boss"
                },
                new Productv1()
                {
                    Id = 1, Name = "The Timeless Art of Seduction"
                }
            };
        }
        
        static List<Productv2> GetShoppingCartv2()
        {
            return new List<Productv2>()
            {
                new Productv2()
                {
                    Id = 2, Name = "Mug - The #1 Boss"
                },
                new Productv2()
                {
                    Id = 1, Name = "The Timeless Art of Seduction"
                }
            };
        }
        
        static List<Productv3> GetShoppingCartv3()
        {
            return new List<Productv3>()
            {
                new Productv3()
                {
                    Id = 2, Name = "Mug - The #1 Boss"
                },
                new Productv3()
                {
                    Id = 1, Name = "The Timeless Art of Seduction"
                }
            };
        }

    }
}