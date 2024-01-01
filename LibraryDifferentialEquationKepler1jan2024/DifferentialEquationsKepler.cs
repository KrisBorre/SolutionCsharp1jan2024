using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler1jan2024
{
    public class DifferentialEquationsKepler : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsKepler()
        {
            DifferentialEquations = new DifferentialEquationBaseClass[4];
            DifferentialEquations[0] = new DifferentialEquation1();
            DifferentialEquations[1] = new DifferentialEquation2();
            DifferentialEquations[2] = new DifferentialEquation3();
            DifferentialEquations[3] = new DifferentialEquation4();
        }

        class DifferentialEquation1 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return y[2];
            }
        }

        class DifferentialEquation2 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return y[3];
            }
        }

        class DifferentialEquation3 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return -y[0] / Math.Pow(y[0] * y[0] + y[1] * y[1], 1.5);
            }
        }

        class DifferentialEquation4 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return -y[1] / Math.Pow(y[0] * y[0] + y[1] * y[1], 1.5);
            }
        }
    }
}

