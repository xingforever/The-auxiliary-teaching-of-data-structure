using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 坐标方位角
    /// </summary>
    public struct Azimuth : IComparable<Azimuth>
    {
        //方位角
        double angle;
        /// <summary>
        /// 根据两个点的坐标，计算从1点到2点的方位角
        /// </summary>
        /// <param name="x1">1点的X坐标</param>
        /// <param name="y1">1点的Y坐标</param>
        /// <param name="x2">2点的X坐标</param>
        /// <param name="y2">2点的Y坐标</param>
        public Azimuth(double x1, double y1, double x2, double y2) : this(x2 - x1, y2 - y1) { }
        /// <summary>
        /// 计算点的坐标方位角
        /// </summary>
        /// <param name="x">点的X坐标</param>
        /// <param name="y">点的Y坐标</param>
        public Azimuth(double x, double y)
        {
            angle = Math.Atan2(y, x);
            if (angle < 0)
            {
                angle += 2.0 * Math.PI;
            }
        }
        /// <summary>
        /// 计算从1点到2点的方位角
        /// </summary>
        /// <param name="p1">1点</param>
        /// <param name="p2">2点</param>
        public Azimuth(Point2d p1, Point2d p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }
        /// <summary>
        /// 根据两个点的坐标，计算从1点到2点的方位角
        /// </summary>
        /// <param name="x1">1点的X坐标</param>
        /// <param name="y1">1点的Y坐标</param>
        /// <param name="x2">2点的X坐标</param>
        /// <param name="y2">2点的Y坐标</param>
        /// <returns></returns>
        public static Azimuth Create(double x1, double y1, double x2, double y2)
        {
            return new Azimuth(x1, y1, x2, y2);
        }
        /// <summary>
        /// 计算从1点到2点的方位角
        /// </summary>
        /// <param name="p1">1点</param>
        /// <param name="p2">2点</param>
        /// <returns></returns>
        public static Azimuth Create(Point2d p1, Point2d p2)
        {
            return new Azimuth(p1, p2);
        }
        /// <summary>
        /// 计算点的坐标方位角
        /// </summary>
        /// <param name="x">点的X坐标</param>
        /// <param name="y">点的Y坐标</param>
        /// <returns>坐标方位角</returns>
        public static Azimuth Create(double x, double y)
        {
            return new Azimuth(x, y);
        }

        /// <summary>
        /// 将方位角限制在0~2PI之间
        /// </summary>
        /// <param name="angle">方位角</param>
        /// <returns></returns>
        static double InTwoPI(double angle)
        {
            angle = angle % (2.0 * Math.PI);
            if (angle < 0)
            {
                angle += 2.0 * Math.PI;
            }
            return angle;
        }
        /// <summary>
        /// 求两个方位角只差
        /// </summary>
        /// <param name="endAngle">第一个方位角</param>
        /// <param name="startAngle">第二个方位角</param>
        /// <returns></returns>
        public static double operator -(Azimuth endAngle, Azimuth startAngle)
        {
            return InTwoPI(endAngle.angle - startAngle.angle);
        }
        /// <summary>
        /// 求方位角减去一个角度的方位角
        /// </summary>
        /// <param name="AzimuthAngle">方位角</param>
        /// <param name="angle">角度</param>
        /// <returns>方位角</returns>
        public static Azimuth operator -(Azimuth AzimuthAngle, double angle)
        {
            AzimuthAngle.angle = InTwoPI(AzimuthAngle.angle - angle);
            return AzimuthAngle;
        }
        /// <summary>
        /// 计算一个方位角加一个角度后的方位角
        /// </summary>
        /// <param name="Azimuth">方位角</param>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static Azimuth operator +(Azimuth Azimuth, double angle)
        {
            Azimuth.angle = InTwoPI(Azimuth.angle + angle);
            return Azimuth;
        }
        /// <summary>
        /// 计算一个方位角加一个角度后的方位角
        /// </summary>
        /// <param name="angle">角度</param>
        /// <param name="Azimuth">方位角</param>
        /// <returns></returns>
        public static Azimuth operator +(double angle, Azimuth Azimuth)
        {
            Azimuth.angle = InTwoPI(Azimuth.angle + angle);
            return Azimuth;
        }
        /// <summary>
        /// 将方位角转为double类型
        /// </summary>
        /// <param name="Azimuth"></param>
        public static implicit operator double(Azimuth Azimuth)
        {
            return Azimuth.angle;
        }
        /// <summary>
        /// 将double类型转为方位角
        /// </summary>
        /// <param name="angle"></param>
        public static explicit operator Azimuth(double angle)
        {
            Azimuth p;
            p.angle = InTwoPI(angle);
            return p;
        }
        /// <summary>
        /// 从以度为单位的角度构建方位角
        /// </summary>
        /// <param name="angle">以度为单位的角度</param>
        /// <returns></returns>
        public static Azimuth FromDegree(double angle)
        {
            Azimuth p;
            p.angle = InTwoPI(angle * Math.PI / 180.0);
            return p;
        }
        /// <summary>
        /// 将方位角转为以度为单位的角度
        /// </summary>
        /// <returns></returns>
        public double ToDegree()
        {
            var angle = this.angle * 180.0 / Math.PI;
            return angle;
        }

        public int CompareTo(Azimuth other)
        {
            return this.angle.CompareTo(other.angle);
        }
    }
}
