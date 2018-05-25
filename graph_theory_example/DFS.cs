using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
    public class DFS
    {
       public Graph graph;
       Stack<DFSNode> DFSStack;
       List<DFSNode> visitedDFSNode;
       List<DFSNode> allDFSNode;
       public DFSNode dfsNode;
        DFSNode DfsNodeMin;

        public int MinIndex = int.MaxValue;
        public DFS(Node StartNode,Graph graph)
        {
            this.graph = graph;
            DFSStack = new Stack<DFSNode>();
            visitedDFSNode = new List<DFSNode>();
            allDFSNode = new List<DFSNode>();
            int i = 0;

            foreach (var node in graph.AllNodes)
            {
                dfsNode = new DFSNode(node, i);
                if (i == 0)
                {
                    DFSStack.Push(dfsNode);
                    visitedDFSNode.Add(dfsNode);
                    
                }
                    

                allDFSNode.Add(dfsNode);       
                i++;
                
            }

            Traversal();
        }

        public void getListMbox()
        {
            string temp = "";
            foreach (var node in visitedDFSNode)
            {
                temp += node.Node.Name + "\n";

            }

            System.Windows.Forms.MessageBox.Show(temp);
        }

        public void Traversal()
        {
            foreach (var node in allDFSNode)
            {
                foreach (var arc in node.Node.Arcs)
                {
                    DFSNode DfsNodeTemp = allDFSNode.Find(a => a.Node == arc.Child);

                    DFSNode visitedNode = visitedDFSNode.Find(a => a.Node == arc.Child);
                    if(visitedNode != null)
                    {
                        continue;
                    }

                    if(DfsNodeTemp.Id < MinIndex)
                    {
                        MinIndex = DfsNodeTemp.Id;
                        DfsNodeMin = DfsNodeTemp;
                    }


                }
                DFSNode notetemp = visitedDFSNode.Find(a => a.Node == DfsNodeMin.Node);
                if(notetemp==null)
                {
                    visitedDFSNode.Add(DfsNodeMin);
                }
                DFSStack.Push(DfsNodeMin);
                
                MinIndex = int.MaxValue;
            }

        }
    }

    public class DFSNode
    {
        public Node Node;
        public int Id;

        public DFSNode(Node node, int id)
        {
            Node = node;
            Id = id;
        }

    }
}
