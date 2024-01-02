using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    // derivative of displacement is the first equation
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        public override double function(double x, params double[] y)
        {
            return y[1];
        }
    }
}
