using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsASD.Utils
{
    class Promotion1 : InterestPromotionDecoration
    {
        private readonly float rate = 1;

        public Promotion1(InterestType pType) : base(pType)
        {

        }
        public override float getRateInterest()
        {
            return rate + this.getItype().getRateInterest();
        }
    }
}
