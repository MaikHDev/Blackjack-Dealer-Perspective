using Blackjack_Dealer_Perspective.classes;

namespace Blackjack_Dealer_Perspective
{
    public partial class Form1 : Form
    {
        Shoe shoe = new Shoe();
        Hand hand = new Hand();
        Dealer dealer = Dealer.GetInstance("klaas");

        public Form1()
        {
            InitializeComponent();
            dealer.ShuffleShoe(shoe);
            hand.Cards.Add(dealer.DrawCard(shoe, classes.Orientation.DOWN));
            hand.Cards.Add(dealer.DrawCard(shoe, classes.Orientation.UP));

            int x = 250;

            foreach (var card in hand.Cards)
            {
                card.PictureBox.Location = new Point(x, 100);
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
            int total = 0;

            foreach (var card in hand.Cards)
            {
                var cardValue = card.GetValue();

                if (cardValue != null)
                {
                    total += (int)cardValue;
                }
            }

            if (total > 0)
            {
                dealersCardValue.Text = total.ToString();
            }
            else
            {
                dealersCardValue.Text = "Unknown";
            }
        }

        private void flipcard_Click(object sender, EventArgs e)
        {
            switch (hand.Cards[0].Orientation)
            {
                case classes.Orientation.UP:
                    hand.Cards[0].Orientation = classes.Orientation.DOWN;
                    break;
                case classes.Orientation.DOWN:
                    hand.Cards[0].Orientation = classes.Orientation.UP;
                    break;
            }

            CalculateDealerHand();
        }
    }
}
