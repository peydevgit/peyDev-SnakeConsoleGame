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
            const int FrameRate = 10;
            GameWorld World = new GameWorld(GameWidth, GameHeight, StartScore);
            ConsoleRenderer Renderer = new ConsoleRenderer(World);
            

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            Player PlayerHead = new Player(new Position(5, 5), '@'); // Första Spelaren
            Food Food = new Food(new Position(GameWorld.Random.Next(2, GameWidth-2), GameWorld.Random.Next(2, GameHeight-2)), '$'); // Första Fooden
            GameWorld.ObjectList.Add(PlayerHead);
            GameWorld.ObjectList.Add(Food);
            

            // Start värden innan spelet börjar.
            PlayerHead.Direction = Player.Directions.Right;
           
            // vi renderar världens kanter en gång.
            Renderer.RenderWorld();
            Console.CursorVisible = false;
            // Huvudloopen
            bool running = true;
            while (running)
            {
                
                Console.Title = "Score: " + GameWorld.Score;
                // Kom ihåg vad klockan var i början
                DateTime Before = DateTime.Now;

                ConsoleKey key = ReadKeyIfExists();

                // Kollar ifall de trycker Escape för att avsluta.
                if (key == ConsoleKey.Escape)
                    running = false;

                // Hantera knapptryckningar från användaren -> static metod från Player.
                Player.PlayerKeyInput(key, PlayerHead);

                // Uppdatera världen och rendera om
                Renderer.RenderBlank();
                World.Update();
                Renderer.Render();

                // Mät hur lång tid det tog
                double FrameTime = Math.Ceiling((1000.0 / FrameRate) - (DateTime.Now - Before).TotalMilliseconds);
                if (FrameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)FrameTime);
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
