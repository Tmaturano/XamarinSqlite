using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace XamarinSqlite
{
    /// <summary>
    /// This platform will be implemented in each platform.
    /// </summary>
    public interface IConfig
    {
        //Each Platform has it's folder directory.
        string DirectoryDB { get; }

        /// <summary>
        /// This interface has some settings for each platform.
        /// 
        /// </summary>
        ISQLitePlatform Platform { get; }
    }
}
