namespace Snakez
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek
            Console.WindowHeight = gameWorld.Height + 1;
            Console.WindowWidth = gameWorld.Width + 1;
            world = gameWorld;
        }
        // en metod vi kommer använda flera gånger av för att förminska koden!
        public void RenderObjects(int X, int Y, char character)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(character);
        }
        public void RenderWorld()
        {
            Console.Clear();
            /// Färgar väggarna av världen.
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            // Renderar Toppen och botten av världen.
            for (int i = 0; i <= world.Width; i++)
            {
                RenderObjects(i, 0, '-'); // Toppen
                RenderObjects(i, world.Height, '-'); // Botten
            }
            // Rendererar Höger och Vänster sida av världen.
            for (int i = 0; i <= world.Height; i++)
            {
                RenderObjects(0, i, '|');
                RenderObjects(world.Width, i, '|');
            }
            Console.ResetColor();
        }
        /// <summary>
        /// 
        /// </summary>
        public void RenderBlank()
        {
            foreach (GameObject obj in world.ObjectList)
            {
                // vi renderar blank efter spelaren bara annars när en food äts upp så kommer båda blinka en gång för att de är på samma position.
                if (obj is Player)
                RenderObjects(obj.Position.X, obj.Position.Y, ' ');
            }
        }

        public void Render()
        {
            foreach (GameObject obj in world.ObjectList)
            {
                if (obj is Player)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (obj.Position.X < 1)
                    {
                        RenderObjects(obj.Position.X = world.Width - 1, obj.Position.Y, obj.Appeareance);
                    }
                    else if (obj.Position.Y < 1)
                    {
                        RenderObjects(obj.Position.X, obj.Position.Y = world.Height - 1, obj.Appeareance);
                    }
                    else if (obj.Position.X >= world.Width)
                    {
                        RenderObjects(obj.Position.X = 1, obj.Position.Y, obj.Appeareance);
                    }
                    else if (obj.Position.Y >= world.Height)
                    {
                        RenderObjects(obj.Position.X, obj.Position.Y = 1, obj.Appeareance);
                    }
                    else
                    {
                        RenderObjects(obj.Position.X, obj.Position.Y, obj.Appeareance);
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
                    RenderObjects(obj.Position.X, obj.Position.Y, obj.Appeareance);
                    Console.ResetColor();
                }
            }
        }
    }
}


