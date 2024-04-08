using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GameFrameworkASC.Models.Interfaces;

namespace GameFrameworkASC.Models
{
    public class Armor : IGameObject
    {
        public string Name { get; set; }
        public bool Destructable { get; set; } = false;
        public Vector2 Position { get; set; }
        public bool Lootable { get; set; } = true;
        public int DamageReduction { get; set; }
        public int Id { get; set; }

        public Armor()
        {
            
        }

        public Armor(string name, Vector2 position, int damageReduction, int id)
        {
            Name = name;
            Position = position;
            DamageReduction = damageReduction;
            Id = id;
        }
    }
}
