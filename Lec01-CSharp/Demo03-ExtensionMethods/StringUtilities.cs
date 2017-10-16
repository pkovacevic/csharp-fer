namespace Demo03_ExtensionMethods
{
    public class StringUtilities
    {
        public static double ToDouble(string s)
        {
            var d = double.Parse(s);
            return d;
        }
    }
}