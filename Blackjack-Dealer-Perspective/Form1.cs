using Blackjack_Dealer_Perspective.classes;

namespace Blackjack_Dealer_Perspective
{
    public enum GameFlow {
        intialize,

    }
    public partial class Form1 : Form
    {
        Shoe shoe = new Shoe();
        Dealer dealer = Dealer.GetInstance("klaas");
        List<Player> players;

        public Form1()
        {
            InitializeComponent();
            dealer.ShuffleShoe(shoe);
            dealer.Hand.Cards.Add(dealer.DrawCard(shoe, classes.Orientation.DOWN));
            dealer.Hand.Cards.Add(dealer.DrawCard(shoe, classes.Orientation.UP));

            players = new List<Player>();
            players.Add(new Player("bob"));

            int x = 250;

            foreach (var card in dealer.Hand.Cards)
            {
                card.PictureBox.Location = new Point(x, 500);
                card.PictureBox.Size = new Size(60, 100);
                card.PictureBox.TabIndex = 0;
                card.PictureBox.TabStop = false;
                card.PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                x += card.PictureBox.Width;
                this.Controls.Add(card.PictureBox);
            }

            CalculateDealerHand();
        }

        private void CalculateDealerHand()
        {
            if (dealer.Hand.GetHandValue() == null)
            {
                dealersCardValue.Text = "Unknown";
            }
            else
            {
                dealersCardValue.Text = dealer.Hand.GetHandValue().ToString();
            }
        }

        private void flipcard_Click(object sender, EventArgs e)
        {
            switch (dealer.Hand.Cards[0].Orientation)
            {
                case classes.Orientation.UP:
                    dealer.Hand.Cards[0].Orientation = classes.Orientation.DOWN;
                    break;
                case classes.Orientation.DOWN:
                    dealer.Hand.Cards[0].Orientation = classes.Orientation.UP;
                    break;
            }

            CalculateDealerHand();
        }
    }
}
