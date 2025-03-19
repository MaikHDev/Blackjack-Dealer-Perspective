using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    enum Suits
    {
        CLUBS,
        SPADES,
        DIAMONDS,
        HEARTS
    }
    enum Ranks
    {
        TWO = 2,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE,
    }
    enum Orientation
    {
        UP,
        DOWN,
    }

    internal class Card
    {
        public Suits Suit { get; private set; }
        public Ranks Rank { get; private set; }
        private Orientation orientation = Orientation.DOWN;
        public Orientation Orientation 
        {
            get => orientation; 
            set
            {
                switch (value)
                {
                    case Orientation.UP:
                        orientation = Orientation.UP;
                        Img = Image.FromFile($"{imgDirectory}{ToLowerCase(Rank)}_of_{ToLowerCase(Suit)}.png");
                        break;
                    case Orientation.DOWN:
                        orientation = Orientation.DOWN;
                        Img = Image.FromFile(imgDirectory + "faced_down.png");
                        break;
                }
            }
        }
        public int Value { get; private set; }
        public Image Img { get; private set; }

        private string imgDirectory;

        public Card(Ranks rank, Suits suit)
        {
            this.Suit = suit;
            this.Rank = rank;

            imgDirectory = Directory.GetCurrentDirectory() + @"\playing-cards-images\";
            Img = Image.FromFile(imgDirectory + $"{ToLowerCase(rank)}_of_{ToLowerCase(suit)}.png");

            switch (rank)
            {
                case Ranks.JACK:
                case Ranks.QUEEN:
                case Ranks.KING:
                    this.Value = 10;
                    break;
                case Ranks.ACE:
                    this.Value = 11;
                    break;
                default:
                    this.Value = (int)rank;
                    break;
            }
        }


        public string ToLowerCase(Enum item)
        {
            return item.ToString().ToLower();
        }

        public string ToUpperCase(Enum item)
        {
            string upper = item.ToString();
            upper = char.ToUpper(upper[0]) + upper.Substring(1).ToLower();
            return upper;
        }

        public override string ToString()
        {
            return Orientation == Orientation.UP ? ToUpperCase(this.Rank) + " of " + ToUpperCase(this.Suit) : "Card is faced down!";
        }
    }
}
