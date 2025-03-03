using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SiliconWraith.Common.API.Common
{
    public class GlobalConstants
    {
        /// <summary>
        /// Constant that controls the string format for the output of GUIDs in a human readable format.  The format is 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
        /// </summary>
        public const string READABLE_GUID_FORMAT_STRING = "D";

        /// <summary>
        /// Constant that controls string format for the output of GUIDs in a format intented for directory of file names.  The format is 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx'
        /// </summary>
        public const string STORAGE_GUID_FORMAT_STRING = "N";


    }
}
