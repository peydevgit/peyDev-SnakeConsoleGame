namespace Snakez
{
    public class Player : GameObject
    {
        public enum Directions 
        {
            Up, Down, Left, Right
        }
        public Directions Direction;

        public Player(Position position, char appereance) : base(position, appereance)
        {

        }
        public static void PlayerKeyInput(ConsoleKey key,Player PlayerHead)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (PlayerHead.Direction != Directions.Up)
                        PlayerHead.Direction = Directions.Up;
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (PlayerHead.Direction != Directions.Right)
                        PlayerHead.Direction = Directions.Right;
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (PlayerHead.Direction != Directions.Left)
                        PlayerHead.Direction = Directions.Left;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (PlayerHead.Direction != Directions.Down)
                        PlayerHead.Direction = Directions.Down;
                    break;
            }
        }
      
        public override void Update()
        {
            switch (Direction)
            {
                case Directions.Up:
                    Position.Y--;
                    break;
                case Directions.Down:
                    Position.Y++;
                    break;
                case Directions.Right:
                    Position.X++;
                    break;
                case Directions.Left:
                    Position.X--;
                    break;
            }

        }


    }
}

