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
    public class Creature : AbstractCreature
    {
        public Creature()
        {
            State = new HealthStateHealthy();
        }

        public Creature(string name, int maxHitPoints, Vector2 position, int movementSpeed, bool friendly, int id)
        {
            Name = name;
            MaxHitPoints = maxHitPoints;
            Position = position;
            CurrentHitPoints = MaxHitPoints;
            MovementSpeed = movementSpeed;
            State = new HealthStateHealthy();
            Friendly = friendly;
            Id = id;

        }

        public override int  DealDamage()
        {
            int damage;
            if(State.GetType() == typeof(HealthStateDead))
            {
                return 0;
            }
            else if (Weapon != null)
            {

                damage = Weapon.WeaponDamage();
            }
            else
            {
                Random random = new Random();
                damage = random.Next(1, 2);
            }
            return damage;
        }

        public override int ReceiveDamage(int damage)
        {
            if (Armor != null)
            {
                damage -= Armor.DamageReduction;
            }
            
            if (damage < 0)
            {
                damage = 0;
            }
            CurrentHitPoints -= damage;
            State.HandleStateChange(this);
            return damage;
        }

        public override void Loot(IGameObject loot)
        {
            if(loot.GetType() == typeof(Weapon))
            {
                Weapon = (Weapon)loot;
            }
            if(loot.GetType() == typeof(Armor))
            {
                Armor = (Armor)loot;
            }
        }

        public override void Defeated()
        {
            MovementSpeed = 0;
        }
        public override void Move(Vector2 vector)
        {
            Position = Position + Vector2.Multiply(vector, (float)State.moveModifier);
        }
    }
}
