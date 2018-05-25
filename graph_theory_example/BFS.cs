using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class BFS
    {
        public Node Center;
        public Node Target;
        public Graph graph;
        Node[] NodeArray;
        public List<Node> visited;
        public Queue<Node> nodeKuyruk;
        public int i = 0;

        public BFS(Node center , Graph graph)
        {
            this.Center = center;
            this.graph = graph;

            nodeKuyruk = new Queue<Node>();
            visited = new List<Node>();
            visited.Add(Center);
            NodeArray = new Node[graph.AllNodes.Count];

            Traversal(Center);
        }

        public void getListMbox()
        {
            string temp = "";
            foreach (var node in visited)
            {
                
                    temp += node.Name + "\n";
                
                
            }

            System.Windows.Forms.MessageBox.Show(temp);
        }

        public void Traversal(Node node)
        {
            NodeArray[i] = node;
            i++;
            foreach (var arc in node.Arcs)
            {
                Node nodetemp1 = visited.Find(a => a == arc.Child);
                if (nodetemp1 == null)
                {
                    nodeKuyruk.Enqueue(arc.Child);
                    visited.Add(arc.Child);
                }
              
            }
            try
            {             
                    Traversal(nodeKuyruk.Dequeue());   
            }
            catch (Exception)
            {

                return;
            }
              
            
        }

    }
}
