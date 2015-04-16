using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentDateCompare;

namespace FluentDateCompare.Test
{
    [TestFixture]
    public class ForDatesInTheFuture
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
            Assert.IsTrue(new DateTime(3001, 1, 1).Is().LaterThan.Years(18).Hence());
        }

        [Test]
        public void ADateUnder18YearsIsFalse()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(1901, 1, 1));
            Assert.IsFalse(new DateTime(1902, 1, 1).Is().LaterThan.Years(18).Hence());
        }

        [Test]
        public void ADateYoungerThan18MonthsIsTrue()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(1901, 1, 1));
            Assert.IsTrue(new DateTime(1902, 1, 1).Is().EarlierThan.Months(18).Hence());
        }

        [Test]
        public void ADateYoungerThan18DaysBeforeIsTrue()
        {
            FluentDateCompare.SetCurrentTime(() => new DateTime(2002, 1, 1));
            Assert.IsTrue(new DateTime(1901, 1, 5).Is().EarlierThan.Days(18).After(new DateTime(1901, 1, 1)));
        }
    }
}
