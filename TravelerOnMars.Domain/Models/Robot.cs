using TravelerOnMars.Domain.ValueObjects;

namespace TravelerOnMars.Domain.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public Position Position { get; set; } = null!;

        public Robot(int id, Position position)
        {
            Id = id;
            Position = position;
        }

        public void TurnLeft()
        {
            Direction oldPosition = this.Position.Direction;

            if (oldPosition == Direction.EAST)
            {
                this.Position.ChangeDirection(Direction.NORTH);
            }

            else if (oldPosition == Direction.NORTH)
            {
                this.Position.ChangeDirection(Direction.WEST);
            }

            else if (oldPosition == Direction.WEST)
            {
                this.Position.ChangeDirection(Direction.SOUTH);
            }

            else if (oldPosition == Direction.SOUTH)
            {
                this.Position.ChangeDirection(Direction.EAST);
            }
        }

        public void TurnRight()
        {
            Direction oldPosition = this.Position.Direction;

            if (oldPosition == Direction.NORTH)
            {
                this.Position.ChangeDirection(Direction.EAST);
            }

            else if (oldPosition == Direction.WEST)
            {
                this.Position.ChangeDirection(Direction.NORTH);
            }

            else if (oldPosition == Direction.SOUTH)
            {
                this.Position.ChangeDirection(Direction.WEST);
            }

            else if (oldPosition == Direction.EAST)
            {
                this.Position.ChangeDirection(Direction.SOUTH);
            }
        }

        public void Move(Cordinate limitCordinate)
        {
            if (this.Position.Direction == Direction.NORTH)
            {
                if (this.Position.Cordinate.Y < limitCordinate.Y)
                    this.Position.Cordinate.Y++;
            }

            else if (this.Position.Direction == Direction.WEST)
            {
                if (this.Position.Cordinate.X > 0)
                    this.Position.Cordinate.X--;
            }

            else if (this.Position.Direction == Direction.SOUTH)
            {
                if (this.Position.Cordinate.Y > 0)
                    this.Position.Cordinate.Y--;
            }

            else if (this.Position.Direction == Direction.EAST)
            {
                if (this.Position.Cordinate.X < limitCordinate.X)
                    this.Position.Cordinate.X++;
            }
        }
    }
}
