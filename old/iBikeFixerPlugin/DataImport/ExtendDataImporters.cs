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
using System.Collections;
using System.Collections.Generic;
using System.Text;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using IBikeFixerPlugin.Edit;

namespace IBikeFixerPlugin.DataImport
{
    class ExtendDataImporters : IExtendDataImporters
    {
        #region IExtendDataImporters Members

        public IList<IFileImporter> FileImporters
        {
            get
            {
                return null;
            }
        }

        public void BeforeImport(IList items)
        {
            IList<IActivity> activities2 = new List<IActivity>();
            foreach (object item in items)
            {
                if (item is IActivity)
                {
                    if (Resources.Plugin.ActivateAtImportBool1)
                    {
                        IActivity activity = (IActivity)item;

                        if (Action.isEnabled(activity))
                        {
                            activities2.Add(activity);
                        }
                    }
                }
            }
            Action tmp = new Action(activities2);
            tmp.Run();
        }

        public void AfterImport(IList added, IList updated)
        {
        }

        #endregion
    }
}
