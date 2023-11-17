using CSharpFunctionalExtensions;

namespace TravelerOnMars.Domain.ValueObjects
{
    public class Position : ValueObject
    {
        public Cordinate Cordinate { get; set; } = null!;
        public Direction Direction { get; private set; } = null!;

        private Position() { }

        public Position(Cordinate cordinate, Direction direction)
        {
            Cordinate = cordinate;
            Direction = direction;
        }

        public static Position Create(Cordinate cordinate, Direction direction)
        {
            return new Position(cordinate, direction);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Cordinate;
            yield return Direction;
        }

        public void ChangeDirection(Direction direction)
        {
            this.Direction = direction;
        }
    }
}
