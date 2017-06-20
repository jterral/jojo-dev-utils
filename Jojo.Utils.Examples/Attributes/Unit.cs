namespace Jojo.Utils.Examples.Attributes
{
    public enum Unit
    {
        /// <summary>
        /// Mètre.
        /// </summary>
        [UnitAttribute("mètre", "m", "m²")]
        m,

        /// <summary>
        /// Mètre.
        /// </summary>
        [UnitAttribute("micromètre", "µm", "µm²")]
        um,
    }
}
