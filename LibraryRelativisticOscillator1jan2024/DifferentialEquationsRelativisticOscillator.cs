using LibraryDifferentialEquations1jan2024;

namespace LibraryRelativisticOscillator1jan2024
{
    public class DifferentialEquationsRelativisticOscillator : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsRelativisticOscillator()
        {   
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1();
            this[1] = new DifferentialEquation2();
        }
    }
}

