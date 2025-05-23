﻿using System;
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

        public List<PictureBox> HandPictureBoxList { get; private set; }

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

        public Hand() {
            HandPictureBoxList = new List<PictureBox>();
        }

        public void DrawHandBox(Point location, Size size) {
            int count = 0;
            int x = location.X;
            int y = location.Y;
            foreach (Card card in Cards)
            {
                if (count % 5 == 0)
                {
                    x = location.X;
                    x += (card.PictureBox.Width / 100) * 90;
                }
                else
                {

                }

                card.PictureBox.Size = size;
                card.PictureBox.TabIndex = 0;
                card.PictureBox.TabStop = false;
                card.PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                count++;
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
    }
}
