using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public static class ClsBL_Settings
    {
        public static void SetConnectionString(string connectionString)
        {
            ClsDA_Settings.connectionString = connectionString;
        }
    }
}
