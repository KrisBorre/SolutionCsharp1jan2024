namespace LibraryDifferentialEquations1jan2024
{
    public interface ISolver
    {
        void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolution solution, double interval = Math.PI, double x_end = Math.PI);
        void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolutions solutions, int number_of_solutions = 10000, double interval = Math.PI, double x_end = Math.PI);
    }
}