using System;
using System.Collections.Generic;

namespace BlackJack
{
    //blackjack programme with multiple user inputs
    class Program
    {
        //welcome screen
        static void Main(string[] args)
        {
            BackgroundColour();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to the Blackjack Table");
            Play();
        }

        //method to add background colour
        public static void BackgroundColour()
        {
            Console.WindowHeight = 25;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();

        }//End of background colour method

        //method to change text colour
        public static void TextColour(string house)
        {
            if (house == "Spades \u2660" || house == "Clubs \u2663")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            else if (house == "Hearts \u2665" || house == "Diamonds \u2666")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }//end of method to change text colour

        //method to play game
        public static void Play()
        {
            //create dealer and players
            var dealer = new Dealer(new Player("Dealer"), new List<Card>());
            var players = new List<Player>();
            CreatePlayers(players);

            Console.WriteLine();

            //deal 2 cards to each player
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}");
                while (player.Hand.Count < 2)
                {
                    var card = dealer.Deal();
                    player.Hand.Add(card);
                    player.Score = Score.EvaluateHand(player.Hand);
                    TextColour(card.House);
                    Console.WriteLine($"The card dealt is {card.Face} of {card.House}");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                //Display player score
                Console.WriteLine($"{player.Name}'s score is {player.Score}");

                //ask player to stick or twist
                StickOrTwist(dealer, player);

                #region Betting (Not Finished)
                //ask each player how much they want to bet
                //Console.WriteLine($"{player.Name}");
                //Console.WriteLine("How many chips would you like to put down ?");
                //string input = Console.ReadLine();
                //int chips = Convert.ToInt32(input);
                //player.Bet = Bet.TotalBet(chips);

                //Display player bet
                //Console.WriteLine($"{player.Name}'s current bet is {player.Bet}");
                //Console.WriteLine();

                ////ask if they want to bet more
                //Console.WriteLine($"Your current bet is {player.Bet}");
                //Console.WriteLine("Would you like to put down more chips? Y or N");
                //string answer = Console.ReadLine();

                ////more chips
                //if (answer is "y" || answer is "Y")
                //{
                //    Console.WriteLine("How many chips would you like to put down?");
                //    string input = Console.ReadLine();
                //    int chips = Convert.ToInt32(input);
                //    player.Bet = Bet.TotalBet(chips);
                //    Console.WriteLine($"{player.Name}'s current bet is {player.Bet}");
                //    Console.WriteLine();
                //}

                ////no more
                //else if (answer is "n" || answer is "N")
                //{
                //    Console.WriteLine("Next Player!");
                //    Console.WriteLine();
                //}
                #endregion
            }

