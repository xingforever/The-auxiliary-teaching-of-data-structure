using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令
{
    public class PrimitiveCMDRotate:PrimitiveCMDEdit
    {
        static PrimitiveCMDRotate cMDRotate { get; set; }
        public static PrimitiveCMDRotate Single { get { return cMDRotate; } }
        public PrimitiveCMDRotate()
        {
            cMDRotate = new PrimitiveCMDRotate(); 
        }
    }
}
