using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsASD.DataAccess.FactoryOfConnection
{
    class FactoryMockDAO : DAOFactory
    {
        public AccountDAO createDAO()
        {
            return new MockAccountDAOImpl();
        }
    }
}
