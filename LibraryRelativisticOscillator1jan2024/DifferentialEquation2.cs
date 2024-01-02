using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    // derivative of velocity (in units of c) is the second equation
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        public override double function(double x, params double[] y)
        {
            return -y[0] * Math.Pow(1 - y[1] * y[1], 1.5);
        }
    }
}
