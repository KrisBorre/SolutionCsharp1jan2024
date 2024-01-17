namespace LibraryDifferentialEquationKepler2jan2024
{
    public class MassExoplanetManager
    {
        private ParameterConfiguration mass_exoplanet_configuration;

        public ParameterConfiguration MassExoplanetConfiguration
        {
            get { return mass_exoplanet_configuration; }
            private set { mass_exoplanet_configuration = value; }
        }

        public MassExoplanetManager(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_configuration = mass_exoplanet_configuration;
        }

        public double GetMassExoplanet(double interval, double t)
        {
            double mass_exoplanet = 1.0;

            if (mass_exoplanet_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	mass_exoplanet = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    mass_exoplanet = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass_exoplanet = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    mass_exoplanet = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	mass_exoplanet = 1.0;
                //}
            }

            if (mass_exoplanet_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    mass_exoplanet = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    mass_exoplanet = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass_exoplanet = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    mass_exoplanet = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    mass_exoplanet = 5.0;
                }
            }

            return mass_exoplanet;// / 10;
        }
    }
}
