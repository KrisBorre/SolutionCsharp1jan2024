namespace LibraryDifferentialEquations1jan2024
{
    public class NumericalSolutions : IIndexInterface<NumericalSolution>
    {
        private NumericalSolution[] numericalSolutions;

        public int Length
        {
            get { return numericalSolutions.Length; }
        }

        public int NumberOfSolutions
        {
            get { return numericalSolutions.Length; }
            set
            {
                numericalSolutions = new NumericalSolution[value];
            }
        }

        public NumericalSolution this[int index]
        {
            get
            {
                return numericalSolutions[index];
            }
            set
            {
                numericalSolutions[index] = value;
            }
        }
    }
}
