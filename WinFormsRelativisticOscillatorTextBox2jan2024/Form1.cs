using LibraryDifferentialEquations1jan2024;
using LibraryRelativisticOscillator2jan2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsRelativisticOscillatorTextBox2jan2024
{
    public partial class Form1 : Form
    {
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;

        private PlotView plotView1;
        private PlotView plotView2;
        private PlotView plotView3;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Relativistic oscillator.";

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            int width = 1456;
            int height = 557;
            this.ClientSize = new Size(width, height);

            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(1352, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.Location = new Point(1113, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(1232, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ratio of v over c:";

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Solving a system of differential equations: Relativistic oscillator.";

            this.plotView1 = new PlotView();
            this.plotView2 = new PlotView();
            this.plotView3 = new PlotView();

            int numberOfPlots = 3;

            this.plotView1.Size = new Size(width, (height - 40) / numberOfPlots);
            this.plotView1.Location = new Point(0, 40);

            this.plotView2.Size = new Size(width, (height - 40) / numberOfPlots);
            this.plotView2.Location = new Point(0, 40 + ((height - 40) / numberOfPlots));

            this.plotView3.Size = new Size(width, (height - 40) / numberOfPlots);
            this.plotView3.Location = new Point(0, 40 + 2 * ((height - 40) / numberOfPlots));


            const double ratio = 0.9;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = ratio.ToString(provider);

            this.Calculate(ratio);

            Controls.Add(plotView1);
            Controls.Add(plotView2);
            Controls.Add(plotView3);

            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = textBox1.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double ratio))
            {
                this.Calculate(ratio);
            }
        }

        private void Calculate(double ratio)
        {
            Console.WriteLine("Don�t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 100;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 1000;

            var problem = new DifferentialEquationsRelativisticOscillator(spring_configuration: ParameterConfiguration.Increase);

            ISolver solver = new DifferentialEquationsSolver1jan2024(problem, Method.RK61);

            ConditionInitial ic = new ConditionInitial(0,
                                           0.0,
                                           ratio);

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolutions solutions, number_of_solutions: (int)(1000 * number_of_oscillations), interval: interval, x_end: interval);

            #region plot1          Spring
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.numericalSolutions.Length; i++)
                {
                    NumericalSolution solution = solutions.numericalSolutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetSpring(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Spring" });

                this.plotView1.Model = plotModel1;
            }
            #endregion

            #region plot2 y1       Displacement
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.numericalSolutions.Length; i++)
                {
                    NumericalSolution solution = solutions.numericalSolutions[i];
                    series2.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "Displacement" });

                this.plotView2.Model = plotModel2;
            }
            #endregion


            #region plot3          Energy
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                double[] energies = new double[solutions.numericalSolutions.Length];

                for (int i = 0; i < solutions.numericalSolutions.Length; i++)
                {
                    NumericalSolution solution = solutions.numericalSolutions[i];
                    double energy = this.energy_function(k: problem.GetSpring(interval, solution.X), m: problem.GetMass(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1]);
                    energies[i] = energy;
                    series3.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotView3.Model = plotModel3;
            }
            #endregion
        }

        private double energy_function(double k, double m, double y1, double y2)
        {
            //double kinetic_energy = (m * y2 * y2) / 2.0; // non-relativistic
            double gamma = Math.Pow(1 - y2 * y2, -0.5);
            double kinetic_energy = gamma * m;
            double potential_energy = (k * y1 * y1) / 2.0;
            return kinetic_energy + potential_energy;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            int numberOfPlots = 3;

            if (this.plotView1 != null)
            {
                this.plotView1.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView1.Location = new Point(0, 40);
            }

            if (this.plotView2 != null)
            {
                this.plotView2.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView2.Location = new Point(0, 40 + ((height - 40) / numberOfPlots));
            }

            if (this.plotView3 != null)
            {
                this.plotView3.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView3.Location = new Point(0, 40 + 2 * ((height - 40) / numberOfPlots));
            }
        }
    }
}