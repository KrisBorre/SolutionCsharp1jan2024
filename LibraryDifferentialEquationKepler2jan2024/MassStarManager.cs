namespace LibraryDifferentialEquationKepler2jan2024
{
    public class MassStarManager
    {
        private ParameterConfiguration mass_star_configuration;

        public ParameterConfiguration MassStarConfiguration
        {
            get { return mass_star_configuration; }
            private set { mass_star_configuration = value; }
        }

        public MassStarManager(ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_star_configuration = mass_star_configuration;
        }

        public double GetMassStar(double interval, double t)
        {
            double mass_star = 1.0;

            if (mass_star_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	mass_star = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    mass_star = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass_star = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    mass_star = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	mass_star = 1.0;
                //}
            }

            if (mass_star_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    mass_star = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    mass_star = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass_star = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    mass_star = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    mass_star = 5.0;
                }
            }

            return mass_star; // * 10;
        }
    }
}
