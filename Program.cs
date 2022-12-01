//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Mordor_s_Cruel_Plan
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            List<string> list = Console.ReadLine().Split(' ').ToList();
//            MoodFactory moodFactory = new MoodFactory();
//            FoodFactory foodFactory = new FoodFactory(list);

//            //Console.WriteLine(foodFactory.GetPoints());

//        }
//    }
//    public abstract class FoodPoints
//    {
//        protected const int cramPoints = 2;
//        protected const int lembasPoints = 3;
//        protected const int applePoints = 1;
//        protected const int melonPoints = 1;
//        protected const int honeyCakePoints = 5;
//        protected const int mushroomsPoints = -10;
//        //protected List<int> AllPoints = new List<int>() { cramPoints, lembasPoints, applePoints, melonPoints, honeyCakePoints, mushroomsPoints};
//        protected List<string> AllFoods = new List<string>() { "cram", "lembas", "apple", "melon", "honeyCake", "mushrooms" };


//    }
//    //Cram   melon   honeyCake   Cake = food -> list1
//    //  2  +   1   +    5      + (-1) = 7
//    //Console.ReadLine(Cram, melon, honeyCake, Cake)
//    //Otgovor = 7
//    public class FoodFactory : FoodPoints
//    {
//        private int points = 0;
//        public FoodFactory(List<string> food)
//        {
//            var list1 = food.Select(x => x.ToString().ToLower()).ToList();

//            Console.WriteLine(Points);

//        }

//        public int Points { get; }
//        public int GetPoints()
//        {
//            int result = Points;
//            return result;
//        }
//    }



//    public class Mood
//    {
//        public Mood()
//        {

//        }
//        public Mood(string name)
//        {
//            Name = name;
//        }

//        public string Name { get; set; }
//    }

//    public static class MoodFactory
//    {

//        public static Mood Make(int points)
//        {

//            if (points < -5)
//            {
//                return new Mood() { Name = "Angry" };
//            }
//            else if (points >= -5 && points <= 0)
//            {
//                return new Mood("Sad");
//            }
//            else if (points >= 1 && points <= 15)
//            {
//                return new Mood("Happy");
//            }
//            return new Mood("JavaScript");



//        }
//    }

//}

using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //var foodFactory = new FoodFactory();


        //string[] inputArr = Console.ReadLine().Split(" ");

        //Food[] foods = inputArr.Select(f => foodFactory.Make(f)).ToArray();

        //var totalPoints = foods.Select(f => f.Points).Sum();

        //Console.WriteLine(totalPoints);

        //Console.WriteLine(MoodFactory.Make(totalPoints).Name);



        var foodFactory = new FoodFactory();

        int totalFoodPoints = Console.ReadLine()
            .Split(" ")
            .Select(f => foodFactory.Make(f))
            .Select(f => f.Points).Sum();   

        Console.WriteLine(totalFoodPoints + "\n"+ MoodFactory.Make(totalFoodPoints).Name);
    }


    public class Mood
    {
        public Mood()
        { }
        public Mood(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }

    public static class MoodFactory
    {
        public static Mood Make(int points)
        {

            if (points < -5)
            {
                return new Mood() { Name = "Angry" };
            }
            else if (points >= -5 && points <= 0)
            {
                return new Mood("Sad");
            }
            else if (points >= 1 && points <= 15)
            {
                return new Mood("Happy");
            }
            return new Mood("JavaScript");
        }


    }





    public class FoodFactory
    {
        private int coef;

        public FoodFactory(int coef = 1)
        {
            this.coef = coef;
        }

        public Food Make(string nameOfFood)//"CrAm "
        {
            nameOfFood = nameOfFood.ToLower().Trim();
            switch (nameOfFood)
            {
                case "cram":
                    {
                        if (coef != 1)
                        {
                            return new Cram(coef);
                        }
                        return new Cram();
                    }
                case "lembas":
                    {
                        return new Lembas();
                    }
                case "apple":
                    {
                        return new Apple();
                    }
                case "melon":
                    {
                        return new Melon();
                    }
                case "honeycake":
                    {
                        return new HoneyCake();
                    }
                case "mushrooms":
                    {
                        return new Mushrooms();
                    }
                default:
                    {
                        return new OtherFood();
                    }
            }
        }


        //switch (expression)
        //{
        //    case x:
        //        // code block
        //        break;
        //    case y:
        //        // code block
        //        break;
        //    default:
        //        // code block
        //        break;
        //}



    }


    public abstract class Food
    {
        protected int multiplier = 1;
        private int points;

        protected Food(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public string Name { get; private set; }
        public int Points { get => points * multiplier; private set => points = value; }
    }

    //        /*
    //        Cram: 2 points of happiness;
    //        Lembas: 3 points of happiness;
    //        Apple: 1 point of happiness;
    //        Melon: 1 point of happiness;
    //        HoneyCake: 5 points of happiness;
    //        Mushrooms: -10 points of happiness;
    //        Everything else: -1 point of happiness;
    //        */






    public class Cram : Food
    {
        private string multiplier;
        public Cram(int multiplier = 1) : base("Cram", 2)
        {
            base.multiplier = multiplier;
        }
    }

    public class Lembas : Food
    {
        public Lembas() : base("Lembas", 3)
        { }
    }

    public class Apple : Food
    {
        public Apple() : base("Apple", 1)
        { }
    }

    public class Melon : Food
    {
        public Melon() : base("Melon", 1)
        { }
    }

    public class HoneyCake : Food
    {
        public HoneyCake() : base("HoneyCake", 5)
        { }
    }
    public class Mushrooms : Food
    {
        public Mushrooms() : base("HoneyCake", -10)
        { }
    }

    public class OtherFood : Food
    {
        public OtherFood() : base("Everything Else", -1)
        { }
    }


}