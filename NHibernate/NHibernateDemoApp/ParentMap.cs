using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateDemoApp
{
    public class ParentMap : ClassMapping<Parent>
    {
        public ParentMap()
        {
            Id(x => x.ParentId, m => m.Generator(Generators.Identity));
            Property(x => x.ParentName);

            Bag(x => x.Children, c =>
            {
                c.Key(k => k.Column("ParentId"));
                c.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, r => r.OneToMany());
        }
    }

}
