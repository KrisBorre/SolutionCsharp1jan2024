using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler2jan2024
{
    public enum ParameterConfiguration
    {
        Constant,
        Decrease,
        Increase
    }

    public class DifferentialEquationsKepler : DifferentialEquationsBaseClass
    {
        private MassExoplanetManager mass_exoplanet_manager;
        private MassStarManager mass_star_manager;

        public DifferentialEquationsKepler(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = new MassExoplanetManager(mass_exoplanet_configuration);
            this.mass_star_manager = new MassStarManager(mass_star_configuration);

            DifferentialEquations = new DifferentialEquationBaseClass[4];
            DifferentialEquations[0] = new DifferentialEquation1(mass_exoplanet_manager, mass_star_manager);
            DifferentialEquations[1] = new DifferentialEquation2(mass_exoplanet_manager, mass_star_manager);
            DifferentialEquations[2] = new DifferentialEquation3(mass_exoplanet_manager, mass_star_manager);
            DifferentialEquations[3] = new DifferentialEquation4(mass_exoplanet_manager, mass_star_manager);
        }

        public double GetMassExoplanet(double interval, double t)
        {
            return mass_exoplanet_manager.GetMassExoplanet(interval, t);
        }

        public double GetMassStar(double interval, double t)
        {
            return mass_star_manager.GetMassStar(interval, t);
        }
    }
}

