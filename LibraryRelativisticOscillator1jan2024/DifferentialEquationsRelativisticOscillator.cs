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
    }
}

