using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    public class Parent
    {
        public virtual int ParentId { get; set; }
        public virtual string ParentName { get; set; }
        public virtual IList<Child> Children { get; set; } = new List<Child>();
    }

}
