using LibraryDifferentialEquations1jan2024;

namespace LibraryHarmonicOscillatorVelocity14feb2024
{
    // velocity and displacement
    public class DifferentialEquationsHarmonicOscillator : DifferentialEquationsBaseClass
    {
        private MassManager mass_manager;
        private SpringManager spring_manager;

        public DifferentialEquationsHarmonicOscillator(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.spring_manager = new SpringManager(spring_configuration);
            this.mass_manager = new MassManager(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1(spring_manager, mass_manager);
            this[1] = new DifferentialEquation2(spring_manager, mass_manager);
        }

        public double GetSpring(double interval, double t)
        {
            return spring_manager.GetSpring(interval, t);
        }

        public double GetMass(double interval, double t)
        {
            return mass_manager.GetMass(interval, t);
        }
    }
}

