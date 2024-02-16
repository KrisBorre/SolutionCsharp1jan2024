namespace LibraryPendulum16feb2024
{
    public class LengthManager
    {
        private ParameterConfiguration length_configuration;

        public ParameterConfiguration LengthConfiguration
        {
            get { return length_configuration; }
            private set { length_configuration = value; }
        }

        public LengthManager(ParameterConfiguration length_configuration = ParameterConfiguration.Constant)
        {
            this.length_configuration = length_configuration;
        }

        public double GetLength(double interval, double t)
        {
            double length = 1.0;

            if (length_configuration == ParameterConfiguration.Increase)
            {
                //if (t <= 10.0)
                //{
                //	length = 1.0;
                //}
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = 4.0 / (interval / 2.0 - 15.0);
                    double q = 1 - (40.0 / (interval / 2.0 - 15.0));
                    length = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    length = 5.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = -4.0 / (interval / 2.0 - 15.0);
                    double q = 1.0 - m * (interval - 10.0);
                    length = m * t + q;
                }
                //if ((t > (interval - 10.0)) && (t <= interval))
                //{
                //	length = 1.0;
                //}
            }

            if (length_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= 10.0)
                {
                    length = 5.0;
                }
                if ((t > 10.0) && (t <= (interval / 2.0 - 5.0)))
                {
                    double m = -4.0 / ((interval / 2.0) - 15.0);
                    double q = 5 - (-40.0 / ((interval / 2.0) - 15.0));
                    length = m * t + q;
                }
                if ((t > (interval / 2.0 - 5.0)) && (t <= (interval / 2.0 + 5.0)))
                {
                    length = 1.0;
                }
                if ((t > (interval / 2.0 + 5.0)) && (t <= (interval - 10.0)))
                {
                    double m = 4.0 / (interval / 2 - 15.0);
                    double q = 1 - (4.0 / (interval / 2 - 15.0)) * (interval / 2.0 + 5.0);
                    length = m * t + q;
                }
                if ((t > (interval - 10.0)) && (t <= interval))
                {
                    length = 5.0;
                }
            }

            return length; // * 10;
        }
    }
}
