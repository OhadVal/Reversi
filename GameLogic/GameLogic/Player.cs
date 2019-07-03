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

        public string Name { get { return rName; }  }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   rName == player.rName;
        }

        public override int GetHashCode()
        {
            return 1970127302 + EqualityComparer<string>.Default.GetHashCode(rName);
        }

        public static bool operator ==(Player player1, Player player2)
        {
            return EqualityComparer<Player>.Default.Equals(player1, player2);
        }

        public static bool operator !=(Player player1, Player player2)
        {
            return !(player1 == player2);
        }
    }
}
