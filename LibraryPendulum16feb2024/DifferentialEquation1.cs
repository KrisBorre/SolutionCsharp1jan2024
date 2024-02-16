using LibraryDifferentialEquations1jan2024;

namespace LibraryPendulum16feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        private LengthManager length_manager;
        private GravityManager gravity_manager;
        private MassManager mass_manager;

        public DifferentialEquation1(LengthManager length_manager, GravityManager gravity_manager, MassManager mass_manager)
        {
            this.length_manager = length_manager;
            this.gravity_manager = gravity_manager;
            this.mass_manager = mass_manager;
        }

        public override double function(double interval, double x, params double[] y)
        {
            double l = length_manager.GetLength(interval, x);
            double g = gravity_manager.GetGravity(interval, x);
            double m = mass_manager.GetMass(interval, x);

            return y[1] / (m * l * l);
        }
    }
}
