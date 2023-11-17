using TravelerOnMars.Domain.Models;
using TravelerOnMars.Domain.ValueObjects;

namespace TravelerOnMars.Web.Models
{
    public class ResultVM
    {
        public List<Robot> Robots { get; set; } = null!;
        public Cordinate tableCordinate { get; set; } = null!;
    }
}
