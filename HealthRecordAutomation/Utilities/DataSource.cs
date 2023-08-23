using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.HealthRecordAutomation.Utilities
{
    public class DataSource
    {
        public static object[] ValidLoginData()
        {
            object[] data1 = new object[4];
            data1[0] = "admin";
            data1[1] = "pass";
            data1[2] = "English (Indian)";
            data1[3] = "OpenEMR";

            object[] data2 = new object[4];
            data2[0] = "admin";
            data2[1] = "pass";
            data2[2] = "English (Indian)";
            data2[3] = "OpenEMR";

            object[] allData = new object[2];
            allData[0] = data1;
            allData[1] = data2;

            return allData;
        }

    }
}
