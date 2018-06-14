using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 平面上的一个点
    /// </summary>
    public class Point2d : IComparable<Point2d>, IEquatable<Point2d>
    {
        /// <summary>
        /// 数值的计算精度
        /// </summary>
        public static double Error = 1.0e-10;
        /// <summary>
        /// 点位的计算精度，XY坐标小于此值就认为是相同的点！
        /// </summary>
        public static double SamePointError = 0.00001;
        /// <summary>
        /// 点的X坐标值
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 点的Y坐标值
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// 采用指定参数创建一个点对象
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point2d() : this(0, 0) { }
        /// <summary>
        /// 拷贝构造函数
        /// </summary>
        /// <param name="p">源对象</param>
        public Point2d(Point2d p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }
        /// <summary>
        /// 坐标原点
        /// </summary>
        public static Point2d Zero
        {
            get { return new Point2d(0, 0); }
        }
        /// <summary>
        /// 比较本点与另一个点的大小
        /// </summary>
        /// <param name="other">另一个点</param>
        /// <returns></returns>
        public int CompareTo(Point2d other)
        {
            var r = this.X.CompareTo(other.X);
            if (r == 0)
            {
                r = this.Y.CompareTo(other.Y);
            }
            return r;
        }
        /// <summary>
        /// 判断本点是否与另一个点相等
        /// </summary>
        /// <param name="other">另一个点</param>
        /// <returns></returns>
        public bool Equals(Point2d other)
        {
            return Equals(other.X, other.Y);
        }
        public bool Equals(double x, double y)
        {
            if (Math.Abs(this.X - x) < SamePointError && Math.Abs(this.Y - y) < SamePointError)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 求从本点到另一个点的距离值
        /// </summary>
        /// <param name="p">另一个点</param>
        /// <returns>距离值</returns>
        public double Distance(Point2d p)
        {
            var dx = p.X - X;
            var dy = p.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public double Distance(double x, double y)
        {
            var dx = x - X;
            var dy = y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        
        
        /// <summary>
        /// 从本点到另一个点的中点
        /// </summary>
        /// <param name="p">另一个点</param>
        /// <returns></returns>
        public Point2d Midpoint2d(Point2d p)
        {
            return new Point2d((X + p.X) / 2.0, (Y + p.Y) / 2.0);
        }
        public override string ToString()
        {
            return X.ToString("F3") + "," + Y.ToString("F3");
        }
        public void Parse(string s)
        {
            var a = s.Split(',');
            X = double.Parse(a[0]);
            Y = double.Parse(a[1]);
        }
    }
}
