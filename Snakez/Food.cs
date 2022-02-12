namespace Snakez
{
    public class Food : GameObject
    {
       
      
        public Food(Position position, char appeareance) : base(position, appeareance)
        {
           
        }
        public static void EatFood(object food)
        {
            //Raderar matbiten som har blivit uppäten.
            GameWorld.ObjectList.Remove((GameObject)food);
            Food NewFood = new Food(new Position(GameWorld.Random.Next(2, 48), GameWorld.Random.Next(2, 18)), '$');
            GameWorld.ObjectList.Add(NewFood);

            Console.Beep();
            GameWorld.Score++;
        }
        public override void Update()
        {
           

        }


    }
}
