/*
Copyright (C) 2007 Gerhard Olsson 

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

namespace GpsCorrectionPlugin
{

    class Plugin : IPlugin
    {
        #region IPlugin Members
        //http://www.guidgen.com/
        public Guid Id
        {
            get { return new Guid("{0df3f6d7-13ed-4a11-9e65-fbd6df847b08}"); }
        }
        public string Name
        {
            get { return "GPS Correction Plugin"; }
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

            attr = pluginNode.GetAttribute(xmlTags.CorrectGpsFromDistanceAtImport);
            if (attr.Length > 0) CorrectGpsFromDistanceAtImport = XmlConvert.ToBoolean(attr);
            else { CorrectGpsFromDistanceAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.CorrectGpsFromDistanceEditMenu);
            if (attr.Length > 0) CorrectGpsFromDistanceEditMenu = XmlConvert.ToBoolean(attr);
            else { CorrectGpsFromDistanceEditMenu = true; }

            attr = pluginNode.GetAttribute(xmlTags.DistanceDiffToPowerAtImport);
            if (attr.Length > 0) DistanceDiffToPowerAtImport = XmlConvert.ToBoolean(attr);
            else { DistanceDiffToPowerAtImport = false; }
            attr = pluginNode.GetAttribute(xmlTags.DistanceDiffToPowerEditMenu);
            if (attr.Length > 0) DistanceDiffToPowerEditMenu = XmlConvert.ToBoolean(attr);
            else { DistanceDiffToPowerEditMenu = true; }
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            pluginNode.SetAttribute(xmlTags.CorrectGpsFromDistanceAtImport, XmlConvert.ToString(CorrectGpsFromDistanceAtImport));
            pluginNode.SetAttribute(xmlTags.CorrectGpsFromDistanceEditMenu, XmlConvert.ToString(CorrectGpsFromDistanceEditMenu));
            pluginNode.SetAttribute(xmlTags.DistanceDiffToPowerAtImport, XmlConvert.ToString(DistanceDiffToPowerAtImport));
            pluginNode.SetAttribute(xmlTags.DistanceDiffToPowerEditMenu, XmlConvert.ToString(DistanceDiffToPowerEditMenu));
        }
        #endregion
        
        public static IApplication GetApplication()
        {
            return application;
        }

        #region Private members
        private static IApplication application;
        public static int Verbose;  //Only changed in xml file

        public static bool CorrectGpsFromDistanceAtImport;
        public static bool CorrectGpsFromDistanceEditMenu;
        public static bool DistanceDiffToPowerAtImport; //Only changed in xml file
        public static bool DistanceDiffToPowerEditMenu; //Only changed in xml file
        private class xmlTags
        {
            public const string Verbose = "Verbose";

            public const string CorrectGpsFromDistanceAtImport = "CorrectGpsFromDistanceAtImport";
            public const string CorrectGpsFromDistanceEditMenu = "CorrectGpsFromDistanceEditMenu";
            public const string DistanceDiffToPowerAtImport = "DistanceDiffToPowerAtImport";
            public const string DistanceDiffToPowerEditMenu = "DistanceDiffToPowerEditMenu";
        }

        #endregion
     }
}
