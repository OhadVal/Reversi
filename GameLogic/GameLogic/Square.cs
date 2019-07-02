using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Square
    {
        private Player mOwner;

        #region Constructors
        public Square(Player iOwner)
        {
            this.mOwner = iOwner;
        }

        public Square()
        {
            this.mOwner = null;
        }
        #endregion

        public Player Owner { get; set; }

        public bool IsEmpty()
        {
            return mOwner == null;
        }
    }
}
