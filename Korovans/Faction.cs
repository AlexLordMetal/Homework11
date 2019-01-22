using System.Collections.Generic;

namespace Korovans
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Fighter> Fighters { get; set; }
    }
}