using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace Jojo.Utils.Helpers.Xml
{
    /// <summary>
    /// Validation de fichier XML face à un schéma XSD.
    /// </summary>
    public class XmlValidator
    {
        /// <summary>
        /// Obtient la liste des erreurs de validation.
        /// </summary>
        public List<string> Errors { get; private set; }

        /// <summary>
        /// Obtient la liste des avertissements de validation.
        /// </summary>
        public List<string> Warnings { get; private set; }

        /// <summary>
        /// Obtient le cache du schéma de validation.
        /// </summary>
        public XmlSchemaSet SchemaSet { get; private set; }

        /// <summary>
        /// Empêche la création d'une instance par défaut de la classe <see cref="XmlValidator"/>.
        /// </summary>
        private XmlValidator()
        {
            this.Errors = new List<string>();
            this.Warnings = new List<string>();
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="XmlValidator"/>.
        /// </summary>
        /// <param name="schemaSet">Le cache du schéma de validation.</param>
        public XmlValidator(XmlSchemaSet schemaSet)
            : this()
        {
            this.SchemaSet = schemaSet;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="XmlValidator"/>.
        /// </summary>
        /// <param name="xsdFilePath">Le chemin du schéma de validation.</param>
        public XmlValidator(string xsdFilePath)
            : this()
        {
            // Construction du XmlSchemaSet
            this.SchemaSet = new XmlSchemaSet();
            this.SchemaSet.Add(string.Empty, xsdFilePath);
        }

        /// <summary>
        /// Validation d'un fichier XML contre le schéma.
        /// </summary>
        /// <param name="filename">Le chemin du fichier XML à valider.</param>
        public void Validate(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }

            XmlSchema compiledSchema = null;
            foreach (XmlSchema schema in this.SchemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
            settings.ValidationType = ValidationType.Schema;

            using (var vreader = XmlReader.Create(filename, settings))
            {
                try
                {
                    while (vreader.Read())
                    {
                    }
                }
                catch (Exception e)
                {
                    this.Errors.Add(e.Message);
                }
            }
        }

        /// <summary>
        /// Se produit lors d'une réception d'un message d'erreur ou d'avertissement pendant la validation du fichier XML.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void ValidationCallback(object sender, ValidationEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }

            if (e == null)
            {
                throw new ArgumentNullException("ValidationEventArgs[e]");
            }

            if (e.Severity == XmlSeverityType.Warning)
            {
                this.Warnings.Add(e.Message);
            }
            else
            {
                this.Errors.Add(e.Message);
            }
        }
    }
}
