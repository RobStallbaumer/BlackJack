using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        public Card[] Hand { get; set; }
        public int Wallet { get; set; }
        public int HandCount { get; set; }

       // public int Score { get; set; }
        public Player()
        {
            HandCount = 0;
            Wallet = 30;
            Hand = new Card[6];
           // Score = 0;
        }


    }
}
