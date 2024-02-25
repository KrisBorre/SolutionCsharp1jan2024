namespace LibraryDifferentialEquations1jan2024
{
    /// <summary>
    /// First order differential equation
    /// </summary>
    public abstract class DifferentialEquationsBaseClass : IIndexInterface<DifferentialEquationBaseClass>
    {
        private DifferentialEquationBaseClass[] differentialEquations;

        public int Length
        {
            get { return differentialEquations.Length; }
        }

        public int NumberOfFirstOrderEquations
        {
            get { return differentialEquations.Length; }
            set
            {
                differentialEquations = new DifferentialEquationBaseClass[value];
            }
        }

        public DifferentialEquationBaseClass this[int index]
        {
            get
            {
                return differentialEquations[index];
            }
            set
            {
                differentialEquations[index] = value;
            }
        }
    }
}
