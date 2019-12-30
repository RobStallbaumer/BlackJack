using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        public Deck Deck { get; set; }
        public Player Player { get; private set; }
        public Dealer Dealer { get; private set; }

        
        public Game()
        {
            Deck = new Deck();
            Player = new Player();
            Dealer = new Dealer();
        }

        /// <summary>
        /// deals the player a card and puts it into the hand Property of the player
        /// </summary>
        public void DealPlayerCard()
        {
            int index = 0;
            while(Player.Hand[index] != null)
            {
                if (index < 4)
                {
                    index++;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            Player.Hand[index] = Deck.DrawCard();
            Player.Hand[index].IsFaceUp = true;
        }

        /// <summary>
        /// deals the Dealer a card and puts it into the hand property of the dealer
        /// </summary>
        /// <param name="faceUp"></param>
        public void DealDealerCard(bool faceUp)
        {
            int index = 0;
            while(Dealer.Hand[index] != null)
            {
                if(index < 4)
                {
                    index++;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            Dealer.Hand[index] = Deck.DrawCard();
            Dealer.Hand[index].IsFaceUp = faceUp;
        }

        /// <summary>
        /// gets the score and factors any aces
        /// </summary>
        /// <param name="hand"> the hand to get the score of </param>
        /// <returns> the score </returns>
        public int GetScore(Card[] hand)
        {
            int score = 0;
            bool containsAce = false;
            int numAces = 0;
            for(int i = 0; i < hand.Length; i++)
            {
                if(hand[i] == null)
                {
                    continue;
                }
                else if(hand[i]._rank == 1)
                {
                    containsAce = true;
                    numAces++;
                    score = score + 11;
                }
                else if(hand[i]._rank < 10 && hand[i]._rank > 1)
                {
                    score = score + hand[i]._rank;
                }
                else if(hand[i]._rank > 9 && hand[i]._rank < 14)
                {
                    score = score + 10;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            if (containsAce)
            {
                int count = 0;
                while(score > 21 && count < numAces)
                {
                    score = score - 10;
                    count++;
                }
                return score;
            }
            return score;
        }

        public Stack<string> GetHandString(Card[] hand)
        {
            Stack<string> stack = new Stack<String>();
            for(int i = 0; i < hand.Length; i++)
            {
                if(hand[i] == null)
                {
                    stack.Push("");
                }
                else if(hand[i].IsFaceUp == false)
                {
                    stack.Push("**");
                }
                else if(hand[i]._rank == 1)
                {
                    stack.Push("A of " + hand[i]._suit);
                }
                else if(hand[i]._rank > 1 && hand[i]._rank < 10)
                {
                    stack.Push(Convert.ToString(hand[i]._rank) + " of " + hand[i]._suit);
                }
                else if(hand[i]._rank == 11)
                {
                    stack.Push("J of " + hand[i]._suit);
                }
                else if(hand[i]._rank == 12)
                {
                    stack.Push("Q of " + hand[i]._suit);
                }
                else if(hand[i]._rank == 13)
                {
                    stack.Push("K of " + hand[i]._suit);
                }
            }
            return stack;
        }
    }
}
