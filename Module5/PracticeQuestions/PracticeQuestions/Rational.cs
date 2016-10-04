using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class Rational
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public void Add(Rational other)
        {
            int commonDenominator = Denominator * other.Denominator;
            Numerator = Numerator * other.Denominator + other.Numerator * Denominator;
            Denominator = commonDenominator;
        }
    }
}
