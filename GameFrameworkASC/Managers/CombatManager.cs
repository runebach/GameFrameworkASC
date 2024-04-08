using GameFrameworkASC.Models;
using GameFrameworkASC.TracingAndLogging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Managers
{
    public class CombatManager
    {
        // Single responsibility
        public CombatManager()
        {
            
        }
        /// <summary>
        /// A method that makes two creatures battle it out.
        /// </summary>
        /// <param name="firstCreature">This is the creature that will attack first.</param>
        /// <param name="secondCreature">This is the creature that will attack second</param>
        public void DoCombat(AbstractCreature firstCreature, AbstractCreature secondCreature)
        {
            while(firstCreature.CurrentHitPoints > 0 && secondCreature.CurrentHitPoints > 0)
            {
                int firstDamage = secondCreature.ReceiveDamage(firstCreature.DealDamage());
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"{firstCreature.Name} has dealt {firstDamage} to {secondCreature.Name}. It has {secondCreature.CurrentHitPoints} left.");

                int secondDamage = firstCreature.ReceiveDamage(secondCreature.DealDamage());
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"{secondCreature.Name} has dealt {secondDamage} to {firstCreature.Name}. It has {firstCreature.CurrentHitPoints} left.");
                
            }
            AbstractCreature victor;
            if (firstCreature.CurrentHitPoints > 0)
            {
                victor = firstCreature;
            }
            else
            {
                victor = secondCreature;
            }
            GameLogger.TraceEvent(TraceEventType.Information, 1, $"{victor.Name} has won this battle");
        }
    }
}
