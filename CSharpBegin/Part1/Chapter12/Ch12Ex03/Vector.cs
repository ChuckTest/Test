using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03
{
    /// <summary>
    /// 表示带极坐标的矢量
    /// </summary>
    class Vector
    {
        /// <summary>
        /// 极径
        /// </summary>
        public double? R = null;
        /// <summary>
        /// 极角(单位：度)  逆时针方向为正
        /// </summary>
        public double? Theta = null;

        /// <summary>
        /// 弧度 弧长等于半径的弧，其所对的圆心角为1弧度
        /// 一周对应的弧度 2Πr/r=2Π  
        /// </summary>
        public double? ThetaRadians//弧度
        {
            get
            {
                //把角度转换为弧度   180°对应于Π
                return Theta / 180.0 * Math.PI; 
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="r">极径</param>
        /// <param name="theta">极角</param>
        public Vector(double? r, double? theta)
        {
            //坐标(3,60°)和(-3,240°)是同一个点
            //(-3,240°)是240°方向的反向延长线上的3个单位长度
            if (r < 0)
            {
                r = -r;
                theta += 180;
            }
            theta = theta % 360;

            R = r;
            Theta = theta;
        }

        /// <summary>
        /// 重载加法运算符
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector op1, Vector op2)
        {
            //C#入门经典中的极坐标，以纵轴为极轴，顺时针方向为正的极角
            //所以纵向分解是R*Cos(theta)  横向分解是R*Sin(theta)  
            try
            {
                //获取新矢量的(x,y)坐标
                double newX = op1.R.Value * Math.Sin(op1.ThetaRadians.Value) + op2.R.Value * Math.Sin(op2.ThetaRadians.Value);
                double newY = op1.R.Value * Math.Cos(op1.ThetaRadians.Value) + op2.R.Value * Math.Cos(op2.ThetaRadians.Value);

                double newR = Math.Sqrt(newX * newX + newY * newY);
                double newTheta = Math.Atan2(newX, newY) * 180.0 / Math.PI;

                return new Vector(newR, newTheta);
            }
            catch 
            {
                return new Vector(null, null);
            }
        }

        /// <summary>
        /// 重载负号运算符
        /// </summary>
        /// <param name="op1"></param>
        /// <returns></returns>
        public static Vector operator -(Vector op1)
        {
            return new Vector(-op1.R, op1.Theta);
        }

        /// <summary>
        /// 重载减法运算符
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector op1, Vector op2)
        {
            return op1 + (-op2);
        }

        /// <summary>
        /// 重写Object的ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";
            return string.Format("({0},{1})", rString, thetaString);
        }
    }
}
