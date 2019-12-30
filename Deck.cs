using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        /// <summary>
        /// stores the deck to be used in a stack to ensure easy drawing of card
        /// </summary>
        public Stack<Card> deck;

        /// <summary>
        /// constructor initializes deck and fills it with 52 new cards then shuffles it
        /// </summary>
        public Deck()
        {
            deck = new Stack<Card>();
            FillDeck();
            ShuffleDeck();
        }

        /// <summary>
        /// fills the deck with 52 new cards 
        /// </summary>
        public void FillDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Card newCard = new Card(j, i);
                    deck.Push(newCard);
                }
            }
        }

        /// <summary>
        /// shuffles the deck by putting it into a temporary array then swaping cards at random
        /// </summary>
        public void ShuffleDeck()
        {
            Card[] d = new Card[52];
            Random rand = new Random();
            for (int i = 0; i < d.Length; i++)
            {
                if(deck.Peek() != null)
                {
                    d[i] = deck.Pop();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            for(int i = 0; i < 80; i++)
            {
                int index1 = rand.Next(0, 52);
                int index2 = rand.Next(0, 52);
                Card temp = d[index1];
                d[index1] = d[index2];
                d[index2] = temp;
            }

            for(int i = 0; i < d.Length; i++)
            {
                deck.Push(d[i]);
            }
        }

        /// <summary>
        /// draws a card to deal out to a player / dealer
        /// </summary>
        /// <returns> the top card on the stack to be dealt </returns>
        public Card DrawCard()
        {
            if (deck.Count > 0)
            {
                return deck.Pop();
            }
            else
            {
                return null;
            }
        }
    }
}
