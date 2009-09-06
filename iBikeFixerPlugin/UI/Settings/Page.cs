/*
Copyright (C) 2007 Gerhard Olsson 

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using IBikeFixerPlugin.Resources;

namespace IBikeFixerPlugin.UI.Settings
{
    class Page : ISettingsPage
    {
        #region ISettingsPage Members

        public Control CreatePageControl()
        {
            if (control == null)
            {
                control = new PageControl();
            }
            return control;
        }

        public bool HidePage()
        {
            return true;
        }

        public string PageName
        {
            get { return Title; }
        }

        public void ShowPage(string bookmark)
        {
        }

        public IPageStatus Status
        {
            get { return null; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            if (control != null)
            {
                control.ThemeChanged(visualTheme);
            }
        }

        public string Title
        {
            get {
                return Resources.Resources.UI_Settings_Page_Title;
            }
        }

        public void UICultureChanged(CultureInfo culture)
        {
            if (control != null)
            {
                control.UICultureChanged(culture);
            }
        }

        public IList<ISettingsPage> SubPages { 
            get
            {
                return null;
            } 
        }
        public Guid Id
        {
            
            get {
                Resources.Plugin plugin = new Resources.Plugin(); 
                return plugin.Id;
            }
        }


        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Private members
        private PageControl control = null;
        #endregion
    }
}
