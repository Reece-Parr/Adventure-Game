﻿using System;
using System.Formats.Asn1;
using System.Text.RegularExpressions;

namespace TurnBasedCombatGame 
{
    class Game
    {
        static void Main(string[] args)
        {
            Introduction();
            // Object o = ChooseClass("Mark");
            // Console.WriteLine(o.ToString());
        }

        public static void Introduction() {
            Console.WriteLine("Hello adventurer! Welcome to Asgard. What may I call you?");
            string? name = Console.ReadLine();
            
            bool isValid = isValidName(name);
            while (!isValid) {
                Console.Write("Your name cannot be blank or include numbers. Enter a new name:");
                name = Console.ReadLine();
                isValid = isValidName(name);
            } 

            bool isConfirm = false;
            while(!isConfirm) 
            {
                Console.WriteLine("Would you like to confirm that name? (y or n)");
                var answer = Console.ReadLine();
                if (answer == "y" || answer == "Y") 
                {
                    isConfirm = true;
                }
                else if (answer == "n" || answer == "N") 
                {
                    Console.WriteLine("Please enter a new name: ");
                    name = Console.ReadLine();
                    continue;
                } 
                else 
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }

            ICharacter character = ChooseClass(name);

            // ADD DELAY FUNCTION to create a delay between commands for ease of reading.
            Console.WriteLine("Hello " + character.GetName() + ", let's take a look at your profile...");
            Delay(2000);
            Console.WriteLine(character.ToString());

        }

        public static ICharacter ChooseClass(String? name)
        {
            int option;
            while(true)
            {
                Console.WriteLine("Please choose your class: \n 1. Warrior \n 2. Mage");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out option))
                {
                    switch(option)
                    {
                        case 1:
                            return new Warrior(name);
                        case 2:
                            return new Mage(name);
                        default:
                            Console.WriteLine("Invalid class input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        public static bool isValidName(string? nameInput) 
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(nameInput)) {
                isValid = false;
            } else {
                isValid = Regex.IsMatch(nameInput, @"^[a-zA-Z]+$");
            }

            foreach (char c in nameInput) {
                if(!char.IsLetter(c)) {
                    isValid = false;
                }
            }
            return isValid;
        }

        public static void Delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        
    }
}