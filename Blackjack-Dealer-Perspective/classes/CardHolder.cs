﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer_Perspective.classes
{
    abstract class CardHolder
    {
        public readonly string Name;

        public CardHolder(string name) {
            this.Name = name;
        }
    }
}
