using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcUtil
{
    public enum Model
    {
        NONE,
        TK_50,
        KJ66,
        GR_180,
        TJE_500
    }

    public enum CompressType
    {
        NONE,
        Retro_Curved,
        Radially_Tipped
    }

    public class Turbine
    {
        //private Model currModel;
        private string currModel;
        private CompressType currType;

        protected double height;
        protected double d2;

        protected double d3;
        protected double d4;
        protected double f;
        protected double di;

        protected double angle;
        protected int bladeNum;

        public Turbine() { }

        public void Init(string _currModel, CompressType _currType, double _height, double _d2)
        {
            this.currModel = _currModel;
            this.currType = _currType;

            this.height = _height;
            this.d2 = _d2;
        }

        public virtual double D3() { return d3; }
        public virtual double D4() { return d4; }
        public virtual double F() { return f; }
        public virtual double Di() { return di; }
    }

    class RetroCurved_Turbine : Turbine
    {
        public override double D3()
        {
            return (1.12 * d2);
        }

        public override double D4()
        {
            return (1.67 * d2);
        }

        public override double F()
        {
            return Math.Sqrt(3030 * d2 * height);
        }

        public override double Di()
        {
            double a = Math.Pow(d2, 2);
            double b = 6.8 * d2 * height;
            return Math.Sqrt(a - b);
        }

    }

    class RadiallyTipped_Turbine : Turbine
    {
        public override double D3()
        {
            return (1.1 * d2);
        }

        public override double D4()
        {
            return (1.7 * d2);
        }

        public override double F()
        {
            return Math.Sqrt(2600 * d2 * height);
        }

        public override double Di()
        {
            double a = Math.Pow(d2, 2);
            double b = 5.3 * d2 * height;
            return Math.Sqrt(a - b);
        }
    }
}
