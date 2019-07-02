using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player
    {
        private readonly string rName;
        private string mNotGonnaStay;

        public Player(string rName, string mNotGonnaStay)
        {
            this.rName = rName;
            this.mNotGonnaStay = mNotGonnaStay;
        }
    }
}
