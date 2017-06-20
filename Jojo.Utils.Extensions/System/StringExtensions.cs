using System;

namespace Jojo.Utils.Extensions.System
{
    /// <summary>
    /// Extensions du type <see cref="System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indique si la chaine de caractères contient la chaine spécifique.
        /// </summary>
        /// <param name="source">La chaine de caractères où vérifier.</param>
        /// <param name="value">La chaine spécifique.</param>
        /// <param name="comparisonType">Le type de comparaison.</param>
        /// <returns>Retourne une valeur indiquant si la chaine de caractères contient la chaine spécifique.</returns>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        /// Comparaison de chaines de caractères avec insensibilité à la casse.
        /// </summary>
        /// <param name="a">La chaine de caractères à comparer.</param>
        /// <param name="b">La chaine de caractères avec laquelle comparer.</param>
        /// <returns>Retourne <c>true</c> si les chaines de caractères sont identiques, <c>false</c> sinon.</returns>
        public static bool EqualsInvariant(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
