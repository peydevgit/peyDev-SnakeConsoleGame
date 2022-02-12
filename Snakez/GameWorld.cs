namespace Snakez
{
    public class GameWorld
    {
        Random random = new Random();

        public List<GameObject> ObjectList = new List<GameObject>();

        public int Width;
        public int Height;
        public int Score;

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
                                //Raderar matbiten som har blivit uppäten.
                                ObjectList.Remove(food);
                                
                                //Skapar en ny food..(En förbättring skulle nog vara att inte ta bort maten men bara byta till en ny random position)
                                Food NewFood = new Food(new Position(random.Next(2, 48), random.Next(2, 18)), '$');
                                ObjectList.Add(NewFood);

                                // Beep and lägger till poäng för att ha ätit upp den.
                                Console.Beep();
                                Score++;
                            }
                        }
                    }
                }

            }
        }
    }
}
