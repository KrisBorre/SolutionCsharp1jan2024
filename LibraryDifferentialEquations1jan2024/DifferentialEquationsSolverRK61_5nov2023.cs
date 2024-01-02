namespace LibraryDifferentialEquations1jan2024
{
    public class DifferentialEquationsSolverRK61_5nov2023 : DifferentialEquationsSolverBaseClass
    {
        // See page 194 Butcher (2008)
        double c2 = 1.0 / 3;
        double a21 = 1.0 / 3;
        double c3 = 2.0 / 3;
        double a31 = 0.0;
        double a32 = 2.0 / 3;
        double c4 = 1.0 / 3;
        double a41 = 1.0 / 12;
        double a42 = 1.0 / 3;
        double a43 = -1.0 / 12;
        double c5 = 5.0 / 6;
        double a51 = 25.0 / 48;
        double a52 = -55.0 / 24;
        double a53 = 35.0 / 48;
        double a54 = 15.0 / 8;
        double c6 = 1.0 / 6;
        double a61 = 3.0 / 20;
        double a62 = -11.0 / 24;
        double a63 = -1.0 / 8;
        double a64 = 1.0 / 2;
        double a65 = 1.0 / 10;
        double c7 = 1.0;
        double a71 = -261.0 / 260;
        double a72 = 33.0 / 13;
        double a73 = 43.0 / 156;
        double a74 = -118.0 / 39;
        double a75 = 32.0 / 195;
        double a76 = 80.0 / 39;
        double b1 = 13.0 / 200;
        double b2 = 0.0;
        double b3 = 11.0 / 40;
        double b4 = 11.0 / 40;
        double b5 = 4.0 / 25;
        double b6 = 4.0 / 25;
        double b7 = 13.0 / 200;


        public DifferentialEquationsSolverRK61_5nov2023(DifferentialEquationsBaseClass differentialEquations) : base(differentialEquations)
        { }

        protected override void runge_kutta_step(double interval, double delta_x, double x, double[] y, out double[] term)
        {
            term = new double[numberOfFirstOrderEquations];

            double[] k1 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                k1[i] = differentialEquations[i].function(interval, x, y) * delta_x;
            }

            double[] k2 = new double[numberOfFirstOrderEquations];

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a21;
                }
                k2[i] = differentialEquations[i].function(interval, x + c2 * delta_x, argument) * delta_x;
            }

            double[] k3 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a31 + k2[j] * a32;
                }
                k3[i] = differentialEquations[i].function(interval,x + c3 * delta_x, argument) * delta_x;
            }

            double[] k4 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a41 + k2[j] * a42 + k3[j] * a43;
                }
                k4[i] = differentialEquations[i].function(interval, x + c4 * delta_x, argument) * delta_x;
            }

            double[] k5 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a51 + k2[j] * a52 + k3[j] * a53 + k4[j] * a54;
                }
                k5[i] = differentialEquations[i].function(interval,x + c5 * delta_x, argument) * delta_x;
            }

            double[] k6 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a61 + k2[j] * a62 + k3[j] * a63 + k4[j] * a64 + k5[j] * a65;
                }
                k6[i] = differentialEquations[i].function(interval, x + c6 * delta_x, argument) * delta_x;
            }

            double[] k7 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a71 + k2[j] * a72 + k3[j] * a73 + k4[j] * a74 + k5[j] * a75 + k6[j] * a76;
                }
                k7[i] = differentialEquations[i].function(interval,x + c7 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i] + b5 * k5[i] + b6 * k6[i] + b7 * k7[i];
            }

        }

    }
}

