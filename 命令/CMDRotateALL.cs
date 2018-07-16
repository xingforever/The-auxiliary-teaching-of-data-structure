using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
    public class CMDRotateALL:PictureCMDBase 
    {
        static CMDRotateALL cMDRotateALL { get; set; }
        public static CMDRotateALL Single { get { return cMDRotateALL; } }
       
        public CMDRotateALL()
        {
            cMDRotateALL = new CMDRotateALL();
        }
      
       

    }
}
