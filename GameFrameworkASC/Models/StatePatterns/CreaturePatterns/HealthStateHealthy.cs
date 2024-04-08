using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models.StatePatterns.CreaturePatterns
{
    public class HealthStateHealthy : AbstractHealthState
    {


        public override int upperHealth { get; set; } = 500;
        public override int lowerHealth { get; set; } = 300;
        public override double moveModifier { get; set; } = 1;

        public override void HandleStateChange(Creature creature)
        {
            if(creature.CurrentHitPoints <= lowerHealth)
            {
                creature.State = new HealthStateHurt();
            }
            if(creature.CurrentHitPoints <= 0)
            {
                creature.State = new HealthStateDead();
            }

        }


    }
}
