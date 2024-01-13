using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateDemoApp
{
    public class ChildMap : ClassMapping<Child>
    {
        public ChildMap()
        {
            Id(x => x.ChildId, m => m.Generator(Generators.Identity));
            Property(x => x.ChildName);
            ManyToOne(x => x.Parent, m => m.Column("ParentId"));
        }
    }
}
