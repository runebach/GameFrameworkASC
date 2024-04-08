using GameFrameworkASC.Models.Interfaces;

namespace GameFrameworkASC.Models
{
    public class GameWorld
    {
        public int XWidth { get; set; }
        public int YHeight { get; set; }

        public GameWorld()
        {
                
        }

        public GameWorld(int xWidth, int yHeight)
        {
            XWidth = xWidth;
            YHeight = yHeight;
        }
    }
}
