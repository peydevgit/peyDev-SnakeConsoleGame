namespace Snakez
{
    public abstract class GameObject
    {
        public Position Position;
        public char Appeareance;

        public GameObject(Position position, char appereance)
        {
           Position = position;
           Appeareance = appereance;
         }
        public abstract void Update();
        
    }
}
