using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationDog1jan2024
{
    public class DifferentialEquationsDog10nov2023 : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsDog10nov2023(double ratio = 0.5)
        {
            DifferentialEquations = new DifferentialEquationBaseClass[2];
            DifferentialEquations[0] = new DifferentialEquation1();
            DifferentialEquations[1] = new DifferentialEquation2(ratio);
        }

        public class DifferentialEquation1 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return y[1];
            }
        }

        public class DifferentialEquation2 : DifferentialEquationBaseClass
        {
            public double ratio; // ratio zou ook een functie van x kunnen zijn.

            public DifferentialEquation2(double ratio = 0.5)
            {
                this.ratio = ratio; // 1.0 / 2; // v / w
                                    // Dog is twice as fast as the master.
            }

            public override double function(double x, params double[] y)
            {
                return (ratio / x) * Math.Pow(1.0 + y[1] * y[1], 0.5);
            }
        }
    }
}