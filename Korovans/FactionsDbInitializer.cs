using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Korovans
{
    public class FactionsDbInitializer : DropCreateDatabaseIfModelChanges<FactionsDbContext>
    {
        protected override void Seed(FactionsDbContext context)
        {
            var random = new Random();
            context.Factions.Add(OrcsCreator(random));
            context.Factions.Add(ElvesCreator(random));
            base.Seed(context);
        }

        private Faction ElvesCreator(Random random, string fileName = "ElfNames.txt")
        {
            var elves = new Faction() { Name = "Elves", Fighters = new List<Fighter>() };
            var names = ReadFromFile(fileName);
            foreach (var name in names)
            {
                var elf = new Fighter()
                {
                    Name = name,
                    Hp = 50 + random.Next(1, 30),
                    Atk = 10 + random.Next(1, 6),
                    Str = 1 + random.Next(4),
                    Class = FighterClass.Normal
                };
                elf.Price = elf.Hp + (int)(elf.Atk * 1.5) + elf.Str * 2;
                ClassRandomizer(elf, "Elves", random);
                elves.Fighters.Add(elf);
            }
            return elves;
        }

        private Faction OrcsCreator(Random random, string fileName = "OrcNames.txt")
        {
            var orcs = new Faction() { Name = "Orcs", Fighters = new List<Fighter>() };
            var names = ReadFromFile(fileName);
            foreach (var name in names)
            {
                var orc = new Fighter()
                {
                    Name = name,
                    Hp = 65 + random.Next(1, 30),
                    Atk = 6 + random.Next(1, 6),
                    Str = 3 + random.Next(4),
                    Class = FighterClass.Normal
                };
                orc.Price = orc.Hp + (int)(orc.Atk * 1.5) + orc.Str * 2;
                ClassRandomizer(orc, "Orcs", random);
                orcs.Fighters.Add(orc);
            }
            return orcs;
        }

        private void ClassRandomizer(Fighter fighter, string factionName, Random random)
        {
            var rnd = random.Next(10);
            if (factionName.ToLower() == "elves")
            {
                if (rnd < 2)
                {
                    AddWarriorAbility(fighter);
                }
                else if (rnd < 4)
                {
                    AddMageAbility(fighter);
                }
                else if (rnd < 6)
                {
                    AddPriestAbility(fighter);
                }
            }

            if (factionName.ToLower() == "orcs")
            {
                if (rnd < 2)
                {
                    AddWarriorAbility(fighter);
                }
                else if (rnd < 4)
                {
                    AddBerserkAbility(fighter);
                }
            }
        }

        private void AddBerserkAbility(Fighter fighter)
        {
            fighter.Class = FighterClass.Berserk;
            fighter.BetweenAbility = 4;
            fighter.AbilityRecoveryCounter = fighter.BetweenAbility;
            fighter.Price = (int)(fighter.Price * 1.4);
        }

        private void AddPriestAbility(Fighter fighter)
        {
            fighter.Class = FighterClass.Priest;
            fighter.BetweenAbility = 4;
            fighter.AbilityRecoveryCounter = fighter.BetweenAbility;
            fighter.Price = (int)(fighter.Price * 1.4);
        }

        private void AddMageAbility(Fighter fighter)
        {
            fighter.Class = FighterClass.Mage;
            fighter.BetweenAbility = 4;
            fighter.AbilityRecoveryCounter = fighter.BetweenAbility;
            fighter.Price = (int)(fighter.Price * 1.4);
        }

        private void AddWarriorAbility(Fighter fighter)
        {
            fighter.Class = FighterClass.Warrior;
            fighter.BetweenAbility = -1;
            fighter.AbilityRecoveryCounter = fighter.BetweenAbility;
            fighter.Price = (int)(fighter.Price * 1.3);
        }

        private List<string> ReadFromFile(string fileName)
        {
            var names = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    names.Add(reader.ReadLine());
                }
            }
            return names;
        }

    }
}
