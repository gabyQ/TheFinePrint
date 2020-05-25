using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheFinePrint.Utils
{
    public class FormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return Utils.Constants.DefaultDateFormat;
        }
    }
}
