using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GameFrameworkASC.Models.Interfaces;

namespace GameFrameworkASC.Models
{
    public class Weapon : IGameObject
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public bool Destructable { get; set; } = false;
        public Vector2 Position { get; set; }
        public bool Lootable { get; set; } = true;
        public int Id { get; set; }

        public Weapon()
        {
            
        }

        public Weapon(string name, int minDamage, int maxDamage, Vector2 position, int id)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Position = position;
            Id = id;
        }

        public int WeaponDamage()
        {
            Random random = new Random();
            int damage = random.Next(MinDamage, MaxDamage);
            return damage;
        }
    }
}
