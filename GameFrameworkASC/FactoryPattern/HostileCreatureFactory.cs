using GameFrameworkASC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GameFrameworkASC.FactoryPattern
{
    public class HostileCreatureFactory : AbstractCreatureFactory
    {
        private static int id = 1;
        public override Creature CreateCreature()
        {
            Creature creature = RandomCreature();
            
            return creature;
        }

        public Creature RandomCreature()
        {
            Random random = new Random();
            
            string[] names = ["Goblin", "Dragon", "Orc", "Bandit", "Gargoyle"];
            Creature creature = new Creature(names[random.Next(names.Length)], 500, new Vector2(0,0), 1, false, id++);
            return creature;

            
        }
    }
}
