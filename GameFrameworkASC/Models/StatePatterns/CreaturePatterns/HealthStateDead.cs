using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models.StatePatterns.CreaturePatterns
{
    public class HealthStateDead : AbstractHealthState
    {
        public override int upperHealth { get; set; }
        public override int lowerHealth { get; set; }
        public override double moveModifier { get; set; } = 0;

        public override void HandleStateChange(Creature creature)
        {
            
        }


    }
}
