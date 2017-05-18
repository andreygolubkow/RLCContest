using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Elements;

using NUnit.Framework;
using System.Numerics;

using NUnit.Framework.Internal;

namespace CoreTest
{
    [Ignore("Не закончен класс тестирования.")]
    [TestFixture]
    public class ElementsTest
    {
        [Test]
        [TestCase(1,1,ExpectedResult  = 1)]
        public double Test_capasitor(double value, double frequency)
        {
            var capasitor = new Capacitor()
                            {
                                Value = value
                            };
            if ( Math.Abs(capasitor.CalculateZ(frequency).Real) > 0 )
            {
                throw new Exception("При тестировании Capasitor обнаружено действительное значение.");
            }
            return capasitor.CalculateZ(frequency).Imaginary;
        }

        [Test]
        [TestCase(1, 1, ExpectedResult = 1)]
        public double Test_inductor(double value, double frequency)
        {
            var inductor = new Inductor
                            {
                                Value = value
                            };
            if (Math.Abs(inductor.CalculateZ(frequency).Real) > 0)
            {
                throw new Exception("При тестировании Inductor обнаружено действительное значение.");
            }
            return inductor.CalculateZ(frequency).Imaginary;
        }

    }
}
