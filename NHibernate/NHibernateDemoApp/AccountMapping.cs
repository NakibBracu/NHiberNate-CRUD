using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    public class AccountMapping : ClassMapping<Account>
    {
        public AccountMapping()
        {
            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Type(NHibernateUtil.Int32);
                m.Column("Id");
                m.UnsavedValue(0);
            });

            Property(x => x.AccountNumber, m =>
            {
                m.Length(50);
                m.Type(NHibernateUtil.String); // Assuming it's a string
                m.NotNullable(true);
                m.Column("AccountNumber"); // Specify the column name
            });

            Property(x => x.Balance, m =>
            {
                m.Type(NHibernateUtil.Decimal); // Correct type for decimal
                m.NotNullable(true);
                m.Column("Balance"); // Specify the column name
            });
        }
    }

}
