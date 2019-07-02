namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private readonly string rName;

        public Player(string rName)
        {
            this.rName = rName;
        }

        public string Name { get; set; }
    }
}
