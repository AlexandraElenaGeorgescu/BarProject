using BarProject.Database_access;
using BarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Services
{
    public class TableService
    {
        private readonly DatabaseAccess _databaseAccess;

        public TableService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<Table> GetTables()
        {
            // You'll need to implement this method in the DatabaseAccess class
            return _databaseAccess.GetTables();
        }

        public void InsertTable(Table table)
        {
            // You'll need to implement this method in the DatabaseAccess class
            _databaseAccess.InsertTable(table);
        }

        public void UpdateTable(Table table)
        {
            // You'll need to implement this method in the DatabaseAccess class
            _databaseAccess.UpdateTable(table);
        }

        public void DeleteTable(int tableId)
        {
            // You'll need to implement this method in the DatabaseAccess class
            _databaseAccess.DeleteTable(tableId);
        }
    }
}
