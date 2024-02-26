using LibraryDifferentialEquations1jan2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring25feb2024
{
    internal class DifferentialEquationsWorkToCompressASpring : DifferentialEquationsBaseClass
    {
        public DifferentialEquationsWorkToCompressASpring()
        {
            this.NumberOfFirstOrderEquations = 1;
            this[0] = new DifferentialEquation1();            
        }
    }
}
