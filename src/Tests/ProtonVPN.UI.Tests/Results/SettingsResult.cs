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

using FlaUI.Core.AutomationElements;
using NUnit.Framework;
using ProtonVPN.UI.Tests.TestsHelper;

namespace ProtonVPN.UI.Tests.Results
{
    public class SettingsResult : UIActions
    {
        private CheckBox ModerateNatCheckBox => ElementByAutomationId("ModerateNatCheckbox").AsCheckBox();

        private string WireguardDnsAdress => NetworkUtils.GetDnsAddress("ProtonVPN");
        private string OpenVpnDnsAdress => NetworkUtils.GetDnsAddress("ProtonVPN TUN");

        public SettingsResult CheckIfSettingsAreDisplayed()
        {
            WaitUntilElementExistsByName("Start Minimized", TestData.VeryShortTimeout);
            WaitUntilElementExistsByName("Start on boot", TestData.VeryShortTimeout);
            WaitUntilElementExistsByName("Connect on app start", TestData.VeryShortTimeout);
            WaitUntilElementExistsByName("Show Notifications", TestData.VeryShortTimeout);
            WaitUntilElementExistsByName("Early Access", TestData.VeryShortTimeout);
            return this;
        }

        public SettingsResult CheckIfCustomDnsAddressWasNotAdded()
        {
            CheckIfDoesNotExistByAutomationId("DeleteButton");
            return this;
        }

        public SettingsResult CheckIfDnsAddressMatches(string expectedDnsAddress)
        {
            Assert.That(DoesContainDnsAddress(expectedDnsAddress), Is.True, DnsAdressErrorMessage(expectedDnsAddress));
            return this;
        }

        public SettingsResult CheckIfDnsAddressDoesNotMatch(string expectedDnsAddress)
        {
            Assert.That(DoesContainDnsAddress(expectedDnsAddress), Is.False, DnsAdressErrorMessage(expectedDnsAddress));
            return this;
        }

        public SettingsResult CheckIfModerateNatIsEnabled()
        {
            Assert.That(ModerateNatCheckBox.IsChecked.Value, Is.True, "Moderate NAT checkbox status is: " + ModerateNatCheckBox.IsChecked.Value);
            return this;
        }

        public SettingsResult CheckIfModerateNatIsDisabled()
        {
            Assert.That(ModerateNatCheckBox.IsChecked.Value, Is.False, "Moderate NAT checkbox status is: " + ModerateNatCheckBox.IsChecked.Value);
            return this;
        }

        private string DnsAdressErrorMessage(string expectedDnsAddress)
        {
            return $"Wireguard dns address: {WireguardDnsAdress}. OpenVPN dns address: {OpenVpnDnsAdress}. Expected dns value: {expectedDnsAddress}";
        }

        private bool DoesContainDnsAddress(string expectedDnsAddress)
        {
            return WireguardDnsAdress == expectedDnsAddress || OpenVpnDnsAdress == expectedDnsAddress;
        }
    }
}
