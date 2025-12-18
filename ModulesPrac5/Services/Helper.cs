using ModulesPrac5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulesPrac5.Services
{
    internal class Helper
    {
        public static Prac5ModulesEntities _context;

        public static Prac5ModulesEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Prac5ModulesEntities();
            }
            return _context;
        }
    }
}
