using System;
using Tynamix.ObjectFiller;

namespace CourseWorkDuo.Entities.Db.Seed
{
    /// <summary>
    /// Creates random student gender.
    /// </summary>
    public class GenderRandomizer : IRandomizerPlugin<string>
    {
        private readonly Random _chance;

        public GenderRandomizer()
        {
            _chance = new Random();
        }

        public string GetValue()
        {
            var fromZerooToOne = _chance.NextDouble();
            if (fromZerooToOne < 0.5)
            {
                return "F"; // Female
            }
            else if (fromZerooToOne < 0.98)
            {
                return "M"; // Male
            }
            else
            {
                return "X"; // Would rather not say
            }
        }
    }
}
