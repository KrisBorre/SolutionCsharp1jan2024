using LibraryDifferentialEquationDog1jan2024;
using LibraryDifferentialEquations1jan2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK61_1jan2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            double interval;

            // https://mathcurve.com/courbes2d.gb/poursuite/poursuite.shtml
            // Solving ODEs I (2000) page 14 master-and-dog problem
            // Sophisticated RK61 method with f(x,y) dependency!
            // 2 eerste orde differentiaal vergelijkingen worden opgelost met Runge-Kutta.
            // zie Euler methode om een differentiaal vergelijking numeriek op te lossen.
            // for RK61 see page 194 Butcher (2008)

            // v / w
            // Dog is twice as fast as the master.
            // That means that we stop when the dog reaches the master.

            int kmax = 15;

            string myfile_dog_RK61 = @"..\..\dog_kmax15_RK61_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 1000;
            Console.WriteLine("master-and-dog problem      RK61");

            for (int k = 0; k < kmax; k++)
            {
                DifferentialEquationsSolverBaseClass solver = new DifferentialEquationsSolverRK61_5nov2023(new DifferentialEquationsDog10nov2023());

                //y1[0] = 0.0; // This is the location where the master starts walking.
                //y2[0] = 0.0;

                // This is the distance at the outset of the problem between the dog and the master.
                const double a = 1.0; // This is the location where the dog starts running.
                double x_end = 0;
                interval = Math.Abs(x_end - a);// 1.0; // interval is from 1 to 0 // Math.Abs(x_end - a);

                ConditionInitial ic = new ConditionInitial(a, 0, 0);
                //ic.X = a; // x_begin                

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolution solution, interval: interval, sophisticated: true, x_end: x_end);

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";

                StringBuilder sb = new StringBuilder();
                sb.Append("Numerical solution: ");
                sb.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution.X, solution.Y[0]));

                sb.Append("Analytic solution: ");
                sb.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution.X, y_exact_function(solution.X)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_dog_RK61, append: true))
                {
                    streamWriter.WriteLine(sb.ToString());
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            Console.WriteLine("Press Enter.");
            Console.ReadLine();

            /*
Numerical solution: 0 	 0.6365441745259239 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6452296221648239 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6514396448403114 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6558651208191794 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6590115972983673 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.66124509834665 	    Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.662828728648748  	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6639506788673385 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6647450951456733 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6653073712674384 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6657052300705967 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6659866935190166 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6661857856339511 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6663265987217415 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6664261854634432 	Analytic solution: 0 	 0.6666666666666666 
            */
        }


        /// <summary>
        /// To check the numerical solution we compare with the exact analytical solution. 
        /// Here is the exact analytical solution to the problem.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double y_exact_function(double x)
        {
            return (Math.Pow(x, 1.5) / 3.0) - Math.Sqrt(x) + 2.0 / 3.0;
        }
    }
}