/*
Copyright (C) 2007, 2009, 2010 Gerhard Olsson 

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;
#if !ST_2_1
using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Visuals.Util;
#endif

namespace MiscPlugin.UI.Activities
{
#if ST_2_1
    class EditTrackInfoPage : IActivityDetailPage
#else
    class EditTrackInfoPage : IDetailPage
#endif
    {
#if !ST_2_1
        public EditTrackInfoPage(IDailyActivityView view)
{
    this.view = view;
    view.SelectionProvider.SelectedItemsChanged += new EventHandler(OnViewSelectedItemsChanged);
}

        private void OnViewSelectedItemsChanged(object sender, EventArgs e)
{
    Activity = CollectionUtils.GetSingleItemOfType<IActivity>(view.SelectionProvider.SelectedItems);
    RefreshPage();
}
        public System.Guid Id { get { return new Guid("{5120F4F6-5B89-11DF-9163-0D40E0D72085}"); } }
#endif
#region IActivityDetailPage Members

        public IActivity Activity
        {
            set
            {
                activity = value;
                if (control != null)
                {
                    control.Activity = value;
                }
            }
        }

        public void RefreshPage()
        {
            if (control != null)
            {
                control.RefreshPage();
            }
        }

        public IList<string> MenuPath
        {
            get { return menuPath; }
            set { menuPath = value; OnPropertyChanged("MenuPath"); }
        }

        public bool MenuEnabled
        {
            get { return menuEnabled; }
            set { menuEnabled = value; OnPropertyChanged("MenuEnabled"); }
        }

        public bool MenuVisible
        {
            get { return menuVisible; }
            set { menuVisible = value; OnPropertyChanged("MenuVisible"); }
        }

        public bool PageMaximized
        {
            get { return pageMaximized; }
            set { pageMaximized = value; OnPropertyChanged("PageMaximized"); }
        }
        #endregion

        #region IDialogPage Members

        public Control CreatePageControl()
        {
            if (control == null)
            {
                control = new EditTrackInfoPageControl();
                control.Activity = activity;
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
            get { return Properties.Resources.UI_Activities_PageControl_tmp_Text; }
        }

        public void UICultureChanged(CultureInfo culture)
        {
            if (control != null)
            {
                control.UICultureChanged(culture);
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
        private IActivity activity = null;
        private EditTrackInfoPageControl control = null;

#if !ST_2_1
        private IDailyActivityView view = null;
#endif
        private IList<string> menuPath = null;
        private bool menuEnabled = true;
        private bool menuVisible = true;
        private bool pageMaximized = false;

        #endregion
    }
}
