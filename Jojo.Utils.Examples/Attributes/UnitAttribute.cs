using System;

namespace Jojo.Utils.Examples.Attributes
{
    /// <summary>
    /// Attributs d'unité.
    /// </summary>
    public class UnitAttribute : Attribute
    {
        /// <summary>
        /// Obtient ou définit le nom complet de l'unité.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtient ou définit le nom court de l'unité.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de la surface.
        /// </summary>
        public string Square { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="UnitAttribute"/>.
        /// </summary>
        /// <param name="name">Le nom complet de l'unité.</param>
        /// <param name="shortName">Le nom court de l'unité.</param>
        /// <param name="square">Le nom de la surface.</param>
        public UnitAttribute(string name, string shortName, string square)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.Square = square;
        }
    }
}
