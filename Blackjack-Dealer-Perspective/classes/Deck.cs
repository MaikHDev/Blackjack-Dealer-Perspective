﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    internal class Deck
    {
        public readonly List<Card> Cards = new List<Card>();

        public Deck()
        {
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                {
                    Card card = new Card(rank, suit);
                    Cards.Add(card);
                }
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach (Card card in Cards)
            {
                result += card.ToString();
                result += "\n";
            }

            return result;
        }
    }
}
