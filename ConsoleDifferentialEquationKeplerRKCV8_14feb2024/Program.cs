﻿using LibraryDifferentialEquationKepler2jan2024;
using LibraryDifferentialEquations1jan2024;

namespace ConsoleDifferentialEquationKeplerRKCV8_14feb2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            Console.WriteLine("Kepler's planetary motion.          RKCV8");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using the Runge-Kutta-Cooper-Verner method.");
            //Console.WriteLine("Comparison between crude Runge-Kutta calculation and sophisticated Runge-Kutta calculation.");

            int kmax = 5; //  15;

            DifferentialEquationsSolverBaseClass solver = new DifferentialEquationsSolverRKCV8(new DifferentialEquationsKepler());

            const double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;
            Console.WriteLine("eccentricity = " + eccentricity);

            double interval = Math.PI;

            string myfile_log10_error_versus_log10_delta_x_RKCV8 = @"..\..\log10_error_versus_log10_delta_x_double_kmax5_RKCV8_kepler_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 200;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                ConditionInitial ic = new ConditionInitial(0,
                                                           y1_zero_exact_function(eccentricity),
                                                           y2_zero_exact_function(eccentricity),
                                                           y3_zero_exact_function(eccentricity),
                                                           y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution solutionSophisticated, interval: interval, sophisticated: true);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                stopwatch.Stop();
                double cpu_duration = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                string output1 = string.Format(numberFormatInfo, "{0} \t {1}", Math.Log10(delta_x), Math.Log10(Math.Abs(error_sophisticated)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_log10_error_versus_log10_delta_x_RKCV8, append: true))
                {
                    streamWriter.WriteLine(output1);
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            /*
Kepler's planetary motion.          RKCV8
Planet moves around the Sun in an elliptic orbit.
The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta-Cooper-Verner method.
eccentricity = 0,5
number_of_steps = 200
error_sophisticated = 1,8109021630223707E-13
De computer tijd nodig voor deze berekening is 5,7665744 seconden.
number_of_steps = 400
error_sophisticated = 2,1452796910142906E-15
De computer tijd nodig voor deze berekening is 0,0027673 seconden.
number_of_steps = 800
error_sophisticated = 1,7511694774218688E-15
De computer tijd nodig voor deze berekening is 0,0056307 seconden.
number_of_steps = 1600
error_sophisticated = 1,3994233861170033E-15
De computer tijd nodig voor deze berekening is 0,0146549 seconden.
number_of_steps = 3200
error_sophisticated = 1,4624874890978325E-15
De computer tijd nodig voor deze berekening is 0,0179741 seconden.
            */

            Console.WriteLine("Beloon jezelf.");
            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }


        static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        static double y1_zero_exact_function(double eccentricity)
        {
            return 1.0 - eccentricity;
        }

        static double y2_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y3_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y4_zero_exact_function(double eccentricity)
        {
            return sqrt((1.0 + eccentricity) / (1.0 - eccentricity));
        }


        /// <summary>
        /// To check the numerical solution we compare with the exact analytical solution. 
        /// Here is the exact analytical solution to the problem.
        /// </summary>
        static double y1_pi_exact_function(double eccentricity)
        {
            return -1.0 - eccentricity;
        }

        static double y2_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y3_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y4_pi_exact_function(double eccentricity)
        {
            return -sqrt((1.0 - eccentricity) / (1.0 + eccentricity)); // Notice the minus and plus sign!
        }
    }
}