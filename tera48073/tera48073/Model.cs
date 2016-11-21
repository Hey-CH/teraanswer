using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
namespace tera48073 {
    public class ObjectModel: DbContext {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
    public class Document {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Person Author { get; set; }
    }
    public class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
