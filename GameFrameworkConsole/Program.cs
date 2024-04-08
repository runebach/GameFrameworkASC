// See https://aka.ms/new-console-template for more information
using GameFrameworkASC.FactoryPattern;
using GameFrameworkASC.Managers;
using GameFrameworkASC.Models;
using GameFrameworkASC.Models.Interfaces;
using GameFrameworkASC.TracingAndLogging;
using System.Numerics;


// WE SET UP OUR NECESSARY WORLD OBJECTS
GameWorldManager worldManager = new GameWorldManager();
CombatManager combatManager = new CombatManager();

// WE LOAD OUR WORLD FROM AN XML FILE. DEFAULT VÆRDIEN ER EN XML FIL.
Console.WriteLine("LOADING WORLD");
worldManager.LoadWorld();
Console.WriteLine();


// WE SET UP OUR FACTORY
HostileCreatureFactory enemyFactory =  new HostileCreatureFactory();


// WE ADD A FEW CREATURES TO OUR WORLD AND CHECK THEIR ID
// BEMÆRK. CREATURES ANVENDER TEMPLATE METHOD PATTERN
Console.WriteLine("USING FACTORIES TO CREATE CREATURES");
Creature firstMonster = enemyFactory.CreateCreature();
worldManager.AddCreature(firstMonster);
Console.WriteLine(firstMonster.Id);
Console.WriteLine();

Creature secondMonster = enemyFactory.CreateCreature();
worldManager.AddCreature(secondMonster);
Console.WriteLine(secondMonster.Id);
Console.WriteLine();

// WE TRY EQUIPPING CREATURES WITH WEAPONS
Console.WriteLine("EQUIPPING WEAPONS TO THE CREATURES");
firstMonster.Weapon = new Weapon("Sword", 10, 50, firstMonster.Position, 1);
Console.WriteLine($"{firstMonster.Name} has equipped the weapon {firstMonster.Weapon.Name}");
Console.WriteLine();

secondMonster.Weapon = new Weapon("Axe", 30, 40, secondMonster.Position, 2);
Console.WriteLine($"{secondMonster.Name} has equipped the weapon {secondMonster.Weapon.Name}");
Console.WriteLine();


// WE TRY EQUIPPING ONE CREATURE WITH ARMOR
Console.WriteLine("EQUIPPING ARMOR TO ONE CREATURE");
firstMonster.Armor = new Armor("Leather Armor", firstMonster.Position, 2, 3);


// WE TRY MAKING TWO CREATURES FIGHT
// BEMÆRK GAMELOGGER ER SINGLETON
Console.WriteLine("FORCING CREATURES INTO DEADLY ONE ON ONE COMBAT");
combatManager.DoCombat(firstMonster, secondMonster);
Console.WriteLine();


// WE CREATE A NEW CREATURE AND MOVE IT WHILE IN A HEALTHY STATE
Console.WriteLine("CReaTING NEW CREATURE AND MAKING IT MOVE");
Creature moveCreature = enemyFactory.CreateCreature();
worldManager.AddCreature(moveCreature);
Console.WriteLine(moveCreature.Position);
moveCreature.Move(new Vector2(0,10));
Console.WriteLine(moveCreature.Position);
Console.WriteLine();


// WE RESET THE POSITION, LOWER ITS HEALTH AND MOVE IT WHILE IN AN INJURED STATE. WE ALSO TRY TO PRINT THE STATE
// STATE MACHINE
Console.WriteLine("RESETTING POSITION AND MOVING IT BEFORE AND AFTER BRUTALLY HURTING IT");
moveCreature.Position = new Vector2(0, 0);
Console.WriteLine(moveCreature.State.GetType());
Console.WriteLine(moveCreature.Position);


moveCreature.ReceiveDamage(300);
Console.WriteLine(moveCreature.State.GetType());
moveCreature.Move(new Vector2(0, 10));
Console.WriteLine(moveCreature.Position);
Console.WriteLine();

// WE PRINT ALL THE CREATURES IN THE GAMEWORLD, DEAD AND ALIVE
Console.WriteLine("FORCING ALL CREATURES TO ANNOUNCE THEIR NAME");
foreach (Creature c in worldManager.Creatures)
{
    Console.WriteLine(c.Name);
}
Console.WriteLine();

// WE TRY REMOVING ALL THE DEAD CREATURES (CURRENTHP BELOW OR EQUAL TO 0)
Console.WriteLine("GETTING RID OF THE DISGUSTING FETID BODIES OF THE DEAD CREATURES. HERE IS WHAT'S LEFT.");
worldManager.RemoveDeadCreatures();
foreach (Creature c in worldManager.Creatures)
{
    Console.WriteLine(c.Name);
}
Console.WriteLine();


// SINCE WE HAVENT ADDED ANY GAMEOBJECT TO THE WORLD, WE WILL BEGIN BY ADDING A COUPLE OF WEAPONS AND ARMOR
// LINQ OG ITERATIONER
Console.WriteLine("CREATING AND ANNOUNCING GLORIOUS LOOT THAT THE FETID CREATURES WILL NEVER OBTAIN");
worldManager.AddGameObject(new Weapon("Frostmourne", 100, 300, new Vector2(0,0), 1));
worldManager.AddGameObject(new Weapon("Cool Axe", 5, 140, new Vector2(0, 0), 2));
worldManager.AddGameObject(new Weapon("Quel'Dalar", 50, 200, new Vector2(0, 0), 3));

worldManager.AddGameObject(new Armor("Chainmail", new Vector2(0,0), 4, 4));
worldManager.AddGameObject(new Armor("Plate mail", new Vector2(0, 0), 7, 5));

Console.WriteLine();

List<IGameObject> equipment = worldManager.FindAllEquipment();
foreach(IGameObject equ in equipment)
{
    Console.WriteLine($"{equ.Name}. {equ.GetType()}");
}
Console.WriteLine();





// FOR SOLID, SE FØLGENDE
// S -  SINGLE RESPONSIBILITY: SE COMBATMANAGER
// O - OPEN/CLOSED: SE STATE DESIGN PATTERN
// L - LISKOVS SUBSTITUTION: SE ABSTRACT CREATURE VS CREATURE
// I - INTERFACE SEGREGATION: IKKE IMPLEMENTERET. UMIDDELBART IKKE BEHOV FOR AT INDDELE INTERFACES OP YDERLIGERE.
// D - DEPENDANCY INJECTION: SE CREATURE. BÅDE CONSTRUCTION OG PROPERTY INJECTION
