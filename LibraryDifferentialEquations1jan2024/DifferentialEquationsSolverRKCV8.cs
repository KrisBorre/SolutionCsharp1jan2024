namespace LibraryDifferentialEquations1jan2024
{
    // Sophisticated Runge Kutta Order 8. See page 197 Butcher (2008) (second edition)
    // Order 7 needs 11 stages.
    // Cooper Verner 8
    public class DifferentialEquationsSolverRKCV8 : DifferentialEquationsSolverBaseClass
    {
        double c2 = 1.0 / 2; // done
        double a21 = 1.0 / 2; // done
        double c3 = 1.0 / 2; // done
        double a31 = 1.0 / 4; // done
        double a32 = 1.0 / 4; // done

        double c4 = (7.0 + Math.Sqrt(21.0)) / 14; // done
        double a41 = 1.0 / 7; // done
        double a42 = (-7.0 - 3.0 * Math.Sqrt(21.0)) / 98; // done // typo
        double a43 = (21.0 + 5.0 * Math.Sqrt(21.0)) / 49; // done

        double c5 = (7.0 + Math.Sqrt(21.0)) / 14; // done
        double a51 = (11.0 + Math.Sqrt(21.0)) / 84; // done
        double a52 = 0.0; // done
        double a53 = (18.0 + 4.0 * Math.Sqrt(21.0)) / 63; // done
        double a54 = (21.0 - Math.Sqrt(21.0)) / 252; // done

        double c6 = 1.0 / 2; // done
        double a61 = (5.0 + Math.Sqrt(21.0)) / 48; // done
        double a62 = 0.0; // done
        double a63 = (9.0 + Math.Sqrt(21.0)) / 36; // done
        double a64 = (-231.0 + 14.0 * Math.Sqrt(21.0)) / 360; // done
        double a65 = (63.0 - 7.0 * Math.Sqrt(21.0)) / 80; // done

        double c7 = (7.0 - Math.Sqrt(21.0)) / 14; // done

        double a71 = (10.0 - Math.Sqrt(21.0)) / 42; // done
        double a72 = 0.0; // done
        double a73 = (-432.0 + 92.0 * Math.Sqrt(21.0)) / 315; // done
        double a74 = (633.0 - 145.0 * Math.Sqrt(21.0)) / 90; // done
        double a75 = (-504.0 + 115.0 * Math.Sqrt(21.0)) / 70; // done
        double a76 = (63.0 - 13.0 * Math.Sqrt(21.0)) / 35; // done

        double c8 = (7.0 - Math.Sqrt(21.0)) / 14; // done

        double a81 = 1.0 / 14; // done
        double a82 = 0.0; // done
        double a83 = 0.0; // done
        double a84 = 0.0; // done
        double a85 = (14.0 - 3.0 * Math.Sqrt(21.0)) / 126; // done
        double a86 = (13.0 - 3.0 * Math.Sqrt(21.0)) / 63; // done
        double a87 = 1.0 / 9; // done

        double c9 = 1.0 / 2; // done

        double a91 = 1.0 / 32; // done
        double a92 = 0.0; // done
        double a93 = 0.0; // done
        double a94 = 0.0; // done
        double a95 = (91.0 - 21.0 * Math.Sqrt(21.0)) / 576; // done
        double a96 = 11.0 / 72; // done
        double a97 = (-385.0 - 75.0 * Math.Sqrt(21.0)) / 1152; // done
        double a98 = (63.0 + 13.0 * Math.Sqrt(21.0)) / 128; // done

        double c10 = (7.0 + Math.Sqrt(21.0)) / 14; // done

        double a101 = 1.0 / 14; // done
        double a102 = 0.0; // done
        double a103 = 0.0; // done
        double a104 = 0.0; // done
        double a105 = 1.0 / 9; // done
        double a106 = (-733.0 - 147.0 * Math.Sqrt(21.0)) / 2205; // done
        double a107 = (515.0 + 111.0 * Math.Sqrt(21.0)) / 504; // done
        double a108 = (-51.0 - 11.0 * Math.Sqrt(21.0)) / 56; // done
        double a109 = (132.0 + 28.0 * Math.Sqrt(21.0)) / 245; // done

        double c11 = 1.0; // done

        double a111 = 0.0; // done
        double a112 = 0.0; // done
        double a113 = 0.0; // done
        double a114 = 0.0; // done
        double a115 = (-42.0 + 7.0 * Math.Sqrt(21.0)) / 18; // done
        double a116 = (-18.0 + 28.0 * Math.Sqrt(21.0)) / 45; // done
        double a117 = (-273.0 - 53.0 * Math.Sqrt(21.0)) / 72; // done
        double a118 = (301.0 + 53.0 * Math.Sqrt(21.0)) / 72; // done
        double a119 = (28.0 - 28.0 * Math.Sqrt(21.0)) / 45; // done
        double a1110 = (49.0 - 7.0 * Math.Sqrt(21.0)) / 18; // done

        double b1 = 1.0 / 20; // done
        double b2 = 0.0; // done
        double b3 = 0.0; // done
        double b4 = 0.0; // .0.0.0
        double b5 = 0.0;
        double b6 = 0.0;
        double b7 = 0.0;
        double b8 = 49.0 / 180;
        double b9 = 16.0 / 45;
        double b10 = 49.0 / 180; // .0.0.0
        double b11 = 1.0 / 20; // done

        public DifferentialEquationsSolverRKCV8(DifferentialEquationsBaseClass differentialEquations) : base(differentialEquations)
        { }

        protected override void runge_kutta_step(double interval, double delta_x, double x, double[] y, out double[] term)
        {
            term = new double[numberOfFirstOrderEquations];

            double[] k1 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                k1[i] = differentialEquations[i].function(interval, x, y) * delta_x;
            }

            double[] k2 = new double[numberOfFirstOrderEquations];

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a21;
                }
                k2[i] = differentialEquations[i].function(interval, x + c2 * delta_x, argument) * delta_x;
            }

            double[] k3 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a31 + k2[j] * a32;
                }
                k3[i] = differentialEquations[i].function(interval, x + c3 * delta_x, argument) * delta_x;
            }

            double[] k4 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a41 + k2[j] * a42 + k3[j] * a43;
                }
                k4[i] = differentialEquations[i].function(interval, x + c4 * delta_x, argument) * delta_x;
            }

            double[] k5 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a51 + k2[j] * a52 + k3[j] * a53 + k4[j] * a54;
                }
                k5[i] = differentialEquations[i].function(interval, x + c5 * delta_x, argument) * delta_x;
            }

            double[] k6 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a61 + k2[j] * a62 + k3[j] * a63 + k4[j] * a64 + k5[j] * a65;
                }
                k6[i] = differentialEquations[i].function(interval, x + c6 * delta_x, argument) * delta_x;
            }

            double[] k7 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a71 + k2[j] * a72 + k3[j] * a73 + k4[j] * a74 + k5[j] * a75 + k6[j] * a76;
                }
                k7[i] = differentialEquations[i].function(interval, x + c7 * delta_x, argument) * delta_x;
            }

            double[] k8 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a81 + k2[j] * a82 + k3[j] * a83 + k4[j] * a84 + k5[j] * a85 + k6[j] * a86 + k7[j] * a87;
                }
                k8[i] = differentialEquations[i].function(interval, x + c8 * delta_x, argument) * delta_x;
            }

            double[] k9 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a91 + k2[j] * a92 + k3[j] * a93 + k4[j] * a94 + k5[j] * a95 + k6[j] * a96 + k7[j] * a97 + k8[j] * a98;
                }
                k9[i] = differentialEquations[i].function(interval, x + c9 * delta_x, argument) * delta_x;
            }

            double[] k10 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a101 + k2[j] * a102 + k3[j] * a103 + k4[j] * a104 + k5[j] * a105 + k6[j] * a106 + k7[j] * a107 + k8[j] * a108 + k9[j] * a109;
                }
                k10[i] = differentialEquations[i].function(interval, x + c10 * delta_x, argument) * delta_x;
            }

            double[] k11 = new double[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                double[] argument = new double[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a111 + k2[j] * a112 + k3[j] * a113 + k4[j] * a114 + k5[j] * a115 + k6[j] * a116 + k7[j] * a117 + k8[j] * a118 + k9[j] * a119 + k10[j] * a1110;
                }
                k11[i] = differentialEquations[i].function(interval, x + c11 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i] + b5 * k5[i] + b6 * k6[i] + b7 * k7[i] + b8 * k8[i] + b9 * k9[i] + b10 * k10[i] + b11 * k11[i];
            }

        }

    }
}

