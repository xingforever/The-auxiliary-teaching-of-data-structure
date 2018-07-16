using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令
{
    public class CMDRotate:PrimitiveCMDEdit
    {
        static CMDRotate cMDRotate { get; set; }
        public static CMDRotate Single { get { return cMDRotate; } }
        public CMDRotate()
        {
            cMDRotate = new CMDRotate(); 
        }
    }
}
