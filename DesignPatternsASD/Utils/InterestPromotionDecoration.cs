using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsASD.Utils
{
    abstract class InterestPromotionDecoration : InterestType
    {
        private InterestType itype;

        public InterestType getItype()
        {
            return itype;
        }

        public void setItype(InterestType itype)
        {
            this.itype = itype;
        }

        public InterestPromotionDecoration(InterestType pType)
        {
            this.itype = pType;
        }

        public abstract float getRateInterest();
    }
}
