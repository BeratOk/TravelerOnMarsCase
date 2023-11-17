using Microsoft.AspNetCore.Mvc;
using TravelerOnMars.Domain.Models;
using TravelerOnMars.Domain.ValueObjects;
using TravelerOnMars.Web.Models;

namespace TravelerOnMars.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartPositionPost(DataManager data)
        {
            return RedirectToAction("CommandPage", "Home", new { x = data.UpCornerCordinate.X, y = data.UpCornerCordinate.Y });
        }

        public IActionResult CommandPage(int x, int y)
        {
            return View(new InputRequestModel() { UpCornerCordinate = new Cordinate() { X = x, Y = y } });
        }

        [HttpPost]
        public IActionResult CommandPagePost(InputRequestModel data)
        {
            data.PositionOne.ChangeDirection(Direction.FromCode(data.DirectionCodeOne));
            data.PositionTwo.ChangeDirection(Direction.FromCode(data.DirectionCodeTwo));
            DataManager input = new()
            {
                UpCornerCordinate = data.UpCornerCordinate,
                Commands = new List<Command>()
                  {
                      Command.Create(data.PositionOne, data.CommandKeysOne),
                      Command.Create(data.PositionTwo, data.CommandKeysTwo)
                  }
            };

            List<Robot> robots = new List<Robot>()
            {
                new Robot(1,data.PositionOne),
                new Robot(2,data.PositionTwo)
            };
            for (int i = 0; i < robots.Count(); i++)
            {
                CommandApply(input.Commands[i], robots[i], input.UpCornerCordinate);

            }
            ResultVM result = new ResultVM()
            {
                Robots = robots,
                tableCordinate = input.UpCornerCordinate
            };

            return View(result);
        }


        public void CommandApply(Command command, Robot robot, Cordinate limitCordinate)
        {
            foreach (var commandKey in command.CommandKeys)
            {
                if (commandKey == CommandKey.LEFT)
                {
                    robot.TurnLeft();
                }

                else if (commandKey == CommandKey.RIGHT)
                {
                    robot.TurnRight();
                }

                else if (commandKey == CommandKey.MOVE)
                {
                    robot.Move(limitCordinate);
                }
            }
        }
    }
}