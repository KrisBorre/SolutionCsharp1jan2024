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
    }
}