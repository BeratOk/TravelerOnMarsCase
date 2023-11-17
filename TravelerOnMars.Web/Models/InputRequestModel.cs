using TravelerOnMars.Domain.ValueObjects;

namespace TravelerOnMars.Web.Models
{
    public class InputRequestModel
    {
        public Cordinate UpCornerCordinate { get; set; } = null!;

        public Position PositionOne { get; set; } = new Position(new Cordinate(), new Direction());
        public Position PositionTwo { get; set; } = new Position(new Cordinate(), new Direction());

        public string DirectionCodeOne { get; set; } = null!;
        public string DirectionCodeTwo { get; set; } = null!;

        public string CommandKeysOne { get; set; } = null!;
        public string CommandKeysTwo { get; set; } = null!;
    }
}
