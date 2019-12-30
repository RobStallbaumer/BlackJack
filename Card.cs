using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public int _rank;

        public bool IsFaceUp { get; set; }

        public Suits _suit;
        public enum Suits
        {
            DIAMONDS, SPADES, HEARTS, CLUBS
        }
        public Card(int rank, int suit)
        {
            IsFaceUp = false;
            _rank = rank;
            if(suit == 0)
            {
                _suit = Suits.DIAMONDS;
            }
            else if(suit == 1)
            {
                _suit = Suits.SPADES;
            }
            else if(suit == 2)
            {
                _suit = Suits.HEARTS;
            }
            else if(suit == 3)
            {
                _suit = Suits.CLUBS;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
