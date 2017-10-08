using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsASD.Observer
{
    class ChangedSender
    {
        public String changedAttribute;
        public String oldValue;
        public String newValue;

        public ChangedSender(String pChangedAttribute, String pOldValue, String pNewValue)
        {
            this.changedAttribute = pChangedAttribute;
            this.oldValue = pOldValue;
            this.newValue = pNewValue;
        }
    }
}
