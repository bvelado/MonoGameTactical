using System;

namespace TurnBasedTileMapRPG
{
    public class RandomController
    {
        private static RandomController instance;
        public static RandomController Instance 
        {
            get {
                if (instance == null)
                {
                    instance = new RandomController();   
                }

                return instance;
            }
        }

        private Random randomInstance;

        public RandomController()
        {
            var tempRandom = new Random();
            randomInstance = new Random(tempRandom.Next());
        }

        public int Range(int min, int max)
        {
            return randomInstance.Next(min, max);
        }
    }
}
