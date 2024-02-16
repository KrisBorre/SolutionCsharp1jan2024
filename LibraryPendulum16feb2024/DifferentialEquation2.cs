using LibraryDifferentialEquations1jan2024;

namespace LibraryPendulum16feb2024
{
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        private LengthManager length_manager;
        private GravityManager gravity_manager;
        private MassManager mass_manager;

        public DifferentialEquation2(LengthManager length_manager, GravityManager gravity_manager, MassManager mass_manager)
        {
            this.length_manager = length_manager;
            this.gravity_manager = gravity_manager;
            this.mass_manager = mass_manager;
        }

        public override double function(double interval, double x, params double[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            double l = length_manager.GetLength(interval, x);
            double g = gravity_manager.GetGravity(interval, x);
            double m = mass_manager.GetMass(interval, x);

            return -m * g * l * Math.Sin(y[0]);
        }
    }
}
