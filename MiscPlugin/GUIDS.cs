/*
Copyright (C) 2016 Gerhard Olsson

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

namespace MiscPlugin
{
    class GUIDs {
        //Also used for Settings page
#if !OLD_GUID
        public static readonly Guid PluginMain = new Guid("01f7ff28-532a-4053-a7dc-0ab3adcacf82");
#else
        public static readonly Guid PluginMain = new Guid("d75393a2-4a95-4fe7-ace2-375ff7338b2c");
#endif
    }
}