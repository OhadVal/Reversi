namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///  This class represents a player in the game.
    /// </summary>
    public class Player
    {
        private readonly string rName;
                
        public Player(string iName)
        {
            this.rName = iName;
        }

        public string Name { get; set; }
    }
}
