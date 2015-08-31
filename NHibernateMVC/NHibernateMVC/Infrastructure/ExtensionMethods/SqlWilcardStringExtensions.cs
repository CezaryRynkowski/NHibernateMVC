using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Infrastructure.ExtensionMethods
{
    /// <summary>
    /// Extensions methods on string to ocnvert * wilcards to % for sql statements
    /// </summary>
    public static class SqlWilcardStringExtensions
    {
        /// <summary>
        /// Converts wilcards for search from user friendly * to sql friendly %
        /// </summary>
        public static string ConvertWildcards(this string target)
        {
            if (string.IsNullOrWhiteSpace(target))
                return target;

            return target.Replace('*', '%');
        }
    }
}