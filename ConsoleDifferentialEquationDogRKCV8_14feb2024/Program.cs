using LibraryDifferentialEquationDog1jan2024;
using LibraryDifferentialEquations1jan2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRKCV8_14feb2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            double interval;

            // https://mathcurve.com/courbes2d.gb/poursuite/poursuite.shtml
            // Solving ODEs I (2000) page 14 master-and-dog problem
            // Sophisticated RKCV8 method with f(x,y) dependency!
            // 2 eerste orde differentiaal vergelijkingen worden opgelost met Runge-Kutta-Cooper-Verner.
            // zie Euler methode om een differentiaal vergelijking numeriek op te lossen.

            // v / w
            // Dog is twice as fast as the master.
            // That means that we stop when the dog reaches the master.

            int kmax = 15;

            string myfile_dog_RKCV8 = @"..\..\dog_kmax15_RKCV8_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 1000;
            Console.WriteLine("master-and-dog problem      RKCV8");

            for (int k = 0; k < kmax; k++)
            {
                DifferentialEquationsSolverBaseClass solver = new DifferentialEquationsSolverRKCV8(new DifferentialEquationsDog10nov2023());

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

                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(myfile_dog_RKCV8, append: true))
                {
                    streamWriter.WriteLine(sb.ToString());
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Stel doelen die je inspireren en zet stappen om ze te bereiken.");
            Console.WriteLine("Look in the text file for the results.");

            Console.WriteLine("Press Enter.");
            Console.ReadLine();

            /*
Numerical solution: 0 	 0.6365440056717472 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.645229503700083 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6514395614037877 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6558650619377026 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6590115557042849 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6612450689498368 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6628287078672404 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6639506641744245 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6647450847568614 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.665307363921668 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6657052248764335 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6659866898462172 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6661857830368999 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6663265968853525 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6664261841649213 	Analytic solution: 0 	 0.6666666666666666 	
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