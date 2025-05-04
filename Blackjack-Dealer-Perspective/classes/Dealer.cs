using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Blackjack_Dealer_Perspective.classes
{
    internal class Dealer : CardHolder
    {
        private Dealer(string name) : base(name) {
            Hand = new Hand();
        }

        private static Dealer _instance;

        private static readonly object _lock = new object();

        private readonly Random _random = new Random();

        public Hand Hand { get; set; }

        public static Dealer GetInstance(string name) {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Dealer(name);
                    }
                }
            }
            return _instance;
        }

        public void ShuffleShoe(Shoe Shoe) {
            // Fisher Yate shuffling algorithm
            for (int currentIndex = 0; currentIndex < Shoe.shoe.Count; currentIndex++)
            {
                int swapIndex = currentIndex + _random.Next(Shoe.shoe.Count - currentIndex);
                (Shoe.shoe[swapIndex], Shoe.shoe[currentIndex]) = (Shoe.shoe[currentIndex], Shoe.shoe[swapIndex]);
            }
        }

        public void DealCard(Shoe shoe, Hand hand, Orientation orientation = Orientation.UP) {
            hand.Cards.Add(DrawCard(shoe, orientation));
        }

        public void ClearHands(List<Hand> allPlayerHands) {
            allPlayerHands.Clear();
        }
        public void ClearHand(List<Hand> hands, Hand hand) {
            hands.Remove(hand);
        }

        public Card DrawCard(Shoe shoe, Orientation orientation = Orientation.DOWN) {
            var card = shoe.shoe[0];
            shoe.shoe.RemoveAt(0);
            card.Orientation = orientation;
            return card;
        }

        public void SplitHand(Shoe shoe, List<Hand> hands, Hand hand) {
            if (hand.Bet == null)
            {
                return;
            }
            if (hand.Split())
            {

                int bet = (int)hand.Bet;
                int handIndex = hands.IndexOf(hand);
                if (handIndex == -1)
                {
                    return;
                }

                hands.Remove(hand);

                var newHands = new List<Hand>
                {
                    new Hand { Cards = { hand.Cards[0], DrawCard(shoe) }, Bet = bet },
                    new Hand { Cards = { hand.Cards[1], DrawCard(shoe) }, Bet = bet }
                };

                hands.InsertRange(handIndex, newHands);
            }
        }

        public bool IsBlackjack(Hand hand) {
            var cards = hand.Cards;

            if (cards.Count == 2 && hand.GetHandValue() == 21) // Has blackjack
            {
                return true;
            }

            return false;
        }

        public bool IsBust(Hand hand) {
            if (hand.GetHandValue() > 21)
            {
                return true;
            }

            return false;
        }

        public void PayoutPlayer(Player player, Hand hand) {
            var handValue = hand.GetHandValue();
            if (hand.Bet == null)
            {
                return;
            }
            if (handValue == null)
            {
                return;
            }
            if (hand.Cards.Count < 2)
            {
                return;
            }
            if (IsBlackjack(hand))
            {
                player.AddChips((int)(hand.Bet * 2.5));
                return;
            }
            if (Hand.GetHandValue() >= 17)
            {
                return;
            }
            if ((handValue > Hand.GetHandValue() || IsBust(Hand)) && !IsBust(hand))
            {
                player.AddChips((int)hand.Bet * 2);
                return;
            }
            if (handValue == Hand.GetHandValue())
            {
                player.AddChips((int)hand.Bet);
            }
        }
    }
}
