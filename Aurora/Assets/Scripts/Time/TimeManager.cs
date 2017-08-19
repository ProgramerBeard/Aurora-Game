using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public WorldTime curTime;

    public void ProgressDay()
    {
        curTime.UpdateTime();
    }

    public void SkipToDate(int newDate)
    {
        int years;
        int day;

        int dayCount = newDate;

        int iterationCount = 1;
        int leapCount = 0;

        while (dayCount > 365)
        {
            iterationCount++;

            if (iterationCount % 4 == 0)
            {
                leapCount++;
            }

            dayCount -= 1;
        }

        years = newDate / 365;
        day = newDate % 365;

        day += leapCount;

        curTime.UpdateTime(WorldTime.DayParts.MORNING, day, years);
    }

    [System.Serializable]
    public class WorldTime
    {
        public enum DayParts
        {
            MORNING,
            AFTERNOON,
            EVENING,
            NIGHT}

        ;

        public enum DaysOfWeek
        {
            MONDAY,
            TUESDAY,
            WENDSDAY,
            THURSDAY,
            FRIDAY,
            SATERDAY,
            SUNDAY}

        ;

        public enum Months
        {
            JANUARY,
            FEBURARY,
            MARCH,
            APRIL,
            MAY,
            JUNE,
            JULY,
            AUGUST,
            SEPTEMBER,
            OCTOBER,
            NOVMBER,
            DECMBER}

        ;

        public DayParts dayPart;
        public DaysOfWeek dayOfWeek;
        public Months month;

        public int day = 1;
        public int year = 0;

        // Used to update the time in game. Used when you want to update the time by event.
        public void UpdateTime()
        {
            if (dayPart == DayParts.NIGHT)
            {
                year = UpdateYear(year);
                month = UpdateMonth(month);
                dayOfWeek = UpdateDayOfWeek(dayOfWeek);
                dayPart = UpdateDayPart(dayPart);
                day++;
            }
            else
            {
                dayPart = UpdateDayPart(dayPart);
            }
        }

        // Used to update the in game time. Use when you want to skip large amounts of time.
        // NOTE: The value to add onto day should be in the range of [1, 365] or [1, 366] if the year is a leap year.
        // NOTE: One should use temp vars to caluated the years and days so that way you know if the year you input is going to be a
        // leap year or not.
        public void UpdateTime(DayParts newDayPart, int daysToAdd, int yearsToAdd)
        {
            int newYearCount = yearsToAdd + year;

            if (IsLeapYear(newYearCount))
            {
                if (daysToAdd > 366)
                {
                    Debug.LogError("The days to add (" + daysToAdd + ") is not in the range of (1, 366). This is because " + newYearCount + " is a leap year.");
                    return;
                }
            }

            if (daysToAdd > 365)
            {
                Debug.LogError("The days to add (" + daysToAdd + ") is not in the range of (1, 365).");
                return;
            }

            int newDayCount = daysToAdd + day;

            bool isLeapYear = false;
            if (year % 4 == 0)
            {
                isLeapYear = true;
            }
            Months newMonth = GetMonthFromDay(newDayCount, isLeapYear);

            DaysOfWeek newDayOfWeek = GetDayOfWeekFromDay(newDayCount);

            year = newYearCount;
            month = newMonth;
            dayOfWeek = newDayOfWeek;
            day = newDayCount;
            dayPart = newDayPart;
        }

        public string GetAsString()
        {
            return dayPart.ToString() + "-" + GetDayProperCase(dayOfWeek) + "( " + GetDayInMonth() + ") , " + month.ToString() + ", " + year;
        }

        public string GetDayProperCase(DaysOfWeek _day)
        {
            string dayString = _day.ToString().ToLower();

            return dayString.Substring(0, 1).ToUpper() + dayString.Substring(1);
        }

        public int GetDayInMonth()
        {
            if (month == Months.JANUARY || month == Months.MARCH || month == Months.MAY || month == Months.JULY || month == Months.AUGUST || month == Months.OCTOBER || month == Months.DECMBER)
            {
                return day % 31;
            }
            else if (month == Months.APRIL || month == Months.JUNE || month == Months.SEPTEMBER || month == Months.NOVMBER)
            {
                return day % 30;
            }
            else
            {
                if (IsLeapYear(year))
                {
                    return day % 29;
                }
                else
                {
                    return day % 28;
                }
            }
        }

        public DaysOfWeek GetDayOfWeekFromDay(int _day)
        {
            if (_day % 7 == 0)
            {
                return DaysOfWeek.SUNDAY;
            }
            else if (_day % 6 == 0)
            {
                return DaysOfWeek.SATERDAY;
            }
            else if (_day % 5 == 0)
            {
                return DaysOfWeek.FRIDAY;
            }
            else if (_day % 4 == 0)
            {
                return DaysOfWeek.THURSDAY;
            }
            else if (_day % 3 == 0)
            {
                return DaysOfWeek.WENDSDAY;
            }
            else if (_day % 2 == 0)
            {
                return DaysOfWeek.TUESDAY;
            }
            else if (_day % 1 == 0)
            {
                return DaysOfWeek.MONDAY;
            }
            else
            {
                Debug.LogError("There was an error, " + _day + " is not a proper day");
                return DaysOfWeek.MONDAY;
            }
        }

        public Months GetMonthFromDay(int _day, bool isLeapYear)
        {
            int mi;
            int mm;

            if (isLeapYear)
            {
                mi = (100 * (_day + 1) + 52) / 3060;
                mm = (mi + 2) % 12 + 1;

                return GetMonthFromNumber(mm);
            }
            else
            {
                mi = (100 * _day + 52) / 3060;
                mm = (mi + 2) % 12 + 1;

                return GetMonthFromNumber(mm);
            }
        }

        private int UpdateYear(int _year)
        {
            if (IsLeapYear(_year))
            {
                if (day % 366 == 0)
                {
                    _year++;	
                }
            }
            else
            {
                if (day % 365 == 0)
                {
                    _year++;
                }
            }

            return _year;
        }

        private DayParts UpdateDayPart(DayParts _dayPart)
        {
            return GetNextDayPart(_dayPart);
        }

        private DaysOfWeek UpdateDayOfWeek(DaysOfWeek _dayOfWeek)
        {
            return GetNextDayOfWeek(_dayOfWeek);
        }

        private Months UpdateMonth(Months _month)
        {
            if (_month == Months.JANUARY || _month == Months.MARCH || _month == Months.MAY || _month == Months.JULY || _month == Months.AUGUST || _month == Months.OCTOBER || _month == Months.DECMBER)
            {
                if (day % 31 == 0)
                {
                    _month = GetNextMonth(_month);
                }
            }
            else if (_month == Months.APRIL || _month == Months.JUNE || _month == Months.SEPTEMBER || _month == Months.NOVMBER)
            {
                if (day % 30 == 0)
                {
                    _month = GetNextMonth(month);
                }
            }
            else
            {
                if (IsLeapYear(year))
                {
                    if (day % 29 == 0)
                    {
                        _month = GetNextMonth(month);
                    }
                    else if (day % 28 == 0)
                    {
                        _month = GetNextMonth(month);
                    }
                }
            }

            return _month;
        }

        private Months GetMonthFromNumber(int number)
        {
            if (number == 3)
            {
                return Months.JANUARY;
            }
            else if (number == 4)
            {
                return Months.FEBURARY;
            }
            else if (number == 5)
            {
                return Months.MARCH;
            }
            else if (number == 6)
            {
                return Months.APRIL;
            }
            else if (number == 7)
            {
                return Months.MAY;
            }
            else if (number == 8)
            {
                return Months.JUNE;
            }
            else if (number == 9)
            {
                return Months.JULY;
            }
            else if (number == 10)
            {
                return Months.AUGUST;
            }
            else if (number == 11)
            {
                return Months.SEPTEMBER;
            }
            else if (number == 12)
            {
                return Months.OCTOBER;
            }
            else if (number == 1)
            {
                return Months.NOVMBER;
            }
            else if (number == 2)
            {
                return Months.DECMBER;
            }
            else
            {
                Debug.LogError("The inputed number is wrong: " + number);
                return Months.JANUARY;
            }
        }

        private Months GetNextMonth(Months curMonth)
        {
            switch (curMonth)
            {
                case Months.JANUARY:
                    return Months.FEBURARY;
                case Months.FEBURARY:
                    return Months.MARCH;
                case Months.MARCH:
                    return Months.APRIL;
                case Months.APRIL:
                    return Months.MAY;
                case Months.MAY:
                    return Months.JUNE;
                case Months.JUNE:
                    return Months.JULY;
                case Months.JULY:
                    return Months.AUGUST;
                case Months.AUGUST:
                    return Months.SEPTEMBER;
                case Months.SEPTEMBER:
                    return Months.OCTOBER;
                case Months.NOVMBER:
                    return Months.DECMBER;
                case Months.DECMBER:
                    return Months.JANUARY;
                default:
                    Debug.LogError(curMonth.ToString() + ": is not a valid month");
                    return Months.JANUARY;
            }
        }

        private DaysOfWeek GetNextDayOfWeek(DaysOfWeek curDayOfWeek)
        {
            switch (curDayOfWeek)
            {
                case DaysOfWeek.MONDAY:
                    return DaysOfWeek.TUESDAY;
                case DaysOfWeek.TUESDAY:
                    return DaysOfWeek.WENDSDAY;
                case DaysOfWeek.WENDSDAY:
                    return DaysOfWeek.THURSDAY;
                case DaysOfWeek.THURSDAY:
                    return DaysOfWeek.FRIDAY;
                case DaysOfWeek.FRIDAY:
                    return DaysOfWeek.SATERDAY;
                case DaysOfWeek.SATERDAY:
                    return DaysOfWeek.SUNDAY;
                case DaysOfWeek.SUNDAY:
                    return DaysOfWeek.MONDAY;
                default:
                    Debug.LogError(curDayOfWeek.ToString() + ": is not a valid day of the week");
                    return DaysOfWeek.MONDAY;
            }
        }

        private DayParts GetNextDayPart(DayParts curDayPart)
        {
            switch (curDayPart)
            {
                case DayParts.MORNING:
                    return DayParts.AFTERNOON;
                case DayParts.AFTERNOON:
                    return DayParts.EVENING;
                case DayParts.EVENING:
                    return DayParts.NIGHT;
                case DayParts.NIGHT:
                    return DayParts.MORNING;
                default:
                    Debug.LogError(curDayPart.ToString() + ": is not a valid day part");
                    return DayParts.MORNING;	
            }
        }

        private bool IsLeapYear(int _year)
        {
            if (_year % 4 == 0)
            {
                return true;
            }
            else if (_year % 100 == 0)
            {
                return true;
            }
            else if (_year % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}