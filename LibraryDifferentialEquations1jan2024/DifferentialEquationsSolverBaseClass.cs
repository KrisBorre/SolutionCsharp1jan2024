namespace LibraryDifferentialEquations1jan2024
{
    public abstract class DifferentialEquationsSolverBaseClass
    {
        protected DifferentialEquationsBaseClass differentialEquations;
        protected int numberOfFirstOrderEquations;


        public DifferentialEquationsSolverBaseClass(DifferentialEquationsBaseClass differentialEquations)
        {
            if (differentialEquations == null)
            {
                throw new Exception("Sorry, Runge Kutta is verkeerd aangeroepen. Hierop kan ik geen Runge Kutta methode uitvoeren.");
            }
            else
            {
                this.differentialEquations = differentialEquations;
                this.numberOfFirstOrderEquations = differentialEquations.NumberOfFirstOrderEquations;
            }
        }


        abstract protected void runge_kutta_step(double interval, double delta_x, double x, double[] y, out double[] term);


        public void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolution solution, double interval = Math.PI, bool sophisticated = true, double x_end = Math.PI)
        {
            delta_x = interval / number_of_steps;

            double[] y = new double[numberOfFirstOrderEquations];

            double x = initialCondition.X;

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                y[i] = initialCondition.Y[i];
            }

            double[] z = new double[numberOfFirstOrderEquations];
            double[] new_y = new double[numberOfFirstOrderEquations];
            double[] term;

            for (ulong k = 1; k <= number_of_steps; k++)
            {
                runge_kutta_step(interval, delta_x, x, y, out term);

                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    if (sophisticated)
                    {
                        term[j] += z[j];
                        new_y[j] = y[j] + term[j];
                        z[j] = term[j] - (new_y[j] - y[j]);
                        y[j] = new_y[j];
                    }
                    else
                    {
                        y[j] += term[j];
                    }
                }

                if (initialCondition.X > x_end)
                {
                    x = initialCondition.X - k * delta_x;
                }
                else
                {
                    x = initialCondition.X + k * delta_x;
                }

            }

            solution = new NumericalSolution(y);
            solution.X = x;
        }

        /// <summary>
        /// Solve the entire trajectory.
        /// </summary>
        /// <param name="initialCondition"></param>
        /// <param name="number_of_steps"></param>
        /// <param name="delta_x"></param>
        /// <param name="solutions"></param>
        /// <param name="number_of_solutions"></param>
        /// <param name="interval"></param>
        /// <param name="sophisticated"></param>
        /// <param name="x_end"></param>
        public void Solve(ConditionInitial initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolutions solutions, int number_of_solutions = 10000, double interval = Math.PI, bool sophisticated = true, double x_end = Math.PI)
        {
            delta_x = interval / number_of_steps;
            int index_solution = 0;

            solutions = new NumericalSolutions();
            number_of_solutions = (int)Math.Min(number_of_steps, (ulong)number_of_solutions);
            solutions.numericalSolutions = new NumericalSolution[number_of_solutions];

            double[] y = new double[numberOfFirstOrderEquations];

            double x = initialCondition.X;

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                y[i] = initialCondition.Y[i];
            }

            double[] z = new double[numberOfFirstOrderEquations];
            double[] new_y = new double[numberOfFirstOrderEquations];
            double[] term;

            for (ulong k = 1; k <= number_of_steps; k++)
            {
                runge_kutta_step(interval, delta_x, x, y, out term);

                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    if (sophisticated)
                    {
                        term[j] += z[j];
                        new_y[j] = y[j] + term[j];
                        z[j] = term[j] - (new_y[j] - y[j]);
                        y[j] = new_y[j];
                    }
                    else
                    {
                        y[j] += term[j];
                    }
                }

                if (initialCondition.X > x_end)
                {
                    x = initialCondition.X - k * delta_x;
                }
                else
                {
                    x = initialCondition.X + k * delta_x;
                }


                ulong factor = number_of_steps / (ulong)number_of_solutions;
                ulong some_number = k % factor;
                if (some_number == 0)
                {
                    NumericalSolution solution = new NumericalSolution(y);
                    solution.X = x;
                    solutions.numericalSolutions[index_solution] = solution;
                    index_solution++;
                }
            }
        }

    }
}

