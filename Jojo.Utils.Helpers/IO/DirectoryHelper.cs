using System.IO;

namespace Jojo.Utils.Helpers.IO
{
    /// <summary>
    /// Utilitaire de gestion des dossiers.
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Copie d'un répertoire.
        /// </summary>
        /// <param name="sourceDirName">Le dossier source à copier.</param>
        /// <param name="destDirName">Le dossier où copier les fichiers.</param>
        /// <param name="copySubDirs">Indique si les sous-dossiers sont à copier.</param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Le dossier à copier n'existe pas à l'emplacement : " + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
