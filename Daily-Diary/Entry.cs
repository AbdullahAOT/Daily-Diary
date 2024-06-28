using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class Entry
    {
        public string dateOfEntry;
        public string contentOfEntry;
        public Entry(string dateOfEntry, string contentOfEntry)
        {
            this.dateOfEntry = dateOfEntry;
            this.contentOfEntry = contentOfEntry;
        }
    }
}
