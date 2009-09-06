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
using System.Text;
using System.Xml;

using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace IBikeFixerPlugin.Resources
{

    class Plugin : IPlugin
    {
        #region IPlugin Members
        //http://www.guidgen.com/
        public Guid Id
        {
            get { return new Guid("{7ccd1da0-2af1-4860-90ff-b1430dd6f61b}"); }
        }
        public string Name
        {
            get { return "Fix iBike Power Track"; }
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
            String attr = pluginNode.GetAttribute(xmlTags.ActivateAtImportBool1);
            if (attr.Length > 0) ActivateAtImportBool1 = XmlConvert.ToBoolean(attr);
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            pluginNode.SetAttribute(xmlTags.ActivateAtImportBool1, XmlConvert.ToString(ActivateAtImportBool1));
        }
        #endregion
        
        public static IApplication GetApplication()
        {
            return application;
        }

        #region Private members
        private static IApplication application;
        public static bool ActivateAtImportBool1;
        #endregion

        private class xmlTags
        {
            public const string ActivateAtImportBool1 = "ActivateAtImportBool1";
        }

     }
}
