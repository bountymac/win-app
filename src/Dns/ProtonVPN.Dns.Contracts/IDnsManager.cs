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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProtonVPN.Common.Networking;

namespace ProtonVPN.Dns.Contracts
{
    public interface IDnsManager
    {
        /// <summary>Returns the cached IP addresses if they are fresh, otherwise resolves for new ones.
        /// If the resolve fails, returns the cached IP addresses.</summary>
        Task<IList<IpAddress>> GetAsync(string host, CancellationToken cancellationToken);
        
        /// <summary>Resolves for IP addresses.
        /// Doesn't check cache and doesn't return cached IP addresses in case of failure.</summary>
        Task<IList<IpAddress>> ResolveWithoutCacheAsync(string host, CancellationToken cancellationToken);
        
        /// <summary>Returns the cached IP addresses.</summary>
        IList<IpAddress> GetFromCache(string host);
    }
}