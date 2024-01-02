using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    // The derivative of the velocity (in units of c) is the second equation.
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        public override double function(double interval, double x, params double[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.
            double k = k_function(interval, x); // spring
            double m = m_function(interval, x); // mass
            return -(k / m) * y[0] * Math.Pow(1 - y[1] * y[1], 1.5);
        }

        private double k_function(double interval, double x)
        {
            return 1;
        }

        private double m_function(double interval, double x)
        {
            return 1;
        }
    }
}
