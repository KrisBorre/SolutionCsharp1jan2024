﻿using LibraryDifferentialEquations1jan2024;

namespace LibraryHarmonicOscillatorVelocity14feb2024
{
    internal class DifferentialEquation2 : DifferentialEquationBaseClass
    {
        private SpringManager spring_manager;
        private MassManager mass_manager;

        public DifferentialEquation2(SpringManager spring, MassManager mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override double function(double interval, double x, params double[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            double k = spring_manager.GetSpring(interval, x);
            double m = mass_manager.GetMass(interval, x);

            return -(k / m) * y[0];
        }
    }
}
