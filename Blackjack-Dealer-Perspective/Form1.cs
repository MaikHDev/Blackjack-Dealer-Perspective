using Blackjack_Dealer_Perspective.classes;

namespace Blackjack_Dealer_Perspective
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
            Card card = new Card(Ranks.FOUR, Suits.SPADES);
            Card card1 = new Card(Ranks.FIVE, Suits.SPADES);

            card.PictureBox.Location = new Point(269, 88);
            card.PictureBox.Name = "pictureBox1";
            card.PictureBox.Size = new Size(126, 163);
            card.PictureBox.TabIndex = 0;
            card.PictureBox.TabStop = false;
            card.PictureBox.SizeMode = PictureBoxSizeMode.Zoom;


            card1.PictureBox.Location = new Point(500, 88);
            card1.PictureBox.Name = "pictureBox1";
            card1.PictureBox.Size = new Size(126, 163);
            card1.PictureBox.TabIndex = 0;
            card1.PictureBox.TabStop = false;
            card1.PictureBox.SizeMode = PictureBoxSizeMode.Zoom;


            this.Controls.Add(card.PictureBox);
            this.Controls.Add(card1.PictureBox);


        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }
    }
}
