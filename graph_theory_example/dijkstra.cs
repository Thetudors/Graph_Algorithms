using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class dijkstra
    {

        public Node TargetNode;
        public List<DijNode> AllDijNode;
        public DijNode dijnode;
        public DijNode startdijNode;

        List<DijNode> visited;
        public dijkstra(Node startNode ,Node Target, Graph graph)
        {
            visited = new List<DijNode>();
            AllDijNode = new List<DijNode>();
            foreach (var Node in graph.AllNodes)
            {
                if(Node.Name == startNode.Name)
                {
                    startdijNode = new DijNode(Node, 0);
                    AllDijNode.Add(startdijNode);
                    continue;
                }

                dijnode = new DijNode(Node, int.MaxValue);
                AllDijNode.Add(dijnode); 

            }
            Traversal();
        }

        public void getListMbox(string Name)
        {
            string temp = "";
            foreach (var item in AllDijNode)
            {
               if(item.Node.Name == Name)
                {
                    temp = Name + " Cost : " + item.Cost;
                }
            }

            System.Windows.Forms.MessageBox.Show(temp);
        }
        public string getListText()
        {
            string temp = "";
            foreach (var item in AllDijNode)
            {
                
               
                    temp += item.Node.Name + " Cost : " + item.Cost +"\n";
                
            }

            return temp;
        }

        public void Traversal()
        {
            foreach (var dijnode in AllDijNode)
            {
                foreach (var arc in dijnode.Node.Arcs)
                {
                    DijNode tempDijnode = visited.Find(a => a.Node == arc.Child);

                    if (tempDijnode != null)
                    {
                        continue;
                    }

                    DijNode tempParent = AllDijNode.Find(a => a.Node == arc.Parent);
                    DijNode tempChild = AllDijNode.Find(a => a.Node == arc.Child);

                    if (dijnode.Cost+arc.Weigth < tempChild.Cost)
                        tempChild.Cost = arc.Weigth + tempParent.Cost;
                }
            }
           

            visited.Add(dijnode);

        }
    }

   public class DijNode
    {
       public Node Node;
       public int Cost;

        public DijNode(Node node ,int cost)
        {
            this.Node = node;
            this.Cost = cost;          
        }

    }
}
