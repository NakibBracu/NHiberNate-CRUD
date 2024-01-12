using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    public class StudentMapping : ClassMapping<Student>
    {
        public StudentMapping() {
            Id(x => x.ID, c => {

                c.Generator(Generators.Identity);
                c.Type(NHibernateUtil.Int32);
                c.Column("ID");
                c.UnsavedValue(0);
            });

            Property(x => x.LastName, c =>
            {
                c.Length(50);
                c.Type(NHibernateUtil.AnsiString);
                c.NotNullable(true);
            });

            Property(x => x.FirstMidName, c =>
            {
                c.Length(50);
                c.Type(NHibernateUtil.AnsiString);
                c.NotNullable(true);
            });
        }

        
       
    }
}
