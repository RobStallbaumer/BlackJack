using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Dealer
    {
        public Card[] Hand { get; set; }
        public int HandCount { get; set; }
       // public int Score { get; set; }
        public Dealer()
        {
            Hand = new Card[6];
            HandCount = 0;
           // Score = 0;
        }
    }
}
