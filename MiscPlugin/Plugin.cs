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

        public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
            String attr;
            attr = pluginNode.GetAttribute(xmlTags.Verbose);
            if (attr.Length > 0) { Verbose = XmlConvert.ToInt16(attr); }
            else { Verbose = 0; }

            attr = pluginNode.GetAttribute(xmlTags.ExtendGPSAtImport);
            if (attr.Length > 0) { ExtendGPSAtImport = XmlConvert.ToBoolean(attr); }
            else { ExtendGPSAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.ExtendGPSEditMenu);
            if (attr.Length > 0) { ExtendGPSEditMenu = XmlConvert.ToBoolean(attr); }
            else { ExtendGPSEditMenu = true; }

            attr = pluginNode.GetAttribute(xmlTags.InsertPausesAtImport);
            if (attr.Length > 0) { InsertPausesAtImport = XmlConvert.ToBoolean(attr); }
            else { InsertPausesAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesEditMenu);
            if (attr.Length > 0) { InsertPausesEditMenu = XmlConvert.ToBoolean(attr); }
            else { InsertPausesEditMenu = true; }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesWhenGPSdifferMinSeconds);
            if (attr.Length > 0) { InsertPausesWhenGPSdifferMinSeconds = XmlConvert.ToInt16(attr); }
            else { InsertPausesWhenGPSdifferMinSeconds = 180; }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesAdjacentCheckSeconds);
            if (attr.Length > 0) { InsertPausesAdjacentCheckSeconds = XmlConvert.ToInt16(attr); }
            else { InsertPausesAdjacentCheckSeconds = 3; }
            attr = pluginNode.GetAttribute(xmlTags.InsertPausesGPSOffsetSeconds);
            if (attr.Length > 0) { InsertPausesGPSOffsetSeconds = XmlConvert.ToInt16(attr); }
            else { InsertPausesGPSOffsetSeconds = 1; }

            attr = pluginNode.GetAttribute(xmlTags.Laps2CadenceEditMenu);
            if (attr.Length > 0) { Laps2CadenceEditMenu = XmlConvert.ToBoolean(attr); }
            else { Laps2CadenceEditMenu = false; }

            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsEditMenu);
            if (attr.Length > 0) { DetectRestLapsEditMenu = XmlConvert.ToBoolean(attr); }
            else { DetectRestLapsEditMenu = false; }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsAtImport);
            if (attr.Length > 0) { DetectRestLapsAtImport = XmlConvert.ToBoolean(attr); }
            else { DetectRestLapsAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsAlternativeAlgorithm);
            if (attr.Length > 0) { DetectRestLapsAlternativeAlgorithm = XmlConvert.ToInt16(attr); }
            else { DetectRestLapsAlternativeAlgorithm = 0; }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsLapDistance);
            if (attr.Length > 0) { DetectRestLapsLapDistance = XmlConvert.ToInt16(attr); }
            else { DetectRestLapsLapDistance = 1000; }
            attr = pluginNode.GetAttribute(xmlTags.DetectRestLapsSpeedFactor);
            if (attr.Length > 0) { DetectRestLapsSpeedFactor = (float)XmlConvert.ToDouble(attr); }
            else { DetectRestLapsSpeedFactor = 1.1F; }

            attr = pluginNode.GetAttribute(xmlTags.RemoveIdenticalGPSAtImport);
            if (attr.Length > 0) { RemoveIdenticalGPSAtImport = XmlConvert.ToBoolean(attr); }
            else { RemoveIdenticalGPSAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.RemoveIdenticalGPSEditMenu);
            if (attr.Length > 0) { RemoveIdenticalGPSEditMenu = XmlConvert.ToBoolean(attr); }
            else { RemoveIdenticalGPSEditMenu = false; }

            attr = pluginNode.GetAttribute(xmlTags.ElevationToGPSAtImport);
            if (attr.Length > 0) { ElevationToGPSAtImport = XmlConvert.ToBoolean(attr); }
            else { ElevationToGPSAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.ElevationToGPSEditMenu);
            if (attr.Length > 0) { ElevationToGPSEditMenu = XmlConvert.ToBoolean(attr); }
            else { ElevationToGPSEditMenu = true; }

            attr = pluginNode.GetAttribute(xmlTags.SetTimeGPSAtImport);
            if (attr.Length > 0) { SetTimeGPSAtImport = XmlConvert.ToBoolean(attr); }
            else { SetTimeGPSAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.SetTimeGPSEditMenu);
            if (attr.Length > 0) { SetTimeGPSEditMenu = XmlConvert.ToBoolean(attr); }
            else { SetTimeGPSEditMenu = true; }

        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            pluginNode.SetAttribute(xmlTags.Verbose, XmlConvert.ToString(Verbose));

            pluginNode.SetAttribute(xmlTags.ExtendGPSAtImport, XmlConvert.ToString(ExtendGPSAtImport));
            pluginNode.SetAttribute(xmlTags.ExtendGPSEditMenu, XmlConvert.ToString(ExtendGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.InsertPausesAtImport, XmlConvert.ToString(InsertPausesAtImport));
            pluginNode.SetAttribute(xmlTags.InsertPausesEditMenu, XmlConvert.ToString(InsertPausesEditMenu));
            pluginNode.SetAttribute(xmlTags.InsertPausesWhenGPSdifferMinSeconds, XmlConvert.ToString(InsertPausesWhenGPSdifferMinSeconds));
            pluginNode.SetAttribute(xmlTags.InsertPausesAdjacentCheckSeconds, XmlConvert.ToString(InsertPausesAdjacentCheckSeconds));
            pluginNode.SetAttribute(xmlTags.InsertPausesGPSOffsetSeconds, XmlConvert.ToString(InsertPausesGPSOffsetSeconds));
            pluginNode.SetAttribute(xmlTags.Laps2CadenceEditMenu, XmlConvert.ToString(Laps2CadenceEditMenu));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsAtImport, XmlConvert.ToString(DetectRestLapsAtImport));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsEditMenu, XmlConvert.ToString(DetectRestLapsEditMenu));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsAlternativeAlgorithm, XmlConvert.ToString(DetectRestLapsAlternativeAlgorithm));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsLapDistance, XmlConvert.ToString(DetectRestLapsLapDistance));
            pluginNode.SetAttribute(xmlTags.DetectRestLapsSpeedFactor, XmlConvert.ToString(DetectRestLapsSpeedFactor));
            pluginNode.SetAttribute(xmlTags.RemoveIdenticalGPSAtImport, XmlConvert.ToString(RemoveIdenticalGPSAtImport));
            pluginNode.SetAttribute(xmlTags.RemoveIdenticalGPSEditMenu, XmlConvert.ToString(RemoveIdenticalGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.ElevationToGPSAtImport, XmlConvert.ToString(ElevationToGPSAtImport));
            pluginNode.SetAttribute(xmlTags.ElevationToGPSEditMenu, XmlConvert.ToString(ElevationToGPSEditMenu));
            pluginNode.SetAttribute(xmlTags.SetTimeGPSAtImport, XmlConvert.ToString(SetTimeGPSAtImport));
            pluginNode.SetAttribute(xmlTags.SetTimeGPSEditMenu, XmlConvert.ToString(SetTimeGPSEditMenu));
        }
        #endregion
        
        public static IApplication GetApplication()
        {
            return application;
        }

        #region Private members
        private static IApplication application;
        public static int  Verbose;  //Only changed in xml file

        public static bool DetectRestLapsAtImport;
        public static bool DetectRestLapsEditMenu;
        public static int DetectRestLapsAlternativeAlgorithm; //Only changed in xml file
        public static int DetectRestLapsLapDistance; //Only changed in xml file
        public static float DetectRestLapsSpeedFactor; //Only changed in xml file
        public static bool ElevationToGPSAtImport;
        public static bool ElevationToGPSEditMenu;
        public static bool ExtendGPSAtImport;
        public static bool ExtendGPSEditMenu;
        public static bool InsertPausesAtImport;
        public static bool InsertPausesEditMenu;
        public static int InsertPausesWhenGPSdifferMinSeconds;
        public static int InsertPausesAdjacentCheckSeconds; //Only changed in xml file
        public static int InsertPausesGPSOffsetSeconds; //Only changed in xml file
        public static bool Laps2CadenceEditMenu; //Only changed in xml file
        public static bool RemoveIdenticalGPSAtImport;
        public static bool RemoveIdenticalGPSEditMenu;
        public static bool SetTimeGPSAtImport;
        public static bool SetTimeGPSEditMenu;
        #endregion

        private class xmlTags
        {
            public const string Verbose = "Verbose";

            public const string DetectRestLapsAtImport = "DetectRestLapsAtImport";
            public const string DetectRestLapsEditMenu = "DetectRestLapsEditMenu";
            public const string DetectRestLapsAlternativeAlgorithm = "DetectRestLapsAlternativeAlgorithm";
            public const string DetectRestLapsLapDistance = "DetectRestLapsLapDistance";
            public const string DetectRestLapsSpeedFactor = "DetectRestLapsSpeedFactor";
            public const string ElevationToGPSAtImport = "ElevationToGPSAtImport";
            public const string ElevationToGPSEditMenu = "ElevationToGPSEditMenu";
            public const string ExtendGPSAtImport = "ExtendGPSAtImport";
            public const string ExtendGPSEditMenu = "ExtendGPSEditMenu";
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
        }
     }
}
