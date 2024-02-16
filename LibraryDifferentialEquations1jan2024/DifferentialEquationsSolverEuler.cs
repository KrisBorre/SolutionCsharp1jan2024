namespace LibraryDifferentialEquations1jan2024
{
    public class DifferentialEquationsSolverEuler : DifferentialEquationsSolverBaseClass
    {
        double b1 = 1.0;

        public DifferentialEquationsSolverEuler(DifferentialEquationsBaseClass differentialEquations) : base(differentialEquations)
        { }

        protected override void runge_kutta_step(double interval, double delta_x, double x, double[] y, out double[] term)
        {
            term = new double[numberOfFirstOrderEquations];

            double[] k1 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                k1[i] = differentialEquations[i].function(interval, x, y) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i];
            }
        }

    }
}


