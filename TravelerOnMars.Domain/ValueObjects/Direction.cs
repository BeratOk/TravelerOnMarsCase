using CSharpFunctionalExtensions;

namespace TravelerOnMars.Domain.ValueObjects
{
    public class Direction : ValueObject
    {
        public static Direction NORTH => new("N", "NORTH");
        public static Direction WEST => new("W", "WEST");
        public static Direction SOUTH => new("S", "SOUTH");
        public static Direction EAST => new("E", "EAST");
        private static Direction[] All => new[] { NORTH, WEST, SOUTH, EAST };

        public string Code { get; } = null!;
        public string Name { get; } = null!;

        public Direction() { }

        public Direction(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static Direction FromCode(string code)
        {
            var codeUpper = code.Normalize().ToUpper();
            var matchingItem = Array.Find(All, x => x.Code == codeUpper);

            return matchingItem!;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Code;
        }

        public static List<Direction> GetAllDirections()
        {
            return All.ToList();
        }
    }
}
