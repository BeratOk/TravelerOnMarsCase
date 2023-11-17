using TravelerOnMars.Domain.ValueObjects;

namespace TravelerOnMars.Domain.Models
{
    public class DataManager
    {
        public Cordinate UpCornerCordinate { get; set; } = null!;
        public List<Command> Commands { get; set; } = null!;
    }
}
