using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    internal class Hand
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        private Nullable<int> bet = null;

        // Imagebox list --
        public List<PictureBox> HandImgBox = new List<PictureBox>();

        public int? Bet {
            get { return bet.GetValueOrDefault(); }
            set {
                if (!bet.HasValue)
                {
                    bet = value;
                }
            }
        }

        public bool DoubledDown { get; private set; } = false;

        private bool stood = false;
        public bool HasStood {
            get { return stood; }
            set {
                if (true == stood)
                {
                    return;
                }
                stood = value;
            }
        }

        public int? GetHandValue() {
            if (Cards == null || !Cards.Any())
            {
                return null;
            }

            int handTotalValue = 0;
            int aceCount = 0;

            foreach (var card in Cards)
            {
                var cardValue = card.GetValue();
                if (cardValue == null)
                {
                    continue;
                }

                handTotalValue += (int)cardValue;

                if (card.Rank == Ranks.ACE)
                {
                    aceCount++;
                }
            }

            while (handTotalValue > 21 && aceCount > 0)
            {
                handTotalValue -= 10;
                aceCount--;
            }

            return handTotalValue > 0 ? handTotalValue : null;
        }


        public void StandHand() {
            HasStood = true;
        }

        public bool DoubleDown() {
            if (true == DoubledDown)
            {
                Console.WriteLine("Already doubled the bet of this hand, it is not possible to double again!");
                return false;
            }

            this.bet = this.bet * 2;
            DoubledDown = true;
            HasStood = true;
            return true;
        }
        public bool Split() {
            if (Cards.Count == 2 && Cards[0].GetValue() == Cards[1].GetValue())
            {
                return true;
            }

            Console.WriteLine("Not possible to split this hand!");
            return false;
        }

        public void AddCardToHand(Card card) {
            Cards.Add(card);
        }
    }
}
