using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    internal class Player : CardHolder
    {
        public List<Hand> Hands { get; private set; } = new List<Hand>();

        public int Chips { get; private set; } = 1000;

        public void AddChips(int chips) {
            Chips += chips;
        }

        public event EventHandler<HandEventHitHandler> HandHit;
        public event EventHandler<HandEventSplitHandler> HandSplit;
        public event EventHandler<HandEventSurrenderHandler> HandSurrender;

        public bool PlaceBet(int bet) {
            if (bet > Chips)
            {
                Console.WriteLine("Can't bet more chips than you currently have.");
                return false;
            }

            if (bet < HouseRules.GetInstance().MinBet) // add houserules!
            {
                Console.WriteLine("Can't bet zero or less chips.");
                return false;
            }

            if (bet % 10 != 0)
            {
                Console.WriteLine("Bets must be in increments of 10.");
                return false;
            }

            Chips -= bet;
            var hand = new Hand {
                Bet = bet
            };
            Hands.Add(hand);

            return true;
        }

        private void OnHandHit(Hand hand, HitAction action) {
            HandHit?.Invoke(this, new HandEventHitHandler(Name, hand, action));
        }
        public void Hit(Hand hand, HitAction action = HitAction.HIT) {
            OnHandHit(hand, action);
        }

        private void OnHandSplit(Hand hand) {
            HandSplit?.Invoke(this, new HandEventSplitHandler(Name, Hands, hand));
        }
        public void Split(Hand hand) {
            if(hand.Bet == null)
            {
                return;
            }

            if (hand.Split())
            {
                OnHandSplit(hand);
                Chips -= (int)hand.Bet;
            }
        }
        private void OnHandSurrender(Player player, List<Hand> hands, Hand hand) {
            HandSurrender?.Invoke(this, new HandEventSurrenderHandler(Name, player, hands, hand));
        }
        public void Surrender(Player player, List<Hand> hands, Hand hand) {
            OnHandSurrender(player, hands, hand);
        }

        public void Stand(Hand hand) {
            hand.StandHand();
        }

        public void DoubleDown(Hand hand) {
            if (hand.Bet == null)
            {
                return;
            }

            if (hand.DoubleDown())
            {
                Chips -= (int)hand.Bet;
                Hit(hand, HitAction.DOUBLE_DOWN);
            }
        }

        public Player(string name) : base(name) {
        }
    }

    enum HitAction {
        HIT,
        DOUBLE_DOWN,
    }
    internal class HandEventHitHandler : EventArgs
    {
        public HandEventHitHandler(string name, Hand hand, HitAction action) {
            this.Name = name;
            this.Hand = hand;
            this.Action = action;
        }

        public readonly Hand Hand;
        public readonly string Name;
        public readonly HitAction Action;
    }
    internal class HandEventSplitHandler : EventArgs
    {
        public HandEventSplitHandler(string name, List<Hand> hands, Hand hand) {
            this.Name = name;
            this.Hands = hands;
            this.Hand = hand;
        }
        public readonly Hand Hand;
        public readonly List<Hand> Hands;
        public readonly string Name;
    }
    internal class HandEventSurrenderHandler : EventArgs
    {
        public HandEventSurrenderHandler(string name, Player player, List<Hand> hands, Hand hand) {
            this.Player = player;
            this.Name = name;
            this.Hands = hands;
            this.Hand = hand;
        }
        public readonly Player Player;
        public readonly Hand Hand;
        public readonly List<Hand> Hands;
        public readonly string Name;
    }
}
