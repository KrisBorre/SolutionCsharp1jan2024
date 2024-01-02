using LibraryDifferentialEquations1jan2024;
using LibraryRelativisticOscillator1jan2024;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsRelativisticOscillatorTextBox1jan2024
{
    public partial class Form1 : Form
    {
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private PlotView plotView1;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Relativistic oscillator.";

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            this.ClientSize = new Size(1456, 557);

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
            this.plotView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            this.plotView1.Size = new Size(1456, 557 - 40);
            this.plotView1.Location = new Point(0, 40);

            const double ratio = 0.9;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = ratio.ToString(provider);

            this.Calculate(ratio);

            Controls.Add(plotView1);
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

            double interval = 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = 1000;
            Console.WriteLine("Relativistic oscillator      RK41");

            ISolver solver = new DifferentialEquationsSolver1jan2024(new DifferentialEquationsRelativisticOscillator(), Method.RK41);


            ConditionInitial ic = new ConditionInitial(0,
                                           0.0,
                                           ratio);

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolutions solutions, number_of_solutions: 1000, interval: interval, x_end: interval);

            PlotModel plotModel = new PlotModel();
            LineSeries series = new LineSeries();

            for (int i = 0; i < solutions.numericalSolutions.Length; i++)
            {
                NumericalSolution solution = solutions.numericalSolutions[i];
                series.Points.Add(new DataPoint(solution.X, solution.Y[0]));
            }

            plotModel.Series.Add(series);

            this.plotView1.Model = plotModel;
        }

    }
}