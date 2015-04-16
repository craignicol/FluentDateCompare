using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDateCompare
{
    public class FluentDateCompare
    {
        public enum ComparisonType
        {
            Unknown,
            EarlierThan,
            LaterThan
        }

        private ComparisonType comparisonType = ComparisonType.Unknown;
        static private Func<DateTime> CurrentTime = () => DateTime.Today;
        static public void SetCurrentTime(Func<DateTime> currentTime)
        {
            CurrentTime = currentTime;
        }

        public FluentDateCompare EarlierThan
        {
            get
            {
                comparisonType = ComparisonType.EarlierThan;
                return this;
            }
        }
        public FluentDateCompare LaterThan
        {
            get
            {
                comparisonType = ComparisonType.LaterThan;
                return this;
            }
        }
        private int DayCount;
        private DateTime inputDate;
        private bool InvertSum;
        private int MonthCount;
        private int YearCount;
        public FluentDateCompare Days(int dayCount)
        {
            DayCount = dayCount;
            return this;
        }

        public FluentDateCompare Months(int monthCount)
        {
            MonthCount = monthCount;
            return this;
        }
        public FluentDateCompare Years(int yearCount)
        {
            YearCount = yearCount;
            return this;
        }
        public FluentDateCompare(DateTime inputDate)
        {
            this.inputDate = inputDate;
        }
        private DateTime ComparisonDate(DateTime originalTime)
        {
            return (originalTime
                .AddYears(YearCount * (InvertSum ? -1 : 1))
                .AddMonths(MonthCount * (InvertSum ? -1 : 1))
                .AddDays(DayCount * (InvertSum ? -1 : 1)));
        }
        private bool CompareDates(DateTime originalTime)
        {
            DateTime comparisonDate = ComparisonDate(originalTime);
            if (comparisonType == ComparisonType.EarlierThan)
            {
                return inputDate < comparisonDate;
            }
            else if (comparisonType == ComparisonType.LaterThan)
            {
                return inputDate > comparisonDate;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public bool Ago()
        {
            return Before(CurrentTime());
        }
        public bool Before(DateTime dateTime)
        {
            InvertSum = true;
            return CompareDates(dateTime);
        }
        public bool Hence()
        {
            return After(CurrentTime());
        }
        public bool After(DateTime dateTime)
        {
            InvertSum = false;
            return CompareDates(dateTime);
        }
    }
}
