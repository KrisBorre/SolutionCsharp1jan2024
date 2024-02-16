namespace LibraryDifferentialEquations1jan2024
{
    // https://www.dotnetperls.com/enum-flags
    [Flags]
    public enum Method
    {
        Euler = 0x0,
        RK21 = 0x1,
        RK22 = 0x2,
        RK41 = 0x4,
        RK5 = 0x8,
        RK61 = 0x10,
        RKCV8 = 0x20,
        Crude = 0x40,
        Sophisticated = 0x80 // Next two values could be 0x80, 0x100
    }

    //// https://stackoverflow.com/questions/8447/what-does-the-flags-enum-attribute-mean-in-c
    //[Flags]
    //public enum Method : long
    //{
    // Euler = 0,
    //    RK21 = 1,
    // RK22 = 2
    //    RK41 = 4,
    // RK5 = 8,
    //    RK61 = 16,
    //    RKCV8 = 32,
    //    Crude = 64,
    //    Sophisticated = 128
    //}

    public class DifferentialEquationsSolver1jan2024 : ISolver
    {
        private DifferentialEquationsSolverBaseClass differentialEquationsSolverBaseClass;
        private bool sophisticated;

        public DifferentialEquationsSolver1jan2024(DifferentialEquationsBaseClass differentialEquations, Method method = Method.RK61)
        {
            switch (method)
            {
                case Method.Euler | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.Euler | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK21 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK21 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK41 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_16feb2024(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_16feb2024(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK5 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK5 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5(differentialEquations);
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
                case Method.RKCV8 | Method.Sophisticated:
                    // Sophisticated Runge Kutta Order 8. See page 197 Butcher (2008) (second edition)
                    // Order 7 needs 11 stages.
                    // Cooper Verner 8
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RKCV8 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RKCV8:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK61:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_5nov2023(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK5:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_16feb2024(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK21:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.Euler:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler(differentialEquations);
                    this.sophisticated = true;
                    break;
                default:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8(differentialEquations);
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
