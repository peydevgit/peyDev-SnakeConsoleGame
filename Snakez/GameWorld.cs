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
                // Ifall objektet är av typen Food
                if (food is Food)
                {
                    // Hämta spelar instansen med hjälp av Linq (Kommer bara funka ifall det finns 1 och enbart 1 instans av Player pga .Single)
                    foreach (GameObject player in ObjectList.ToList())
                    {
                        // Ifall objektet är av typen Food
                        if (player is Player)
                        {
                            // Jämnför positionerna 
                            if (food.Position.X == player.Position.X && food.Position.Y == player.Position.Y)
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
