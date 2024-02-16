namespace LibraryDifferentialEquations1jan2024
{
    public class DifferentialEquationsSolverRK5 : DifferentialEquationsSolverBaseClass
    {
        // Runge Kutta 5. See page 99 Butcher (2008)

        double c2 = 1.0 / 4;
        double a21 = 1.0 / 4;
        double c3 = 1.0 / 4;
        double a31 = 1.0 / 8.0;
        double a32 = 1.0 / 8;
        double c4 = 1.0 / 2;
        double a41 = 0.0;
        double a42 = 0.0;
        double a43 = 1.0 / 2;
        double c5 = 3.0 / 4;
        double a51 = 3.0 / 16;
        double a52 = -3.0 / 8;
        double a53 = 3.0 / 8;
        double a54 = 9.0 / 16;
        double c6 = 1.0;
        double a61 = -3.0 / 7;
        double a62 = 8.0 / 7;
        double a63 = 6.0 / 7;
        double a64 = -12.0 / 7;
        double a65 = 8.0 / 7;
        double b1 = 7.0 / 90;
        double b2 = 0.0;
        double b3 = 32.0 / 90;
        double b4 = 12.0 / 90;
        double b5 = 32.0 / 90;
        double b6 = 7.0 / 90;

        public DifferentialEquationsSolverRK5(DifferentialEquationsBaseClass differentialEquations) : base(differentialEquations)
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
                k3[i] = differentialEquations[i].function(interval, x + c3 * delta_x, argument) * delta_x;
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
                k5[i] = differentialEquations[i].function(interval, x + c5 * delta_x, argument) * delta_x;
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

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i] + b5 * k5[i] + b6 * k6[i];
            }

        }

    }
}

