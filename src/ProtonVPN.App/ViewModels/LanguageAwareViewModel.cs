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
using System.ComponentModel;
using System.Windows;
using Caliburn.Micro;
using ProtonVPN.Core.Settings;
using ProtonVPN.Translations;

namespace ProtonVPN.ViewModels
{
    public class LanguageAwareViewModel : Screen, ISettingsAware
    {
        private readonly List<string> _rightToLeftLanguages = new() {"fa"};

        public FlowDirection FlowDirection =>
            _rightToLeftLanguages.Contains(TranslationSource.Instance.CurrentCulture.TwoLetterISOLanguageName)
                ? FlowDirection.RightToLeft
                : FlowDirection.LeftToRight;

        public virtual void OnAppSettingsChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(IAppSettings.Language)))
            {
                NotifyOfPropertyChange(() => FlowDirection);
            }
        }
    }
}