using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class Graph
    {
        
            public Node Root;
            public List<Node> AllNodes = new List<Node>();

            public Node CreateRoot(string name)
            {
                Root = CreateNode(name);
                return Root;
            }
        public Node CreateRoot(string name,int id)
        {
            Root = CreateNode(name,id);
            return Root;
        }

        public Node CreateNode(string name)
            {
                var n = new Node(name);
                AllNodes.Add(n);
                return n;
            }
        public Node CreateNode(string name,int id)
        {
            var n = new Node(name,id);
            AllNodes.Add(n);
            return n;
        }


    }
}
