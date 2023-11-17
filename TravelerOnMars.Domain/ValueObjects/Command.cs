using CSharpFunctionalExtensions;

namespace TravelerOnMars.Domain.ValueObjects
{
    public class Command : ValueObject
    {
        public Position StartPosition { get; set; } = null!;
        public List<CommandKey> CommandKeys { get; set; } = null!;

        private Command() { }

        private Command(Position startPosition, List<CommandKey>? commandKeys)
        {
            StartPosition = startPosition;
            CommandKeys = commandKeys!;
        }

        public static Command Create(Position startPosition, string commandKeysString)
        {
            var _commandKeys = new List<CommandKey>();
            foreach (var key in commandKeysString)
            {
                var commandKey = CommandKey.FromCode(key.ToString());
                _commandKeys.Add(commandKey);
            }

            return new Command(startPosition, _commandKeys);
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return StartPosition;
            yield return (IComparable)CommandKeys;
        }
        
    }
}
