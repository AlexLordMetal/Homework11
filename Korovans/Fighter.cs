namespace Korovans
{
    public class Fighter
    {
        private int hp;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (value >= 0) hp = value;
                else hp = 0;
            }
        }
        public int Atk { get; set; }
        public int Str { get; set; }
        public int Price { get; set; }
        public FighterClass Class { get; set; }
        public int BetweenAbility { get; set; }
        public int AbilityRecoveryCounter { get; set; }

        public string FullDescription()
        {
            return $"{Name}, HP={Hp}, ATK={Atk}, STR={Str}, Class={Class.ToString()}\tHire cost = {Price}";
        }
    }
}