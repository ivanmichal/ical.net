﻿using System;
using Ical.Net.Interfaces.Components;
using Ical.Net.Interfaces.Evaluation;
using Ical.Net.Interfaces.General;

namespace Ical.Net.Interfaces
{
    public interface ICalendar : ICalendarComponent, IGetOccurrencesTyped, IGetFreeBusy, IMergeable
    {
        /// <summary>
        /// Gets/sets the calendar version.  Defaults to "2.0".
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// Gets/sets the product ID for the calendar.
        /// </summary>
        string ProductId { get; set; }

        /// <summary>
        /// Gets/sets the scale of the calendar.
        /// </summary>
        string Scale { get; set; }

        /// <summary>
        /// Gets/sets the calendar method.
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// Gets/sets the restriction on how evaluation of 
        /// recurrence patterns occurs within this calendar.
        /// </summary>
        RecurrenceRestrictionType RecurrenceRestriction { get; set; }

        /// <summary>
        /// Gets/sets the evaluation mode during recurrence
        /// evaluation.  Default is ThrowException.
        /// </summary>
        RecurrenceEvaluationModeType RecurrenceEvaluationMode { get; set; }

        /// <summary>
        /// Creates a new component, and adds it
        /// to the calendar.
        /// </summary>
        T Create<T>() where T : ICalendarComponent;

        /// <summary>
        /// Returns the time zone object that corresponds
        /// to the provided TZID, or null of no matching
        /// time zone could be found.
        /// </summary>
        ITimeZone GetTimeZone(string tzId);

        /// <summary>
        /// Gets a list of unique components contained in the calendar.
        /// </summary>
        IUniqueComponentList<IUniqueComponent> UniqueComponents { get; }

        /// <summary>
        /// Gets a list of Events contained in the calendar.
        /// </summary>
        IUniqueComponentList<IEvent> Events { get; }

        /// <summary>
        /// Gets a list of Free/Busy components contained in the calendar.
        /// </summary>
        IUniqueComponentList<IFreeBusy> FreeBusy { get; }

        /// <summary>
        /// Gets a list of Journal entries contained in the calendar.
        /// </summary>
        ICalendarObjectList<IJournal> Journals { get; }

        /// <summary>
        /// Gets a list of time zones contained in the calendar.
        /// </summary>
        ICalendarObjectList<ITimeZone> TimeZones { get; }

        /// <summary>
        /// Gets a list of To-do items contained in the calendar.
        /// </summary>
        IUniqueComponentList<ITodo> Todos { get; }


        /// <summary>
        /// Adds a system time zone to the iCalendar.  This time zone may
        /// then be used in date/time objects contained in the 
        /// calendar.
        /// </summary>
        /// <param name="tzi">A System.TimeZoneInfo object to add to the calendar.</param>
        /// <returns>The time zone added to the calendar.</returns>
        ITimeZone AddTimeZone(TimeZoneInfo tzi);

        ITimeZone AddTimeZone(TimeZoneInfo tzi, DateTime earliestDateTimeToSupport, bool includeHistoricalData);

        /// <summary>
        /// Adds the local system time zone to the iCalendar.  
        /// This time zone may then be used in date/time
        /// objects contained in the calendar.
        /// </summary>
        /// <returns>The time zone added to the calendar.</returns>
        ITimeZone AddLocalTimeZone();

        ITimeZone AddLocalTimeZone(DateTime earliestDateTimeToSupport, bool includeHistoricalData);
    }
}