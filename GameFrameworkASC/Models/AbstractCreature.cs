using GameFrameworkASC.Models.Interfaces;
using GameFrameworkASC.Models.StatePatterns.CreaturePatterns;
using GameFrameworkASC.TracingAndLogging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models
{
    public abstract class AbstractCreature
    {
        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Max amount of hitpoints
        /// </summary>
        public int MaxHitPoints { get; set; }
        /// <summary>
        /// Current amount of hitpoints
        /// </summary>
        public int CurrentHitPoints { get; set; }
        /// <summary>
        /// Movementspeed of creature
        /// </summary>
        public int MovementSpeed { get; set; }
        /// <summary>
        /// Whether or not a creature is friendly
        /// </summary>
        public bool Friendly { get; set; }
        /// <summary>
        /// The position of the creature
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        /// Weapon equipped by the creature
        /// </summary>
        public Weapon Weapon { get; set; }
        /// <summary>
        /// Armor equipped by the creature
        /// </summary>
        public Armor Armor { get; set; }
        /// <summary>
        /// Id of creature
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The current health state of the creature
        /// </summary>
        public AbstractHealthState State { get; set; } 
        
        

        /// <summary>
        /// A method that returns an amount of damage. This can depend on a weapon equipped.
        /// </summary>
        /// <returns>Damage dealt by this creature</returns>
        public abstract int DealDamage(); 

        /// <summary>
        /// A method that allows the creature to receive damage
        /// </summary>
        /// <param name="damage">The damage that the creature will receive.</param>
        /// <returns>Damage received by this creature</returns>
        public abstract int ReceiveDamage(int damage);

        /// <summary>
        /// A loot method that allows the creature to loot and equip an object.
        /// </summary>
        /// <param name="loot">The IGameObject object that this creature will attempt to loot</param>
        public abstract void Loot(IGameObject loot);

        /// <summary>
        /// A method that will destroy the creature
        /// </summary>
        public abstract void Defeated();
        /// <summary>
        /// A method that will change the creatures vector position
        /// </summary>
        /// <param name="vector">the vector that the creature will add to its own position vector</param>
        public abstract void Move(Vector2 vector);
    }
}
