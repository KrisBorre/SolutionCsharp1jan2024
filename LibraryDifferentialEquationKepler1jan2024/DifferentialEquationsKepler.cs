using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationKepler1jan2024
{
    public class DifferentialEquationsKepler : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsKepler()
        {   
            this.NumberOfFirstOrderEquations = 4;
            this[0] = new DifferentialEquation1();
            this[1] = new DifferentialEquation2();
            this[2] = new DifferentialEquation3();
            this[3] = new DifferentialEquation4();
        }
    }
}

