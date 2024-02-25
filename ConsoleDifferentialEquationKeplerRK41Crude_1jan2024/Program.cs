using LibraryDifferentialEquationKepler1jan2024;
using LibraryDifferentialEquations1jan2024;

namespace ConsoleDifferentialEquationKeplerRK41Crude_1jan2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");
            Console.WriteLine("Comparison between crude Runge-Kutta calculation and sophisticated Runge-Kutta calculation.");

            int kmax = 8; // 5; //  15;

            DifferentialEquationsSolverBaseClass solver = new DifferentialEquationsSolverRK41_16feb2024(new DifferentialEquationsKepler());

            const double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;
            Console.WriteLine("eccentricity = " + eccentricity);

            double interval = Math.PI;

            string myfile_log10_error_versus_log10_delta_x = @"..\..\log10_error_versus_log10_delta_x_double_kmax8_kepler_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

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
                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, out NumericalSolution solutionCrude, interval: interval, sophisticated: false);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                double[] y_crude = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_crude[i] = solutionCrude.Y[i];
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                double error_crude = sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                Console.WriteLine("error_crude = " + error_crude);

                double total_energy_numerical = total_energy_function(y_sophisticated[0], y_sophisticated[1], y_sophisticated[2], y_sophisticated[3]);
                double angular_momentum_numerical = angular_momentum_function(y_sophisticated[0], y_sophisticated[1], y_sophisticated[2], y_sophisticated[3]);

                double total_energy_exact = total_energy_function(y1_pi_exact, y2_pi_exact, y3_pi_exact, y4_pi_exact);
                double angular_momentum_exact = angular_momentum_function(y1_pi_exact, y2_pi_exact, y3_pi_exact, y4_pi_exact);

                stopwatch.Stop();
                double cpu_duration = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                string output1 = string.Format(numberFormatInfo, "{0} \t {1} \t {2}", Math.Log10(delta_x), Math.Log10(Math.Abs(error_sophisticated)), Math.Log10(Math.Abs(error_crude)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_log10_error_versus_log10_delta_x, append: true))
                {
                    streamWriter.WriteLine(output1);
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            /*
eccentricity = 0,5
number_of_steps = 200
error_sophisticated = 5,416653837116365E-07
error_crude = 5,416653876275004E-07
De computer tijd nodig voor deze berekening is 0,0020319 seconden.
number_of_steps = 400
error_sophisticated = 3,2139068476957545E-08
error_crude = 3,213906580896298E-08
De computer tijd nodig voor deze berekening is 0,0011067 seconden.
number_of_steps = 800
error_sophisticated = 1,955389188640242E-09
error_crude = 1,9553795716111583E-09
De computer tijd nodig voor deze berekening is 0,0020223 seconden.
number_of_steps = 1600
error_sophisticated = 1,205525243556392E-10
error_crude = 1,2054664957147092E-10
De computer tijd nodig voor deze berekening is 0,0566277 seconden.
number_of_steps = 3200
error_sophisticated = 7,484111132471269E-12
error_crude = 7,491535662659562E-12
De computer tijd nodig voor deze berekening is 0,0065255 seconden.
number_of_steps = 6400
error_sophisticated = 4,675141776300203E-13
error_crude = 5,134189576381022E-13
De computer tijd nodig voor deze berekening is 0,0130724 seconden.
number_of_steps = 12800
error_sophisticated = 3,060201776824907E-14
error_crude = 8,594330541389016E-14
De computer tijd nodig voor deze berekening is 0,0240452 seconden.
number_of_steps = 25600
error_sophisticated = 3,3066620024888147E-15
error_crude = 1,161219153353765E-13
De computer tijd nodig voor deze berekening is 0,0522791 seconden.
             */

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


        static double total_energy_function(double y1, double y2, double y3, double y4)
        {
            return 0.5 * (y3 * y3 + y4 * y4) - 1.0 / sqrt(y1 * y1 + y2 * y2);
        }

        static double angular_momentum_function(double y1, double y2, double y3, double y4)
        {
            return y1 * y4 - y2 * y3; // Notice the minus sign!
        }
    }
}