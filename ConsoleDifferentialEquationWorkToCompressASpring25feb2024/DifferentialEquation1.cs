using LibraryDifferentialEquations1jan2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring25feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass
    {
        double k;

        public DifferentialEquation1(double k = 50)
        {
            this.k = k;
        }

        public override double function(double interval, double x, params double[] y)
        {
            return k * x;
        }
    }
}
