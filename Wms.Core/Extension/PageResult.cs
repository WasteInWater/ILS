using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core
{
   
   public static class PageResult<T> where T : new()
   {
        public static dynamic LayuiPageResult(PagedList<T> page)
        {
            return new
            {
                count = page.TotalCount,
                Rows = page.Items //
            };
        }
    }
}
