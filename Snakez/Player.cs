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

