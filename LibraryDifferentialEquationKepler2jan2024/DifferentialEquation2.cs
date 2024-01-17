using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler2jan2024
{
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        private MassExoplanetManager mass_exoplanet_manager;
        private MassStarManager mass_star_manager;

        public DifferentialEquation2(MassExoplanetManager mass_exoplanet_manager, MassStarManager mass_star_manager, ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = mass_exoplanet_manager;
            this.mass_star_manager = mass_star_manager;
        }

        public override double function(double interval, double x, params double[] y)
        {
            double mass = mass_exoplanet_manager.GetMassExoplanet(interval, x);
            return y[3] / mass;
        }
    }
}
