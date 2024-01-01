namespace LibraryDifferentialEquations1jan2024
{
    public class ConditionInitial : ConditionBaseClass
    {
        private int numberOfFirstOrderEquations;

        private double[] y;

        public double[] Y
        {
            get { return y; }
        }

        public ConditionInitial(double x, params double[] y) : base(x)
        {
            if (y != null)
            {
                this.numberOfFirstOrderEquations = y.Length;
                this.y = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    this.y[i] = y[i];
                }
            }
        }
    }
}
