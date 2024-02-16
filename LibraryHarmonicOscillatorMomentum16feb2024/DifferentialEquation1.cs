using LibraryDifferentialEquations1jan2024;

namespace LibraryHarmonicOscillatorMomentum16feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        private SpringManager spring_manager;
        private MassManager mass_manager;

        public DifferentialEquation1(SpringManager spring, MassManager mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override double function(double interval, double x, params double[] y)
        {
            double m = mass_manager.GetMass(interval, x);

            return y[1] / m;
        }
    }
}
