using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Utils
{
    public static class ValidateNullableItem
    {
        public static void ItemIsNull(object item)
        {
            if (item == null)
                throw new ArgumentNullException();
        }
    }
}
