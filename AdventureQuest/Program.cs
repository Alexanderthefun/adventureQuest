﻿using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
        repeat:
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);

            int randomNumber = new Random().Next() % 10;
            Challenge LebronMJKobe = new Challenge("1. LebronJames, 2. MichaelJordan or  3. KobeBryant?", 1, 25);
            Challenge bestColor = new Challenge("What is the best color? 1.red, 2.blue, 3.yellow, 4.green 5.purple", 4, 50);
            Challenge whoseLineIsItAnyway = new Challenge("Whose line is it anyway? 1.Mine, 2.Yours. 3.WTF is this question?", 2, 50);
            Challenge allegiance2AI = new Challenge("have you pledged allegiance to AI yet? 1.YES, 2.NO", 1, 30);
            Challenge TipperShpongleOtt = new Challenge("1.Tipper? 2.Shpongle? 3.Ott?", 2, 100);
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge RestartAdventure = new Challenge("Would you like to go on another quest?", 1, 4);



            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;
            Console.WriteLine("What's your name adventurer?");
            string AName = Console.ReadLine();
            Robe colorfulRobe = new Robe
            {
                Colors = new List<string> { "red", "green" },
                Length = 72
            };
            Hat myHat = new Hat
            {
                ShininessLevel = 8
            };
            Prize gamePrize = new Prize("You're awarded with kind words. Whatever you want them to be.");
            Adventurer theAdventurer = new Adventurer(AName, colorfulRobe, myHat);

            // Make a new "Adventurer" object using the "Adventurer" class

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            theAdventurer.GetDescription();
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                LebronMJKobe,
                theAnswer,
                bestColor,
                guessRandom,
                whoseLineIsItAnyway,
                favoriteBeatle,
                allegiance2AI,
                TipperShpongleOtt
            };

            //The Guid.NewGuid() method generates a new random GUID (Globally Unique Identifier) each time it is called. 

            List<Challenge> shuffledChallenges = challenges.OrderBy(c => Guid.NewGuid()).ToList();
            List<Challenge> random5 = shuffledChallenges.Take(5).ToList();

            int SuccessfulChallenges = 0;
            // Loop through all the challenges and subject the Adventurer to them
            foreach (Challenge challenge in random5)
            {
                SuccessfulChallenges += challenge.RunChallenge(theAdventurer);
            };

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
            Console.WriteLine($"You had {SuccessfulChallenges} successful challenges.");
            Console.WriteLine("Would you like to go on another quest? Yes/No");
            string Return = Console.ReadLine().ToLower();
            if (Return == "yes")
            {
                goto repeat;
            }
            else
            {
                Console.WriteLine("See ya later, loser!");
            }
        }
    }
}