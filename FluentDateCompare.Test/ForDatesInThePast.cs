using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentDateCompare;

namespace FluentDateCompare.Test
{
    [TestFixture]
    public class ForDatesInThePast
    {
        private void SetTime()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(2015, 1, 1));
        }

        [SetUp]
        public void Setup()
        {
            SetTime();
        }

        [Test]
        public void ADateOver18YearsCanBeCompared()
        {
            Assert.IsTrue(new DateTime(1901, 1, 1).Is().EarlierThan.Years(18).Ago());
        }

        [Test]
        public void ADateUnder18YearsIsFalse()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(1902, 1, 1));
            Assert.IsFalse(new DateTime(1901, 1, 1).Is().EarlierThan.Years(18).Ago());
        }

        [Test]
        public void ADateYoungerThan18MonthsIsTrue()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(1902, 1, 1));
            Assert.IsTrue(new DateTime(1901, 1, 1).Is().LaterThan.Months(18).Ago());
        }

        [Test]
        public void ADateYoungerThan18DaysBeforeIsTrue()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(2002, 1, 1));
            Assert.IsTrue(new DateTime(1901, 1, 1).Is().LaterThan.Days(18).Before(new DateTime(1901, 1, 5)));
        }
    }
}