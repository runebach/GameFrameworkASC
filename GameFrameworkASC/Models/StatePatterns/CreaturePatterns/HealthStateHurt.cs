using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models.StatePatterns.CreaturePatterns
{
    public class HealthStateHurt : AbstractHealthState
    {
        public override int upperHealth { get; set; } = 300;
        public override int lowerHealth { get; set; } = 0;
        public override double moveModifier { get; set; } = 0.5;
        public override void HandleStateChange(Creature creature)
        {
            if(creature.CurrentHitPoints > lowerHealth)
            {
                creature.State = new HealthStateHealthy();
            }
            else if(creature.CurrentHitPoints >= upperHealth)
            {
                creature.State = new HealthStateDead();
            }
        }



    }
}
