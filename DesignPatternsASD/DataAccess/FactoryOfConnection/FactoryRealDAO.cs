using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsASD.DataAccess.FactoryOfConnection
{
    class FactoryRealDAO : DAOFactory
    {
        public AccountDAO createDAO()
        {
            return new AccountDAOImpl();
        }
    }
}
