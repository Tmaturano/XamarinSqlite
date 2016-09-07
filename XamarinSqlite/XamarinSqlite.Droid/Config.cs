using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinSqlite.Droid.Config))]

namespace XamarinSqlite.Droid
{
    public class Config : IConfig
    {
        private string _directoryDB;
        /// <summary>
        /// This is the directory that will save the database.
        /// </summary>
        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_directoryDB))
                {
                    _directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
                    //This class has the management of Sqlite for Android.
                    _platform = new SQLitePlatformAndroid();
                }

                return _platform;
            }
        }
    }
}