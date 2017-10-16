namespace Demo03_ExtensionMethods
{
    /// <summary>
    /// Extension method definition.
    /// Static class containing static method that takes "this type-we-are-extending" as the first parameter.
    /// 
    /// Code below will allow us to call
    /// string s = "3.14";
    /// double d = s.ToDouble(); 
    /// </summary>
    public static class StringExtensions
    {
        public static double ToDouble(this string s) 
        {
            var d = double.Parse(s);
            return d;
        }
    }
}