using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public struct Square
    {
        private Player mOwner;

        #region Constructors
        public Square(Player iOwner) : this()
        {
            this.mOwner = iOwner;
        }

        #endregion

        public Player Owner
        {
            get
            {
                return mOwner;
            }

            set
            {
                mOwner = value;
            }
        }

        public bool IsEmpty()
        {
            return mOwner == null;
        }
    }
}
