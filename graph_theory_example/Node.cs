using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class Node
    {
        public int ID;
        public string Name;
        
        public List<Arc> Arcs = new List<Arc>();


        public Node(string name)
        {
            Name = name;
        }
        public Node(string name,int id)
        {
            ID = id;
            Name = name;
        }

        public Node AddArc(Node child, int w)
        {
            Arcs.Add(new Arc
            {
                Parent = this,
                Child = child,
                Weigth = w
            });

            if (!child.Arcs.Exists(a => a.Parent == child && a.Child == this))
            {
                child.AddArc(this, w);
            }



            return this;
        }
    }
}
