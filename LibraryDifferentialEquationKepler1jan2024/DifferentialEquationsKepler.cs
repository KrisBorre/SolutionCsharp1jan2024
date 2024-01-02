using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler1jan2024
{
    public class DifferentialEquationsKepler : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsKepler()
        {
            DifferentialEquations = new DifferentialEquationBaseClass[4];
            DifferentialEquations[0] = new DifferentialEquation1();
            DifferentialEquations[1] = new DifferentialEquation2();
            DifferentialEquations[2] = new DifferentialEquation3();
            DifferentialEquations[3] = new DifferentialEquation4();
        }
    }
}

