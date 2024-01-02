using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationDog1jan2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        public override double function(double x, params double[] y)
        {
            return y[1];
        }
    }
}
