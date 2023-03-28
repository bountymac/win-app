﻿/*
 * Copyright (c) 2023 Proton AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */


using System.Diagnostics;

namespace ProtonVPN.Common.OS.Event
{
    public class SystemEventLog
    {
        private const string Source = "ProtonVPN";

        public void Log(string message, int eventId)
        {
            EnsureEventSourceExists();

            var log = new EventLog {Source = Source};

            log.WriteEntry(message, EventLogEntryType.Information, eventId);
        }

        private void EnsureEventSourceExists()
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }
        }
    }
}
