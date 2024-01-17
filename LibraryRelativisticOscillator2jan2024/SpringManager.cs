namespace LibraryRelativisticOscillator2jan2024
{
    public class SpringManager
    {
        private ParameterConfiguration spring_configuration;

        public ParameterConfiguration SpringConfiguration
        {
            get { return spring_configuration; }
            private set { spring_configuration = value; }
        }

        public SpringManager(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant)
        {
            this.spring_configuration = spring_configuration;
        }

        public double GetSpring(double interval, double t)
        {
            double spring = 1.0;

            if (spring_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	spring = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    spring = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    spring = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    spring = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	spring = 1.0;
                //}
            }

            if (spring_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    spring = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    spring = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    spring = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    spring = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    spring = 5.0;
                }
            }

            return spring; // / 10;
        }
    }
}
