using System;
using System.Linq;
using System.IO;
using static System.Console;
using System.Collections.Generic;

namespace TextFileGame
{
    //my reference for the turn based system:
    //https://thecoderscat.wordpress.com/2021/12/20/csharp-turn-based-console-game/

    class Program
    {
        static void Main(string[] args)
        {
            int playerHP = 300;
            int frogHP = 300;
            int dragonHP = 700;
            int goblinHP = 900;
            int HEAL = 100;

            int playerATK = 300;
            int frogATK = 100;
            int dragonATK = 100;
            int goblinATK = 50;

            Random random = new Random();

            string filePath = @"C:\Users\13129\Desktop\TextFileGame\Stats.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            WriteLine("Here are your generated monsters!!");

            foreach (string lin in lines)
            {
                WriteLine(lin);
            }

            //just input the intended letter before the writeline, hit space and input the intended letter again for it to work.
            string choice = ReadLine();
            WriteLine("enter 's'  to teleport to the SWAMP room to fight the Frog God");
            ReadKey();
            if (choice == "s")
            {
                while (playerHP > 0 && frogHP > 0)
                {
                    // Player turn
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Player turn");
                    WriteLine("Enter 'a' to attack or 'h' to heal.");
                    string choice1 = ReadLine();
                    if (choice1 == "a")
                    {
                        frogHP -= playerATK;
                        WriteLine("player attacks with " + playerATK + " damage");
                    }
                    else
                    {
                        playerHP += HEAL;
                        WriteLine("Player heals " + HEAL + " HP");
                    }

                    //frog's turn
                    if (frogHP > 0)
                    {
                        WriteLine("Enemy turn");
                        WriteLine("Player HP is " + playerHP + " | Enemy HP is " + frogHP);
                        int frogChoice = random.Next(0, 2);
                        if (frogChoice == 0)
                        {
                            playerHP -= frogATK;
                            WriteLine("Frog God attacks, dealing " + frogATK + " damage");
                        }
                        else
                        {
                            frogHP += HEAL;
                            WriteLine("Frog God heals " + HEAL + " HP");
                        }
                    }
                }
                if (playerHP > 0)
                {
                    //goes to the next room 
                    ResetColor();
                    WriteLine("you defeated the Frog god, nice onto the next room!!!");
                    string otherchoice = ReadLine();
                    WriteLine("enter 'd'  to teleport to the SKY room to fight the Dragon God");
                    ReadKey();
                    if (otherchoice == "d")
                    {
                        while (playerHP > 0 && dragonHP > 0)
                        {
                            // Player turn
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Player turn");
                            WriteLine("Enter 'a' to attack or 'h' to heal.");
                            string choice2 = ReadLine();
                            if (choice2 == "a")
                            {
                                dragonHP -= playerATK;
                                WriteLine("player attacks with " + playerATK + " damage");
                            }
                            else
                            {
                                playerHP += HEAL;
                                WriteLine("Player heals " + HEAL + " HP");
                            }

                            //dragon's turn
                            if (dragonHP > 0)
                            {
                                WriteLine("Enemy turn");
                                WriteLine("Player HP is " + playerHP + " | Enemy HP is " + dragonHP);
                                int dragonChoice = random.Next(0, 2);
                                if (dragonChoice == 0)
                                {
                                    playerHP -= dragonATK;
                                    WriteLine("Dragon God attacks, dealing " + dragonATK + " damage");
                                }
                                else
                                {
                                    dragonHP += HEAL;
                                    WriteLine("Dragon God heals " + HEAL + " HP");
                                }
                            }
                        }
                        if (playerHP > 0)
                        {
                            //goes to the next room
                            ResetColor();
                            WriteLine("you defeated the Dragon god, nice onto the next room!!!");
                            string otherotherchoice = ReadLine();
                            WriteLine("enter 'f'  to teleport to the CASTLE room to fight the Goblin God");
                            ReadKey();
                            if (otherotherchoice == "f")
                            {
                                while (playerHP > 0 && goblinHP > 0)
                                {
                                    // Player turn
                                    ForegroundColor = ConsoleColor.Magenta;
                                    WriteLine("Player turn");
                                    WriteLine("Enter 'a' to attack or 'h' to heal.");
                                    string choice3 = ReadLine();
                                    if (choice3 == "a")
                                    {
                                        goblinHP -= playerATK;
                                        WriteLine("player attacks with " + playerATK + " damage");
                                    }
                                    else
                                    {
                                        playerHP += HEAL;
                                        WriteLine("Player heals " + HEAL + " HP");
                                    }

                                    //goblin's turn
                                    if (goblinHP > 0)
                                    {
                                        WriteLine("Enemy turn");
                                        WriteLine("Player HP is " + playerHP + " | Enemy HP is " + goblinHP);
                                        int goblinChoice = random.Next(0, 2);
                                        if (goblinChoice == 0)
                                        {
                                            playerHP -= goblinATK;
                                            WriteLine("Goblin God attacks, dealing " + goblinATK + " damage");
                                        }
                                        else
                                        {
                                            goblinHP += HEAL;
                                            WriteLine("Goblin God heals " + HEAL + " HP");
                                        }
                                    }
                                }
                                if(playerHP > 0)
                                {
                                    //prints out the results
                                    WriteLine("printing out the results on the txt file");
                                    lines.Add("CONGRAGULATIONS YOU BEAT IT! YOU DEFEATED ALL THE GODS");
                                    File.WriteAllLines(filePath, lines);
                                }
                                else
                                {
                                    //prints out the defeated on the txt flle
                                    WriteLine("printing your bad ending on the txt file");
                                    lines.Add("Sadly your player lost, at least you beaten two gods.");
                                    File.WriteAllLines(filePath, lines);
                                }
                            }
                            else
                            {
                                //prints out the defeated on the txt file
                                WriteLine("printing your bad ending on the txt file");
                                lines.Add("Sadly your player lost, at least you beaten one god.");
                                File.WriteAllLines(filePath, lines);
                            }

                        }


                    }
                    else
                    {
                        //prints out the defeated on the txt file
                        WriteLine("printing your bad ending on the txt file");
                        lines.Add("Sadly your player lost, though you couldn't defeat no gods.");
                        File.WriteAllLines(filePath, lines);
                    }
                }

            }
        }
    }
}
