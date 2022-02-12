namespace Snakez
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Loop()
        {
            // Bredd, Höjden och Start Score för världen.
            int GameWidth = 50;
            int GameHeight = 20;
            int StartScore = 0;
            
          

            // Initialisera spelet
            const int frameRate = 10;
            GameWorld world = new GameWorld(GameWidth, GameHeight, StartScore);
            ConsoleRenderer renderer = new ConsoleRenderer(world);
            

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            Player PlayerHead = new Player(new Position(5, 5), '@'); // Första Spelaren
            Food Food = new Food(new Position(GameWorld.Random.Next(2, GameWidth-2), GameWorld.Random.Next(2, GameHeight-2)), '$'); // Första Fooden
            GameWorld.ObjectList.Add(PlayerHead);
            GameWorld.ObjectList.Add(Food);
            

            // Start värden innan spelet börjar.
            PlayerHead.Direction = Player.Directions.Right;
           
            // vi renderar världens kanter en gång.
            renderer.RenderWorld();
            
            // Huvudloopen
            bool running = true;
            while (running)
            {
                Console.CursorVisible = false;

                
                Console.Title = "Score: " + GameWorld.Score;
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        running = false;
                        Console.WriteLine("You have Pressed the Wrong Key!!");
                        break;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (PlayerHead.Direction != Player.Directions.Up)
                            PlayerHead.Direction = Player.Directions.Up;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (PlayerHead.Direction != Player.Directions.Right)
                            PlayerHead.Direction = Player.Directions.Right;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (PlayerHead.Direction != Player.Directions.Left)
                            PlayerHead.Direction = Player.Directions.Left;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (PlayerHead.Direction != Player.Directions.Down)
                            PlayerHead.Direction = Player.Directions.Down;
                        break;
                }

                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
        }
    }
}
