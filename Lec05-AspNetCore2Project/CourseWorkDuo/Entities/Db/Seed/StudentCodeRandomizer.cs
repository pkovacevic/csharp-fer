using Tynamix.ObjectFiller;

namespace CourseWorkDuo.Entities.Db.Seed
{
    /// <summary>
    /// Creates random student code.
    /// </summary>
    public class StudentCodeRandomizer : IRandomizerPlugin<string>
    {
        private readonly SequenceGeneratorInt32 _numberRandomizer;

        public StudentCodeRandomizer()
        {
            _numberRandomizer = new SequenceGeneratorInt32();
        }

        public string GetValue()
        {
            var val = _numberRandomizer.GetValue().ToString().PadLeft(5, '0');
            return val;
        }
    }
}
