using GameFrameworkASC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.FactoryPattern
{
    public abstract class AbstractCreatureFactory
    {
        
        public AbstractCreatureFactory()
        {
            
        }
        /// <summary>
        /// Factory method that creates a creature
        /// </summary>
        /// <returns>Returns the created creature.</returns>
        public abstract Creature CreateCreature();
    }
}
