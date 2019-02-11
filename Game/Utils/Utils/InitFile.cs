using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace Game.Utils.Utils
{
    public class InitFile
    {
       
       // public string sPath = string.Format("{0}\\ctrlconfig.ini", System.Configuration.ConfigurationManager.AppSettings["gamectrlinfo"].ToString());
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void InitWriteValue(string Section, string Key, string Value, string filePath, string fileName)
        {
            if (!Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            WritePrivateProfileString(Section, Key, Value, filePath + "\\" + fileName);
        }

        public string InitReadValue(string Section, string Key, string filePath,string fileName)
        {
            if (!Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filePath + "\\" + fileName);
            return temp.ToString();
        }
    }
}
