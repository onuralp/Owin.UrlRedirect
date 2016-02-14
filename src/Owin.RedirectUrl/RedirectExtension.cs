using System;

namespace Owin.RedirectUrl
{
    public static class RedirectExtension
    {
        public static bool ShouldRedirect(this string absolutePath, string sourcePath, string destinationPath)
        {
            return !string.IsNullOrWhiteSpace(destinationPath) &&
                   string.Equals(absolutePath, sourcePath, StringComparison.CurrentCultureIgnoreCase) &&
                   !string.Equals(absolutePath, destinationPath, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}