using GameFrameworkASC.TracingAndLogging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models.StatePatterns.CreaturePatterns
{
    public abstract class AbstractHealthState
    {
        
        /// <summary>
        /// The upper boundary for health in the state
        /// </summary>
        public abstract int upperHealth { get; set; }
        /// <summary>
        /// The lower boundary for health in the state
        /// </summary>
        public abstract int lowerHealth { get; set; }
        /// <summary>
        /// a number that modifies the movement of a creature
        /// </summary>
        public abstract double moveModifier { get; set; }
        /// <summary>
        /// The method that handles the state change of a creature. Updates the state based on requirements
        /// </summary>
        /// <param name="creature">the creature which state needs to be updated</param>
        public abstract void HandleStateChange(Creature creature);

    }
}
