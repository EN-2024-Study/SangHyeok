using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ManagerRepository  // singleton
    {
        private static ManagerRepository instance;
        private ManagerVo manager;

        private ManagerRepository()
        {
            this.manager = new ManagerVo("21013314", "1234");
        }

        public static ManagerRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new ManagerRepository();
                return instance;
            }
        }

        public ManagerVo GetManager()
        {
            return manager;
        }
    }
}
