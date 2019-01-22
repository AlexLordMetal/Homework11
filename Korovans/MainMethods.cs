using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korovans
{
    class MainMethods
    {

        public void StartGame()
        {            
            var bandSquad = new Squad() { Money = 200, Fighters = new List<Fighter>() };
            while (bandSquad.Fighters.Count == 0)
            {
                Console.WriteLine("Hire at least one fighter");
                HireFighter(bandSquad);
            }
            MainMenu();
        }

        public void HireFighter(Squad bandSquad)
        {            
            using (var context = new FactionsDbContext())
            {
                Console.WriteLine("Choose faction:");
                foreach (var eachFaction in context.Factions)
                {
                    Console.WriteLine($"{eachFaction.Id}. {eachFaction.Name}");
                }
                Console.WriteLine("0 - To main menu");
                var factionId = ConsoleExt.ReadLineToInt(context.Factions.Count());
                var faction = context.Factions.Find(factionId);

                Console.WriteLine("Choose fighter:");
                foreach (var eachFighter in faction.Fighters)
                {
                    Console.WriteLine($"{eachFighter.Id}. {eachFighter.FullDescription()}");
                }
                Console.WriteLine("0 - To main menu");
                var fighterId = ConsoleExt.ReadLineToInt(faction.Fighters.Count());
                var fighter = faction.Fighters[fighterId-1];

                if (fighter.Price <= bandSquad.Money)
                {
                    bandSquad.Fighters.Add(fighter);
                    bandSquad.Money -= fighter.Price;
                    Console.WriteLine($"You hired {fighter.Name}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"You don't have enough money to hire {fighter.Name}");
                    Console.ReadLine();
                }
            }
        }

    }
}