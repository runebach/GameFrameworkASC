using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkASC.Models.Interfaces
{
    public interface IGameObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool Destructable { get; set; }
        public Vector2 Position { get; set; }
        public bool Lootable { get; set; }





    }
}
