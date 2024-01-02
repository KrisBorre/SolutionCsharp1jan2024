using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler1jan2024
{
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        public override double function(double x, params double[] y)
        {
            return y[3];
        }
    }
}
