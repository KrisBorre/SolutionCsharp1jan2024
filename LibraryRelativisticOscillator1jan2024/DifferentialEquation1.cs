using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    // The derivative of the displacement is the first equation.
    // More specifically, the derivative of the displacement is the velocity.
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        public override double function(double interval, double x, params double[] y)
        {
            return y[1];
        }
    }
}
