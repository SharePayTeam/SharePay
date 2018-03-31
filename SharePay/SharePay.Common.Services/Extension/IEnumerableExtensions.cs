using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Common.Services.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> ToPagedList<TSource>(this IEnumerable<TSource> source, int pageNumber, int pageSize, string orderBy, bool isDescendingOrder, out int totalItemsCount, Expression<Func<TSource, bool>> filter = null)
        {
            if (source == null)
            {
                totalItemsCount = 0;
                return null;
            }

            if (filter != null)
            {
                source = source.Where(filter.Compile());
            }

            if (!isDescendingOrder)
            {
                source = source.OrderBy(x => x.GetType().GetProperty(orderBy).GetValue(x, null));
            }
            else
            {
                source = source.OrderByDescending(x => x.GetType().GetProperty(orderBy).GetValue(x, null));
            }

            totalItemsCount = source.Count();

            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public static IEnumerable<TSource> ToSortedList<TSource>(this IEnumerable<TSource> source, string orderBy, bool isDescendingOrder, out int totalItemsCount, Expression<Func<TSource, bool>> filter = null)
        {
            if (source == null)
            {
                totalItemsCount = 0;
                return null;
            }

            if (filter != null)
            {
                source = source.Where(filter.Compile());
            }

            if (!isDescendingOrder)
            {
                source = source.OrderBy(x => x.GetType().GetProperty(orderBy).GetValue(x, null));
            }
            else
            {
                source = source.OrderByDescending(x => x.GetType().GetProperty(orderBy).GetValue(x, null));
            }

            totalItemsCount = source.Count();

            return source.ToList();
        }
        
    }
}
