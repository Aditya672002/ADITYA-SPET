using System;

namespace Petassignment
{
    class MyPet
    {
        public string PetName { get; set; }
        public string PetType { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Health { get; set; }

        public MyPet(string name, string type)
        {
            PetName = name;
            PetType = type;
            Hunger = 5;
            Happiness = 5;
            Health = 10;
        }

        public void Feed()
        {
            Hunger -= 2;
            Health += 1;
            Console.WriteLine($"You fed {PetName}! Hunger decreased by 2, Health increased by 1.");
        }

        public void Play()
        {
            if (Hunger > 3)
            {
                Happiness += 2;
                Hunger += 1;
                Console.WriteLine($"You played with {PetName}! Happiness increased by 2, Hunger increased by 1.");
            }
            else
            {
                Console.WriteLine($"{PetName} is too hungry to play. Please feed them first!");
            }
        }

        public void Rest()
        {
            Health += 2;
            Happiness -= 1;
            Console.WriteLine($"You let {PetName} rest. Health increased by 2, Happiness decreased by 1.");
        }

        public void CheckStatus()
        {
            Console.WriteLine($"** {PetName}'s Status **");
            Console.WriteLine($"Hunger: {Hunger}/10");
            Console.WriteLine($"Happiness: {Happiness}/10");
            Console.WriteLine($"Health: {Health}/10");

            if (Hunger < 3)
            {
                Console.WriteLine("NOTE: Hunger is critically low!");
            }
            if (Happiness < 3)
            {
                Console.WriteLine("NOTE: Happiness is critically low!");
            }
            if (Health < 5)
            {
                Console.WriteLine("NOTE: Health is critically low!");
            }
        }

        public void SimulateTimePassage()
        {
            Hunger += 1;
            Happiness -= 1;
            Console.WriteLine("Time passed... Hunger increased by 1, Happiness decreased by 1.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO MYPET CARE!");
            Console.Write("Enter your Favorite pet's name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter your Favorite pet's type (Rabbit, Horse, Goat): ");
            string Type = Console.ReadLine();

            MyPet pet = new MyPet(Name, Type);
            Console.WriteLine($"You've adopted a {Type} named {Name}!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check Status of your pet");
                Console.WriteLine("5. Exit the application");

                int choice;
                bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        pet.Feed();
                        break;
                    case 2:
                        pet.Play();
                        break;
                    case 3:
                        pet.Rest();
                        break;
                    case 4:
                        pet.CheckStatus();
                        break;
                    case 5:
                        Console.WriteLine("THANK YOU!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }

                pet.SimulateTimePassage();

                if (pet.Hunger > 8)
                {
                    Console.WriteLine("NOTE: Starvation is getting too high! It is important that you feed your pet as soon as possible!");
                }
                if (pet.Happiness < 2)
                {
                    Console.WriteLine("NOTE: The happiness is getting too low! You should engage your pet in play as soon as possible!");
                }
                if (pet.Health < 3)

                    Console.WriteLine("NOTE: I think health is getting too low! Relax your pet as soon as possible!");
            }
        }
    }
}
