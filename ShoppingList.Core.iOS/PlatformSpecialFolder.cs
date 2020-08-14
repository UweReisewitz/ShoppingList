using System;
using System.IO;

namespace ShoppingList.Core
{
    public class PlatformSpecialFolder : IPlatformSpecialFolder
    {
        public string ApplicationData
        {
            get
            {
                var retval = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ShoppingList");
                Directory.CreateDirectory(retval);
                return retval;
            }
        }
    }
}