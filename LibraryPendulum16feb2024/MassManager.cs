namespace LibraryPendulum16feb2024
{
    public class MassManager
    {
        private ParameterConfiguration mass_configuration;

        public ParameterConfiguration MassConfiguration
        {
            get { return mass_configuration; }
            private set { mass_configuration = value; }
        }

        public MassManager(ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.mass_configuration = mass_configuration;
        }

        public double GetMass(double interval, double t)
        {
            double mass = 1.0;

            if (mass_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	mass = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    mass = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    mass = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	mass = 1.0;
                //}
            }

            if (mass_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    mass = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    mass = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    mass = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    mass = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    mass = 5.0;
                }
            }

            return mass; // * 10;
        }
    }
}
