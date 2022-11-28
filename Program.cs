using System;
using System.Collections.Generic;
using System.Linq;

namespace Mordor_s_Cruel_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = Console.ReadLine().Split(' ').ToList();
            MoodFactory moodFactory = new MoodFactory();
            FoodFactory foodFactory = new FoodFactory(list);

            //Console.WriteLine(foodFactory.GetPoints());
            moodFactory.GetMood();
        }
    }
    public abstract class FoodPoints
    {
        protected const int cramPoints = 2;
        protected const int lembasPoints = 3;
        protected const int applePoints = 1;
        protected const int melonPoints = 1;
        protected const int honeyCakePoints = 5;
        protected const int mushroomsPoints = -10;    
        //protected List<int> AllPoints = new List<int>() { cramPoints, lembasPoints, applePoints, melonPoints, honeyCakePoints, mushroomsPoints};
        protected List<string> AllFoods = new List<string>() { "cram", "lembas", "apple", "melon", "honeyCake", "mushrooms" };
        
        /*
        Cram: 2 points of happiness;
        Lembas: 3 points of happiness;
        Apple: 1 point of happiness;
        Melon: 1 point of happiness;
        HoneyCake: 5 points of happiness;
        Mushrooms: -10 points of happiness;
        Everything else: -1 point of happiness;
        */
    }
    //Cram   melon   honeyCake   Cake = food -> list1
    //  2  +   1   +    5      + (-1) = 7
    //Console.ReadLine(Cram, melon, honeyCake, Cake)
    //Otgovor = 7
    public class FoodFactory : FoodPoints
    {
        private int points = 0;
        public FoodFactory(List<string> food)
        {
            var list1 = food.Select(x => x.ToString().ToLower()).ToList();
            
            Console.WriteLine(Points);

        }
        
        public int Points { get; }
        public int GetPoints()
        {
            int result = Points;
            return result;
        }
    }
    public class MoodFactory
    {
        FoodFactory foodFactory;
        public void GetMood()
        {
            if(foodFactory.Points < -5)
            {
                Console.WriteLine("Angry");
            }
            else if(foodFactory.Points >= -6 && foodFactory.Points <=0)
            {
                Console.WriteLine("Sad");
            }
            else if (foodFactory.Points >= 1 && foodFactory.Points <= 15)
            {
                Console.WriteLine("Happy");
            }
            else if (foodFactory.Points > 15)
            {
                Console.WriteLine("JavaScript");
            }
        }
    }
    
}
