using System;
using Xamarin.Forms;
using SQLite.Net;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace XamarinSqlite
{
    public class DataAccess : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            _connection = new SQLiteConnection(config.Platform, Path.Combine(config.DirectoryDB, "myDatabase.db3"));
            _connection.CreateTable<Contact>();
        }

        public void Insert(Contact contact)
        {
            _connection.Insert(contact);
        }

        public void Update(Contact contact)
        {
            _connection.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _connection.Delete(contact);
        }

        public Contact GetById(int Id)
        {
            return _connection.Table<Contact>().FirstOrDefault(c => c.Id == Id);
        }

        public List<Contact> GetContacts()
        {
            return _connection.Table<Contact>().OrderBy(c => c.Name).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
