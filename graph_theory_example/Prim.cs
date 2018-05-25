using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class Prim
    {

        public Node Center;
        public Graph graph;
        public List<Node> visited;

        public int Cost = 0;
        public List<Arc> TraversalArcList;


        public Prim(Node center , Graph graph)
        {
            this.Center = center;
            this.graph = graph;
            visited = new List<Node>();
            TraversalArcList = new List<Arc>();
            visited.Add(Center);
            Traversal();
        }
        public void getListMbox()
        {
            string temp = "";
            foreach (var item in TraversalArcList)
            {
                temp += item.Parent.Name + "-" + item.Child.Name + "\n";
            }

            System.Windows.Forms.MessageBox.Show(temp);
        }

        public void Traversal()
        {
            int tempWeight = 999;
            Node tempNode = new Node("Default");
            Arc tempArc = new Arc();

            foreach (var node in visited)
            {
                foreach (var arc in node.Arcs)
                {
                    Node TempNode2 = visited.Find(a => a == arc.Child);

                    if(TempNode2 != null)
                    {
                        continue;
                    }

                    if (tempWeight > arc.Weigth)
                    {
                        tempWeight = arc.Weigth;
                        
                        tempNode = arc.Child;
                        tempArc = arc;
                    }
                }
            }

            if(tempNode.Name != "Default")
            {
                TraversalArcList.Add(tempArc);    
                visited.Add(tempNode);
                Traversal();
            }
            else
            {
                foreach (var Arc in TraversalArcList)
                {
                    Cost += Arc.Weigth;
                }
            }      

        }



    }
}
