using CSharpFunctionalExtensions;

namespace TravelerOnMars.Domain.ValueObjects
{
    public class CommandKey : ValueObject
    {
        public static CommandKey LEFT => new("L", "LEFT");
        public static CommandKey RIGHT => new("R", "RIGHT");
        public static CommandKey MOVE => new("M", "MOVE");
        private static CommandKey[] All => new[] { LEFT, RIGHT, MOVE };

        public string Code { get; } = null!;
        public string Name { get; } = null!;

        private CommandKey() { }

        private CommandKey(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static CommandKey FromCode(string code)
        {
            var codeUpper = code.Normalize().ToUpper();
            var matchingItem = Array.Find(All, x => x.Code == codeUpper);

            return matchingItem!;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Code;
        }

        public static List<CommandKey> GetAllDirections()
        {
            return All.ToList();
        }
    }
}
