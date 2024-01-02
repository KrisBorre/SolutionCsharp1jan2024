using LibraryDifferentialEquations1jan2024;
using LibraryRelativisticOscillator1jan2024;

namespace ConsoleRelativisticOscillator1jan2024
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The special relativistic generalization of the Harmonic Oscillator.");

            DifferentialEquationsSolverBaseClass solver = new DifferentialEquationsSolverRK41_5nov2023(new DifferentialEquationsRelativisticOscillator());

            double interval = 5.0 * 2.0 * Math.PI; // 5 oscillations    
            ulong number_of_steps = 200;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            ConditionInitial ic = new ConditionInitial(0,
                                                       0.0,
                                                       0.9);
            //ic.X = 0;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolutions solutions, number_of_solutions: 200, interval: interval, x_end: interval);

            string string_file_name = "rel_osc_RK41_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            System.IO.FileStream aFileStream2 = new System.IO.FileStream(string_file_name, System.IO.FileMode.CreateNew);
            System.IO.StreamWriter streamWriter1 = new System.IO.StreamWriter(aFileStream2);

            for (int i = 0; i < solutions.numericalSolutions.Length; i++)
            {
                NumericalSolution solution = solutions.numericalSolutions[i];

                string string_time = solution.X.ToString("G15", System.Globalization.CultureInfo.InvariantCulture);
                streamWriter1.Write(string_time + "\t");

                string string_displacement = solution.Y[0].ToString("G15", System.Globalization.CultureInfo.InvariantCulture);
                streamWriter1.WriteLine(string_displacement);
            }

            streamWriter1.Close();

            stopwatch.Stop();
            double cpu_duration = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

            Console.WriteLine("Look in the text file for the results.");

            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }
    }
}



