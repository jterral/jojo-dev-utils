using System;
using System.Xml;
using System.Xml.Xsl;

namespace Jojo.Utils.Helpers.Xslt
{
    /// <summary>
    /// Aide à la gestion des fichiers de transformation XSLT.
    /// </summary>
    public static class XsltHelper
    {
        /// <summary>
        /// Chargement du fichier de transformation.
        /// </summary>
        /// <param name="xslFilePath">Le chemin vers le fichier de transformation.</param>
        /// <returns>Retourne le compilateur XSLT.</returns>
        public static XslCompiledTransform Load(string xslFilePath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            try
            {
                xslt.Load(xslFilePath);
            }
            catch (Exception)
            {
                // TODO : Implémentation de la logique d'exception
            }

            return xslt;
        }

        /// <summary>
        /// Ecriture d'un fichier XML vers un fichier HTML à partir d'un fichier de transformation XSLT.
        /// </summary>
        /// <param name="xmlFilePath">Le chemin vers le fichier XML à transformer.</param>
        /// <param name="outFilePath">Le chemin vers le fichier HTML.</param>
        /// <param name="compiler">Le compilateur XSLT.</param>
        public static void Write(string xmlFilePath, string outFilePath, XslCompiledTransform compiler)
        {
            try
            {
                // Création de l'écrivain du fichier HTML
                using (XmlWriter writer = XmlWriter.Create(outFilePath, compiler.OutputSettings))
                {
                    // Transformation en HTML
                    compiler.Transform(xmlFilePath, writer);
                }
            }
            catch (Exception)
            {
                // TODO : Implémentation de la logique d'exception
            }
        }
    }
}
