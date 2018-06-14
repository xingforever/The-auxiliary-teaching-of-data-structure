using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    [Flags]
    public enum SnapType
    {
        NULL=1,
        EndPoint=1<<1,
        MidPoint=1<<2,
        CenterPoint=1<<3

    }
}
