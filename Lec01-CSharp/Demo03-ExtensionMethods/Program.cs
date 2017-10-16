using System;

namespace Demo03_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Imagine we have a code base where we often have to convert string to a double type.
            // Ideally, string would have a ToDouble() method available for us.
            // double d = "3.41".ToDouble();
            // Unfortunately, .NET string does not come with this method implemented.

            
            // Option #0: Create your own string that inherits from string and has ToDouble method.
            // But actually, that wouldn't work. String is marked as "sealed class", and we are not allowed to inherit from it.
            // -
            
            // Option #1: Check StringUtilities.cs
            // 
            // Add utilities class that will hold this functionality.
            // Good enough solution, but not as elegant syntax as  "3.41".ToDouble();
            double d = StringUtilities.ToDouble("3.41"); 
            
            
            // Option #2: Check StringExtensions.cs
            // Extension methods.. C# allows us to extend the type implementation, without touching the 
            // source code of that type.
            // Perfect!
            double d2 = "3.41".ToDouble(); 
            
            
            // Check the real world usage of extension methods in LINQ demo project.
        }
    }




}