using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    internal class Shoe
    {
        public readonly List<Card> shoe = new List<Card>();

        public Shoe()
        {
            for (int i = 0; i < 6; i++)
            {
                shoe.AddRange(new Deck().Cards);
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach (Card card in shoe)
            {
                result += card.ToString();
                result += "\n";
            }
            int count = shoe.Count();
            result += "Amount of cards in shoe: " + count.ToString();

            return result;
        }
    }
}