            //get 2 random cards for dealer
            while (dealer.Hand.Count < 2)
            {
                var card = dealer.Deal();
                dealer.Hand.Add(card);
                dealer.Player.Score = Score.EvaluateHand(dealer.Hand);
                TextColour(card.House);
                Console.WriteLine($"The card dealt is {card.Face} of {card.House}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            //keep dealing if under 17
            while (dealer.Player.Score < 17)
            {
                var card = dealer.Deal();
                dealer.Hand.Add(card);
                dealer.Player.Score = Score.EvaluateHand(dealer.Hand);
                TextColour(card.House);
                Console.WriteLine($"The card dealt is {card.Face} of {card.House}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            //display dealer score
            Console.WriteLine($"Dealer's score is {dealer.Player.Score}");

            //busts or blackjacks
            BustsAndBlackjacks(players, dealer);

            //closest to 21
            Winner(players, dealer);

            //play again?
            PlayAgain();

            //pause console
            Console.ReadLine();
        }//end play method

        //create a player
        private static void CreatePlayers(List<Player> players)
        {
            var createPlayer = "y";
            do
            {
                Console.Write("Please enter your name: ");
                var name = Console.ReadLine();
                players.Add(new Player(name));
                Console.WriteLine($"{name} has sat at the table. \n Add more players ? Please enter y or n ");
                createPlayer = Console.ReadLine().ToLower();
            }
            while (createPlayer == "y");

        }//end of create player


        //method to stick or twist
        public static void StickOrTwist(Dealer dealer, Player player1)
        {
            //ask player if they want to stick or twist
            Console.Write("Do you want to stick or twist? Enter s or t: ");
            string answer = Console.ReadLine();

            //twist
            if (answer is "t" || answer is "T")
            {
                var card = dealer.Deal();
                player1.Hand.Add(card);
                player1.Score = Score.EvaluateHand(player1.Hand);
                TextColour(card.House);
                Console.WriteLine($"The card dealt is {card.Face} of {card.House}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                //display new score
                Console.WriteLine($"Your score is {player1.Score}");

                //bust over 21
                if (player1.Score > 21)
                {
                    Console.WriteLine("You're bust!");
                    Console.WriteLine();
                }

                else StickOrTwist(dealer, player1);
            }

            //stick
            else if (answer is "s" || answer is "S")
            {
                Console.WriteLine();
            }

            //invalid answer
            else
            {
                Console.WriteLine("Please choose s to stick or t to twist");
                StickOrTwist(dealer, player1);
            }

        }//end stick or twist method

        //any busts or blackjacks
        public static void BustsAndBlackjacks(List<Player> players, Dealer dealer)
        {
            //new list with all players and dealer
            List<Player> allPlayers = players;
            allPlayers.Add(dealer.Player);

            int noOfPlayers = allPlayers.Count;

            //check to see if anyone has gone bust
            for (var i = 0; i < noOfPlayers; i++)
            {
                //players that have over 21 go bust
                if (players[i].Score > 21)
                {
                    Console.WriteLine(players[i].Name + " has gone bust! ");
                }

                //if all players have over 21 they all go bust and draw
                if (allPlayers.Count == 0)
                {
                    Console.WriteLine("All players have gone bust, it's a draw!");
                }
            }

            //check to see if anyone has blackjack
            var blackJackPlayers = new List<Player>();
            for (var j = 0; j < allPlayers.Count; j++)
            {
                if (allPlayers[j].Score == 21)
                {
                    Console.WriteLine(players[j].Name + " has blackjack! ");
                    blackJackPlayers.Add(allPlayers[j]);
                }
            }

            //if only one player has blackjack they win
            if (blackJackPlayers.Count == 1)
            {
                Console.WriteLine(blackJackPlayers[0].Name + " wins! ");
            }

            //if multiple players have blackjack they draw
            else if (blackJackPlayers.Count > 1)
            {
                var names = "";
                foreach (Player player in blackJackPlayers)
                {
                    names = names + player.Name + "";
                }
                Console.WriteLine("Multiples blackjacks, draw between" + names);
            }//end busts and blackjacks

        }

        //closest to 21 is winner
        public static void Winner(List<Player> players, Dealer dealer)
        {
            //creating new list with all players and dealer
            List<Player> allPlayers = players;
            allPlayers.Add(dealer.Player);
            allPlayers.RemoveAll(player => player.Score > 21);

            //checking to make sure there are players left
            if (allPlayers.Count == 0)
            {
                Console.WriteLine("All players have gone bust, it's a draw!");
            }

            //calculating highest score
            else
            {
                Player winner = allPlayers[0];

                foreach (Player player in allPlayers)
                {
                    if (player.Score > winner.Score)
                    {
                        winner = player;
                    }
                }

                //if highest score is equal then draw
                var draw = false;
                foreach (Player player in allPlayers)
                {
                    if (player != winner && player.Score == winner.Score)
                    {
                        draw = true;
                        Console.WriteLine("Draw!");
                        //Console.WriteLine("All chips returned");
                    }
                }

                //if one player has a highest score they are the winner
                if (!draw)
                {
                    Console.WriteLine(winner.Name + " wins the game!");
                    //Console.WriteLine(winner.Name + $" wins all chips!");
                }
            }
        }//end of winner method

        //method to play again
        public static void PlayAgain()
            {
                //ask to play again
                Console.WriteLine();
                Console.Write("Do you want to play again? Enter y or n: ");
                string answer = Console.ReadLine();

                //if yes, play again
                if (answer is "y" || answer is "Y")
                {
                    Console.Clear();
                    Play();
                }

                //if no, clear and close
                else if (answer is "n" || answer is "N")
                {
                    Console.Clear();
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                //invalid answer
                else
                {
                    Console.WriteLine("Please choose y to play again or n to stop playing");
                    PlayAgain();
                }
            }//end method play again

    }//end of main method
}
