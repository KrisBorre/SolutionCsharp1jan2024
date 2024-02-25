using LibraryDifferentialEquations1jan2024;

namespace LibraryDifferentialEquationDog1jan2024
{
    public class DifferentialEquationsDog10nov2023 : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsDog10nov2023(double ratio = 0.5)
        {   
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1();
            this[1] = new DifferentialEquation2(ratio);
        }
    }
}