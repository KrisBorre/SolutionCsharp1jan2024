namespace LibraryPendulum16feb2024
{
    public class GravityManager
    {
        private ParameterConfiguration gravity_configuration;

        public ParameterConfiguration GravityConfiguration
        {
            get { return gravity_configuration; }
            private set { gravity_configuration = value; }
        }

        public GravityManager(ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant)
        {
            this.gravity_configuration = gravity_configuration;
        }

        public double GetGravity(double interval, double t)
        {
            double gravity = 1.0;

            if (gravity_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	gravity = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    gravity = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    gravity = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    gravity = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	gravity = 1.0;
                //}
            }

            if (gravity_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    gravity = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    gravity = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    gravity = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    gravity = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    gravity = 5.0;
                }
            }

            return gravity; // / 10;
        }
    }
}
