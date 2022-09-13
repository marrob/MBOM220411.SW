using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MBOM220411.Data
{
    interface ITableOperations
    {
        void New(string name);
       // void Delete(string name);
        void CreateDefault();
    }

}
