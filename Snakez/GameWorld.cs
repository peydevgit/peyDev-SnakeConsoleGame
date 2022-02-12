namespace Snakez
{
    public class GameWorld
    {
        public static Random Random = new Random();

        public static List<GameObject> ObjectList = new List<GameObject>();

        public int Width;
        public int Height;
        public static int Score;

        public GameWorld(int x, int y, int score)
        {
            Width = x;
            Height = y;
            Score = score;
        }
        public void Update()
        {
            // Loopa igenom listan av objekt och anropa Update() på dem.
            foreach (GameObject objects in ObjectList)
                objects.Update();

            /// Kolla om matbiten har samma position som player så blir den uppäten -- > loop inside a loop
            foreach (GameObject food in ObjectList.ToList())
            {

                if (food is Food) // Ifall objektet är av typen Food
                { 
                    foreach (GameObject player in ObjectList.ToList())
                    {
                        if (player is Player)
                        {
                            if (food.Position.X == player.Position.X && food.Position.Y == player.Position.Y) // Jämnför positionerna 
                            {
                                Food.EatFood(food);
                            }
                        }
                    }
                }

            }
        }
    }
}
