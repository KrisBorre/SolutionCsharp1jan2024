using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler1jan2024
{
    internal class DifferentialEquation3 : DifferentialEquationBaseClass
    {
        public override double function(double x, params double[] y)
        {
            return -y[0] / Math.Pow(y[0] * y[0] + y[1] * y[1], 1.5);
        }
    }
}
