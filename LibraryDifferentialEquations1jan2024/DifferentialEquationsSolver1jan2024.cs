namespace LibraryDifferentialEquations1jan2024
{
    [Flags]
    public enum Method
    {
        RK41 = 0x0,
        RK61 = 0x1,
        Crude = 0x2,
        Sophisticated = 0x4
    }

    public class DifferentialEquationsSolver1jan2024 : ISolver
    {
        private DifferentialEquationsSolverBaseClass differentialEquationsSolverBaseClass;
        private bool sophisticated;

        public DifferentialEquationsSolver1jan2024(DifferentialEquationsBaseClass differentialEquations, Method method = Method.RK61)
        {
            switch (method)
            {
                case Method.RK41 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_5nov2023(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK61 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK61 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_5nov2023(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK61:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
                default:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
            }
        }

        public void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolution solution, double interval = Math.PI, double x_end = Math.PI)
        {
            differentialEquationsSolverBaseClass.Solve(initialCondition, number_of_steps, out delta_x, out solution, interval, this.sophisticated, x_end);
        }

        public void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolutions solutions, int number_of_solutions = 10000, double interval = Math.PI, double x_end = Math.PI)
        {
            differentialEquationsSolverBaseClass.Solve(initialCondition, number_of_steps, out delta_x, out solutions, number_of_solutions, interval, this.sophisticated, x_end);
        }
    }
}
