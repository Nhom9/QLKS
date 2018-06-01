using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    public class SDDVDAO
    {
        private static SDDVDAO instance;


        internal static SDDVDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SDDVDAO();
                return SDDVDAO.instance;
            }
            private set { SDDVDAO.instance = value; }
        }


        private SDDVDAO() { }
    }
}
