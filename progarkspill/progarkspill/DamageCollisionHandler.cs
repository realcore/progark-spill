﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace progarkspill.GameObjects
{
    public class DamageCollisionHandler : ICollisionHandler
    {
        public void collide(Entity me, Entity other)
        {
            int resistance;
            if (me.CombatStats.DamageType == 0)
                resistance = other.CombatStats.Armor;
            else
                resistance = other.CombatStats.Resistance;
            other.CombatStats.Health -= (int) (me.CombatStats.Damage * (1 - resistance / 100.0));
        }
    }
}
