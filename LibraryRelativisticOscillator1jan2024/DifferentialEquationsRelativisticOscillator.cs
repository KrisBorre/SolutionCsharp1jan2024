using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    public class DifferentialEquationsRelativisticOscillator : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsRelativisticOscillator()
        {
            DifferentialEquations = new DifferentialEquationBaseClass[2];
            DifferentialEquations[0] = new DifferentialEquation1();
            DifferentialEquations[1] = new DifferentialEquation2();
        }

        // derivative of displacement is the first equation
        class DifferentialEquation1 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return y[1];
            }
        }

        // derivative of velocity (in units of c) is the second equation
        class DifferentialEquation2 : DifferentialEquationBaseClass
        {
            public override double function(double x, params double[] y)
            {
                return -y[0] * Math.Pow(1 - y[1] * y[1], 1.5);
            }
        }
    }
}

