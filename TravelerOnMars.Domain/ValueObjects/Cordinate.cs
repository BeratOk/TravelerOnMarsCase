using CSharpFunctionalExtensions;

namespace TravelerOnMars.Domain.ValueObjects
{
    public class Cordinate : ValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
