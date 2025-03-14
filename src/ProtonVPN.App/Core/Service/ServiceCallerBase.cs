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

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ProtonVPN.Common.Abstract;
using ProtonVPN.ProcessCommunication.Contracts.Controllers;

namespace ProtonVPN.Core.Service
{
    public abstract class ServiceCallerBase<TController>
        where TController : IServiceController
    {
        private readonly IServiceControllerCaller _serviceControllerCaller;

        public ServiceCallerBase(IServiceControllerCaller serviceControllerCaller)
        {
            _serviceControllerCaller = serviceControllerCaller;
        }

        protected Task<Result<Task>> InvokeAsync(Func<TController, CancellationToken, Task<Task>> serviceCall, [CallerMemberName] string memberName = "")
        {
            return _serviceControllerCaller.InvokeAsync(serviceCall, memberName);
        }

        protected Task<Result<TResult>> InvokeAsync<TResult>(Func<TController, CancellationToken, Task<TResult>> serviceCall, [CallerMemberName] string memberName = "")
        {
            return _serviceControllerCaller.InvokeAsync(serviceCall, memberName);
        }
    }
}