/*
Copyright (C) 2007, 2009 Gerhard Olsson 

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
using System.Text;
using System.Xml;

using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MiscPlugin
{

    class Plugin : IPlugin
    {
        #region IPlugin Members
        //http://www.guidgen.com/ {d8bd1522-d1b0-11db-9705-005056c00008}
        public Guid Id
        {
            get { return new Guid("{d8bd1522-d1b0-11db-9705-005056c00008}"); }
        }
        public string Name
        {
            get { return "Miscellaneous Utilities Plugin"; }
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(3); }
        }


        public IApplication Application
        {
            set { application = value; }
        }

        public static IApplication GetApplication()
        {
            return application;
        }

        public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
            String attr;

            attr = pluginNode.GetAttribute(xmlTags.AdjustPausesToDeviceAtImport);
            if (attr.Length > 0) { AdjustPausesToDeviceAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.AdjustPausesToDeviceEditMenu);
            if (attr.Length > 0) { AdjustPausesToDeviceEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsAtImport);
            if (attr.Length > 0) { DetectRestLapsAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsEditMenu);
            if (attr.Length > 0) { DetectRestLapsEditMenu = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsAlternativeAlgorithm);
            if (attr.Length > 0) { DetectRestLapsAlternativeAlgorithm = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsLapDistance);
            if (attr.Length > 0) { DetectRestLapsLapDistance = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsSlowSpeedFactor);
            if (attr.Length > 0) { DetectRestLapsSlowSpeedFactor = (float)XmlConvert.ToDouble(attr); }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsSpeedFactor);
            if (attr.Length > 0) { DetectRestLapsSpeedFactor = (float)XmlConvert.ToDouble(attr); }

            attr = pluginNode.GetAttribute(xmlTags.ElevationToGPSAtImport);
            if (attr.Length > 0) { ElevationToGPSAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.ElevationToGPSEditMenu);
            if (attr.Length > 0) { ElevationToGPSEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.ExtendGPSAtImport);
            if (attr.Length > 0) { ExtendGPSAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.ExtendGPSEditMenu);
            if (attr.Length > 0) { ExtendGPSEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.FixHRAtImport);
            if (attr.Length > 0) { FixHRAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.FixHREditMenu);
            if (attr.Length > 0) { FixHREditMenu = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.FixHRStartHR);
            if (attr.Length > 0) { FixHRStartHR = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.FixHRTruncateHR);
            if (attr.Length > 0) { FixHRTruncateHR = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.FixHRCheckSeconds);
            if (attr.Length > 0) { FixHRCheckSeconds = XmlConvert.ToInt16(attr); }

            attr = pluginNode.GetAttribute(xmlTags.FixNaNEditMenu);
            if (attr.Length > 0) { FixNaNEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.InsertPausesAtImport);
            if (attr.Length > 0) { InsertPausesAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesEditMenu);
            if (attr.Length > 0) { InsertPausesEditMenu = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesWhenGPSdifferMinSeconds);
            if (attr.Length > 0) { InsertPausesWhenGPSdifferMinSeconds = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesAdjacentCheckSeconds);
            if (attr.Length > 0) { InsertPausesAdjacentCheckSeconds = XmlConvert.ToInt16(attr); }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesGPSOffsetSeconds);
            if (attr.Length > 0) { InsertPausesGPSOffsetSeconds = XmlConvert.ToInt16(attr); }

            attr = pluginNode.GetAttribute(xmlTags.Laps2CadenceEditMenu);
            if (attr.Length > 0) { Laps2CadenceEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.RemoveIdenticalGPSAtImport);
            if (attr.Length > 0) { RemoveIdenticalGPSAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.RemoveIdenticalGPSEditMenu);
            if (attr.Length > 0) { RemoveIdenticalGPSEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.SetTimeGPSAtImport);
            if (attr.Length > 0) { SetTimeGPSAtImport = XmlConvert.ToBoolean(attr); }
            attr = pluginNode.GetAttribute(xmlTags.SetTimeGPSEditMenu);
            if (attr.Length > 0) { SetTimeGPSEditMenu = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.SetUseEnteredDataAtImport);
            if (attr.Length > 0) { SetUseEnteredDataAtImport = XmlConvert.ToBoolean(attr); }

            attr = pluginNode.GetAttribute(xmlTags.Verbose);
            if (attr.Length > 0) { Verbose = XmlConvert.ToInt16(attr); }
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            pluginNode.SetAttribute(xmlTags.AdjustPausesToDeviceAtImport, XmlConvert.ToString(AdjustPausesToDeviceAtImport));
            pluginNode.SetAttribute(xmlTags.AdjustPausesToDeviceEditMenu, XmlConvert.ToString(AdjustPausesToDeviceEditMenu));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsAtImport, XmlConvert.ToString(DetectRestLapsAtImport));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsEditMenu, XmlConvert.ToString(DetectRestLapsEditMenu));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsAlternativeAlgorithm, XmlConvert.ToString(DetectRestLapsAlternativeAlgorithm));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsLapDistance, XmlConvert.ToString(DetectRestLapsLapDistance));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsSlowSpeedFactor, XmlConvert.ToString(DetectRestLapsSlowSpeedFactor));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsSpeedFactor, XmlConvert.ToString(DetectRestLapsSpeedFactor));
            pluginNode.SetAttribute(xmlTags.ElevationToGPSAtImport, XmlConvert.ToString(ElevationToGPSAtImport));
            pluginNode.SetAttribute(xmlTags.ElevationToGPSEditMenu, XmlConvert.ToString(ElevationToGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.ExtendGPSAtImport, XmlConvert.ToString(ExtendGPSAtImport));
            pluginNode.SetAttribute(xmlTags.ExtendGPSEditMenu, XmlConvert.ToString(ExtendGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.FixHRAtImport, XmlConvert.ToString(FixHRAtImport));
            pluginNode.SetAttribute(xmlTags.FixHREditMenu, XmlConvert.ToString(FixHREditMenu));
            pluginNode.SetAttribute(xmlTags.FixHRStartHR, XmlConvert.ToString(FixHRStartHR));
            pluginNode.SetAttribute(xmlTags.FixHRTruncateHR, XmlConvert.ToString(FixHRTruncateHR));
            pluginNode.SetAttribute(xmlTags.FixHRCheckSeconds, XmlConvert.ToString(FixHRCheckSeconds));
            pluginNode.SetAttribute(xmlTags.FixNaNEditMenu, XmlConvert.ToString(FixNaNEditMenu));
            pluginNode.SetAttribute(xmlTags.InsertPausesAtImport, XmlConvert.ToString(InsertPausesAtImport));
            pluginNode.SetAttribute(xmlTags.InsertPausesEditMenu, XmlConvert.ToString(InsertPausesEditMenu));
            pluginNode.SetAttribute(xmlTags.InsertPausesWhenGPSdifferMinSeconds, XmlConvert.ToString(InsertPausesWhenGPSdifferMinSeconds));
            pluginNode.SetAttribute(xmlTags.InsertPausesAdjacentCheckSeconds, XmlConvert.ToString(InsertPausesAdjacentCheckSeconds));
            pluginNode.SetAttribute(xmlTags.InsertPausesGPSOffsetSeconds, XmlConvert.ToString(InsertPausesGPSOffsetSeconds));
            pluginNode.SetAttribute(xmlTags.Laps2CadenceEditMenu, XmlConvert.ToString(Laps2CadenceEditMenu));
            pluginNode.SetAttribute(xmlTags.RemoveIdenticalGPSAtImport, XmlConvert.ToString(RemoveIdenticalGPSAtImport));
            pluginNode.SetAttribute(xmlTags.RemoveIdenticalGPSEditMenu, XmlConvert.ToString(RemoveIdenticalGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.SetTimeGPSAtImport, XmlConvert.ToString(SetTimeGPSAtImport));
            pluginNode.SetAttribute(xmlTags.SetTimeGPSEditMenu, XmlConvert.ToString(SetTimeGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.SetUseEnteredDataAtImport, XmlConvert.ToString(SetUseEnteredDataAtImport));

            pluginNode.SetAttribute(xmlTags.Verbose, XmlConvert.ToString(Verbose));
        }
        #endregion
        
        #region Private members
        private static IApplication application;

        public static bool AdjustPausesToDeviceAtImport = false;
        public static bool AdjustPausesToDeviceEditMenu = false;
        public static bool DetectRestLapsAtImport = false;
        public static bool DetectRestLapsEditMenu = false;
        public static int DetectRestLapsAlternativeAlgorithm = 0; //Only changed in xml file
        public static int DetectRestLapsLapDistance = 1000; //Only changed in xml file
        public static float DetectRestLapsSlowSpeedFactor = 2F; //Only changed in xml file
        public static float DetectRestLapsSpeedFactor = 1.1F; //Only changed in xml file
        public static bool ElevationToGPSAtImport = false;
        public static bool ElevationToGPSEditMenu = false;
        public static bool ExtendGPSAtImport = false;
        public static bool ExtendGPSEditMenu = false;
        public static bool FixHRAtImport = false;
        public static bool FixHREditMenu = false;
        public static int FixHRStartHR = 100; //Only changed in xml file
        public static int FixHRCheckSeconds = 500; //Only changed in xml file
        public static int FixHRTruncateHR = 150; //Only changed in xml file
        public static bool FixNaNEditMenu = false;
        public static bool InsertPausesAtImport = false;
        public static bool InsertPausesEditMenu = false;
        public static int InsertPausesWhenGPSdifferMinSeconds = 180;
        public static int InsertPausesAdjacentCheckSeconds = 3; //Only changed in xml file
        public static int InsertPausesGPSOffsetSeconds = 1; //Only changed in xml file
        public static bool Laps2CadenceEditMenu = false; //Only changed in xml file
        public static bool RemoveIdenticalGPSAtImport = false;
        public static bool RemoveIdenticalGPSEditMenu = false;
        public static bool SetTimeGPSAtImport = false;
        public static bool SetTimeGPSEditMenu = false;
        public static bool SetUseEnteredDataAtImport = false;

        public static int Verbose = 0;  //Only changed in xml file
        #endregion

        private class xmlTags
        {
            public const string AdjustPausesToDeviceAtImport = "AdjustPausesToDeviceAtImport";
            public const string AdjustPausesToDeviceEditMenu = "AdjustPausesToDeviceEditMenu";
            public const string DetectRestLapsAtImport = "DetectRestLapsAtImport";
            public const string DetectRestLapsEditMenu = "DetectRestLapsEditMenu";
            public const string DetectRestLapsAlternativeAlgorithm = "DetectRestLapsAlternativeAlgorithm";
            public const string DetectRestLapsLapDistance = "DetectRestLapsLapDistance";
            public const string DetectRestLapsSlowSpeedFactor = "DetectRestLapsSlowSpeedFactor";
            public const string DetectRestLapsSpeedFactor     = "DetectRestLapsSpeedFactor";
            public const string ElevationToGPSAtImport = "ElevationToGPSAtImport";
            public const string ElevationToGPSEditMenu = "ElevationToGPSEditMenu";
            public const string ExtendGPSAtImport = "ExtendGPSAtImport";
            public const string ExtendGPSEditMenu = "ExtendGPSEditMenu";
            public const string FixHRAtImport = "FixHRAtImport";
            public const string FixHREditMenu = "FixHREditMenu";
            public const string FixHRStartHR = "FixHRStartHR";
            public const string FixHRTruncateHR = "FixHRTruncateHR";
            public const string FixHRCheckSeconds = "FixHRCheckSeconds";
            public const string FixNaNEditMenu = "FixNaNEditMenu";
            public const string InsertPausesAtImport = "InsertPausesAtImport";
            public const string InsertPausesEditMenu = "InsertPausesEditMenu";
            public const string InsertPausesWhenGPSdifferMinSeconds = "InsertPauseWhenGPSdifferMinSeconds";
            public const string InsertPausesAdjacentCheckSeconds = "InsertPausesAdjacentCheckSeconds";
            public const string InsertPausesGPSOffsetSeconds = "InsertPausesGPSOffsetSeconds";
            public const string Laps2CadenceEditMenu = "Laps2CadenceEditMenu";
            public const string RemoveIdenticalGPSAtImport = "RemoveIdenticalGPSAtImport";
            public const string RemoveIdenticalGPSEditMenu = "RemoveIdenticalGPSEditMenu";
            public const string SetTimeGPSAtImport = "SetTimeGPSAtImport";
            public const string SetTimeGPSEditMenu = "SetTimeGPSEditMenu";
            public const string SetUseEnteredDataAtImport = "SetUseEnteredDataAtImport";

            public const string Verbose = "Verbose";
        }
        #region Utility
        public static DateTime Min(DateTime t1, DateTime t2)
        {
            if (DateTime.Compare(t1, t2) > 0)
            {
                return t2;
            }
            return t1;
        }

        public static DateTime Max(DateTime t1, DateTime t2)
        {
            if (DateTime.Compare(t1, t2) < 0)
            {
                return t2;
            }
            return t1;
        }

        #endregion
    }
}
