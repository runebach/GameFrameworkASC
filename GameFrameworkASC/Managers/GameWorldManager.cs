using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameworkASC.Config;
using GameFrameworkASC.Models;
using GameFrameworkASC.Models.Interfaces;
using GameFrameworkASC.TracingAndLogging;

namespace GameFrameworkASC.Managers
{
    public class GameWorldManager
    {
        /// <summary>
        /// GameWorld object. Is initialized through LoadWorld method
        /// </summary>
        private GameWorld _world;
        /// <summary>
        /// List of all gameobjects in world
        /// </summary>
        public List<IGameObject> GameObjects { get; private set; }
        /// <summary>
        /// List of all creatures in world
        /// </summary>
        public List<Creature> Creatures { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameWorldManager()
        {
            GameObjects = new List<IGameObject>();
            Creatures = new List<Creature>();
        }

        /// <summary>
        /// Initializes the _world variable through an xml file. A default xml file is assigned.
        /// </summary>
        /// <param name="filepath">Defaults to a local file in the solution. Can be assigned.</param>

        public void LoadWorld(string filepath = "C:\\Users\\rubah\\Desktop\\Programmering\\Advanced Software\\GameFrameworkASC\\GameFrameworkASC\\Config\\ConfigFile.xml.txt")
        {
            _world = XmlConfig.ConfigWorld(filepath);
            GameLogger.TraceEvent(TraceEventType.Information, 1, $"Loading world from filepath: {filepath}. World size: {_world.XWidth} by {_world.YHeight}");
        }
        /// <summary>
        /// Method that adds a creature to the list of creatures in the world
        /// </summary>
        /// <param name="creature">The creature to be added</param>
        public void AddCreature(Creature creature)
        {
            if(creature != null)
            {
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"Adding creature {creature.Name} to world");
                Creatures.Add(creature);
            }
        }

        /// <summary>
        /// Method that removes a creature by its Id from the world.
        /// </summary>
        /// <param name="id">Id of the creature that should be removed.</param>
        public void RemoveCreature(int id)
        {

            Creature c = Creatures.Find(x => x.Id == id);
            if(c != null)
            {
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"Removing creature {c.Name} from world");
                Creatures.Remove(c);
            }
        }
        public Creature FindCreature(int id)
        {
            Creature c = Creatures.Find(x => x.Id == id);
            if(c != null)
            {
                return c;
            }
            return null;
        }
        /// <summary>
        /// Method tht removes all creatures which have their HP reduced to less than or equal to 0.
        /// </summary>
        public void RemoveDeadCreatures()
        {

            foreach (Creature creature in Creatures.ToList())
            {
                if(creature.CurrentHitPoints <= 0)
                {
                    Creatures.Remove(creature);
                }
            }
        }
        /// <summary>
        /// Method that adds a gameobject to the world. 
        /// </summary>
        /// <param name="obj">the object that needs to be added</param>
        public void AddGameObject(IGameObject obj)
        {
            if(obj != null)
            {
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"Adding gameobject {obj.Name} to world");
                GameObjects.Add(obj);
            }
            
        }

        /// <summary>
        /// Method that removes a gameobject from the world
        /// </summary>
        /// <param name="id">Id of the gameobject that needs to be removed.</param>
        public void RemoveGameObject(int id)
        {
            IGameObject obj = GameObjects.Find(x => x.Id == id);
            if(obj != null)
            {
                GameLogger.TraceEvent(TraceEventType.Information, 1, $"Removing gameobject {obj.Name} from world");
                GameObjects.Remove(obj);
            }

        }

        /// <summary>
        /// Method to find a gameobject by id
        /// </summary>
        /// <param name="id">id of the object you want to find</param>
        /// <returns> returns the found object</returns>
        public IGameObject FindGameObject(int id)
        {
            IGameObject obj = GameObjects.Find(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        /// <summary>
        /// Method to find all GameObjects that are of the type "Weapon" or "Armor".
        /// </summary>
        /// <returns>Returns all gameobjects from the list, that are of the type "Weapon" or "Armor"</returns>
        public List<IGameObject> FindAllEquipment()
        {
            IEnumerable<IGameObject> tempList =
                from obj in GameObjects
                where obj.GetType() == typeof(Weapon) || obj.GetType() == typeof(Armor)
                select obj;
            return tempList.ToList();
        }
    }
}
