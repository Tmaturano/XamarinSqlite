using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;
using Xamarin.Forms;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(XamarinSqlite.iOS.Config))]

namespace XamarinSqlite.iOS
{
    public class Config : IConfig
    {
        private string _directoryDB;
        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_directoryDB))
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _directoryDB = Path.Combine(directory, "..", "Library");
                }

                return _directoryDB;
            }
        }

        private ISQLitePlatform _platform;
        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                {
                    _platform = new SQLitePlatformIOS();
                }

                return _platform;
            }
        }
    }
}
