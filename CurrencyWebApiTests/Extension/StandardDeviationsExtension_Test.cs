using System;
using System.Collections.Generic;
using CurrencyWebApi.Extensions;
using NUnit.Framework;

namespace CurrencyWebApiTests.Extension
{
    public class StandardDeviationExtensionTests
    {
      
       [Test]
        public void std_dev_for_double_test()
        {
            var list = new List<double>() {300,300,300,300,300,300,400,400,400,400,400,400};
            var ret = list.StandardDeviation();
            Assert.That(ret,Is.EqualTo(50));
        }


        [Test]
        public void std_dev_for_double_with_function_test()
        {
            var list = new List<double>() { 300, 300, 300, 300, 300, 300, 400, 400, 400, 400, 400, 400 };
            var ret = list.StandardDeviation(a=>a);
            Assert.That(ret, Is.EqualTo(50));
        }

        [Test]
        public void std_dev_for_empty_list()
        {
            var list = new List<double>();
            var ret = list.StandardDeviation();
            Assert.That(ret, Is.EqualTo(0));
        }

        [Test]
        public void std_dev_for_eur_rate_test()
        {
            var list = new List<double>() { 4.2135, 4.2461, 4.237, 4.2409 };
            var ret = list.StandardDeviation();
            ret = Math.Round(ret, 4);
            Assert.That(ret, Is.EqualTo(0.0125));
        }
    }
}