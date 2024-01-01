namespace LibraryDifferentialEquations1jan2024
{
    /// <summary>
    /// First order differential equation
    /// </summary>
    public abstract class DifferentialEquationsBaseClass : IIndexInterface<DifferentialEquationBaseClass>
    {
        public DifferentialEquationBaseClass[] DifferentialEquations;

        public int NumberOfFirstOrderEquations
        {
            get { return DifferentialEquations.Length; }
        }

        public DifferentialEquationBaseClass this[int index]
        {
            get
            {
                return DifferentialEquations[index];
            }
            set
            {
                DifferentialEquations[index] = value;
            }
        }
    }
}
