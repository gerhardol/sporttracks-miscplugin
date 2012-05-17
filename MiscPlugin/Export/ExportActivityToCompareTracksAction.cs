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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
#if !ST_2_1
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Visuals.Util;
#endif

namespace MiscPlugin.Edit
{
    class ExportActivityToCompareTracksAction : IAction
    {
#if !ST_2_1
        public ExportActivityToCompareTracksAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public ExportActivityToCompareTracksAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
#endif
        public ExportActivityToCompareTracksAction(IList<IActivity> activities)
        {
            this.activities = activities;
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null && activity.GPSRoute.Count > 0)
                {
                    return false;
                    //TODO return true;
                }
            return false;
        }

        #region IAction Members

        public bool Enabled
        {
            get
            {
                Boolean enabled = true;
                foreach (IActivity activity in activities)
                {
                    if (isEnabled(activity))
                    {
                        enabled = true;
                        break;
                    }
                }
                return enabled;
            }
        }

        public bool HasMenuArrow
        {
            get { return false; }
        }

        public Image Image
        {
            get { return null; }
//            get { return Properties.Resources.Image_16_CT; }
        }
        public IList<string> MenuPath
        {
            get
            {
                return new List<string> { Properties.Resources.Edit_MiscPluginPath_Title };
            }
        }
        public void Refresh()
        {
        }

        public void Run(Rectangle rectButton)
        {
#if false
		            if (false)
            {
                //TODO: Not yet implemented
                string tmpDir = System.Environment.GetEnvironmentVariable("TEMP");
                string ctDir = System.Environment.GetEnvironmentVariable("TEMP");
                //string ctDir = "C:\\Program Files\\CompareTracks\\Db\\";
                //int ctActNo = 1;
                //int ctFileNo = 1;
                String ctTrkDb = ctDir + "MsTrip.txt";

                StreamReader reader = new StreamReader(ctTrkDb);
                String tmp = null;
                try
                {
                    do
                    {
                        //Read until last line
                        tmp = reader.ReadLine();
                    }
                    while (reader.Peek() != -1);
                }

                catch
                {
                    //addListItem("Cannot find CompareTracks DB file:" + ctTrkDb);
                    //               string pattern = 
                    //	@"^(?<ctactno>.{5})";
                    //	Match ma = re.Match(sr.ReadLine());
                    //	Console.Write("First name = " +
                    //        ma.Groups["ctactno"].Value.TrimEnd());

                }

                finally
                {
                    reader.Close();
                    //parse for last line
                }
                string[] files = Directory.GetFiles(ctDir + "Track\\track*.txt");
                foreach (string i in files)
                {
                    //Do not assume files are sorted, just get the largest number
                }

                foreach (IActivity activity in activities)
                {
                    FileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "GPS eXchange Files(*.gpx)|*.gpx|All files|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Export(dialog.FileName);
                            MessageBox.Show("Done!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            foreach (IActivity activity in activities)
            {
                FileDialog dialog2 = new SaveFileDialog();
                dialog2.Filter = "Distance Files(*.csv)|*.csv|All files|*.*";
                if (dialog2.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Export(dialog2.FileName, activity);
                        MessageBox.Show("Done!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Export(string filename, IActivity activity)
        {
            TextWriter writer = new StreamWriter(filename);
            
            int g = 0;

            for (g = 0; g < activity.DistanceMetersTrack.Count ; g++)
            {
                writer.WriteLine(activity.DistanceMetersTrack.EntryDateTime(activity.DistanceMetersTrack[g]).ToString() + "; " +
                    activity.DistanceMetersTrack[g].Value);
            }
            writer.Close();
  
#endif        
        }
        public string Title
        {
            get { return Properties.Resources.Edit_ExportActivityToCompareTracks_Text; }
        }
        public bool Visible
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

#if !ST_2_1
        private IDailyActivityView dailyView = null;
        private IActivityReportsView reportView = null;
#endif
        //private int outputFormat = 0;
        private IList<IActivity> _activities = null;
        private IList<IActivity> activities
        {
            get
            {
#if !ST_2_1
                //activities are set either directly or by selection,
                //not by more than one
                if (_activities == null)
                {
                    if (dailyView != null)
                    {
                        return CollectionUtils.GetAllContainedItemsOfType<IActivity>(dailyView.SelectionProvider.SelectedItems);
                    }
                    else if (reportView != null)
                    {
                        return CollectionUtils.GetAllContainedItemsOfType<IActivity>(reportView.SelectionProvider.SelectedItems);
                    }
                    else
                    {
                        return new List<IActivity>();
                    }
                }
#endif
                return _activities;
            }
            set
            {
                _activities = value;
            }
        }
    }
}
