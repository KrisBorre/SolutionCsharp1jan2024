namespace LibraryDifferentialEquations1jan2024
{
    public class DifferentialEquationsSolverRK41_16feb2024 : DifferentialEquationsSolverBaseClass
    {
        // See page 87 Butcher (2008)
        // Runge Kutta 41. See page 99 Butcher (2008)
        double c2 = 1.0 / 2.0; // Fouten maken hoort bij elk groeiproces.
        double a21 = 1.0 / 2.0;
        double c3 = 1.0 / 2.0;
        double a31 = 0.0;
        double a32 = 1.0 / 2.0;
        double c4 = 1.0;
        double a41 = 0.0;
        double a42 = 0.0;
        double a43 = 1.0;

        double b1 = 1.0 / 6.0;
        double b2 = 1.0 / 3.0;
        double b3 = 1.0 / 3.0;
        double b4 = 1.0 / 6.0;

        public DifferentialEquationsSolverRK41_16feb2024(DifferentialEquationsBaseClass differentialEquations) : base(differentialEquations)
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

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i];
            }
        }

    }
}


