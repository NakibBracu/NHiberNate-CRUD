namespace NHibernateDemoApp
{
    public class Child
    {
        public virtual int ChildId { get; set; }
        public virtual string ChildName { get; set; }
        public virtual Parent Parent { get; set; }
    }

}
