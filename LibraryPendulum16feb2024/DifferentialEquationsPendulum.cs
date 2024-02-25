using LibraryDifferentialEquations1jan2024;

namespace LibraryPendulum16feb2024
{
    public class DifferentialEquationsPendulum : DifferentialEquationsBaseClass
    {
        private LengthManager length_manager;
        private GravityManager gravity_manager;
        private MassManager mass_manager;

        // angle: theta, canonical momentum: p_theta
        public DifferentialEquationsPendulum(ParameterConfiguration length_configuration = ParameterConfiguration.Constant, ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.length_manager = new LengthManager(length_configuration);
            this.gravity_manager = new GravityManager(gravity_configuration);
            this.mass_manager = new MassManager(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1(length_manager, gravity_manager, mass_manager);
            this[1] = new DifferentialEquation2(length_manager, gravity_manager, mass_manager);
        }

        public double GetLength(double interval, double t)
        {
            return length_manager.GetLength(interval, t);
        }

        public double GetGravity(double interval, double t)
        {
            return gravity_manager.GetGravity(interval, t);
        }

        public double GetMass(double interval, double t)
        {
            return mass_manager.GetMass(interval, t);
        }
    }
}

