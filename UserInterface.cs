using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class uxBlackJack : Form
    {
        public Game game;

        

        public uxBlackJack()
        {
            InitializeComponent();
            game = new Game();
            uxWallet.Text = Convert.ToString(game.Player.Wallet);
        }

        private void uxHit_Click(object sender, EventArgs e)
        {
            game.DealPlayerCard();
            UpdateHands();
            if(game.GetScore(game.Player.Hand) > 21)
            {
                MessageBox.Show("You busted");
            }
            
        }

        private void uxStand_Click(object sender, EventArgs e)
        {
            uxHit.Enabled = false;
            uxStand.Enabled = false;
            uxHit.Visible = false;
            uxStand.Visible = false;
            uxStartHand.Enabled = true;
            uxStartHand.Visible = true;
        }

        private void uxSaveGame_Click(object sender, EventArgs e)
        {
            
        }

        private void uxExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uxLoadGame_Click(object sender, EventArgs e)
        {

        }

        private void uxStartHand_Click(object sender, EventArgs e)
        {
            
            game.DealDealerCard(false);
            game.DealPlayerCard();
            game.DealDealerCard(true);
            game.DealPlayerCard();
            uxStartHand.Visible = false;
            uxStartHand.Enabled = false;
            uxHit.Enabled = true;
            uxStand.Enabled = true;
            uxHit.Visible = true;
            uxStand.Visible = true;
            UpdateHands();
        }
        private void UpdateHands()
        {
            Stack<string> playerHand = game.GetHandString(game.Player.Hand);
            Stack<string> dealerHand = game.GetHandString(game.Dealer.Hand);

            uxDCard6.Text = playerHand.Pop();
            uxPCard5.Text = playerHand.Pop();
            uxPCard4.Text = playerHand.Pop();
            uxPCard3.Text = playerHand.Pop();
            uxPCard2.Text = playerHand.Pop();
            uxPCard1.Text = playerHand.Pop();

            uxDCard6.Text = dealerHand.Pop();
            uxDCard5.Text = dealerHand.Pop();
            uxDCard4.Text = dealerHand.Pop();
            uxDCard3.Text = dealerHand.Pop();
            uxDCard2.Text = dealerHand.Pop();
            uxDCard1.Text = dealerHand.Pop();

            uxPPoints.Text = Convert.ToString(game.GetScore(game.Player.Hand));
            uxDPoints.Text = Convert.ToString(game.GetScore(game.Dealer.Hand));
        }

        
    }
}
