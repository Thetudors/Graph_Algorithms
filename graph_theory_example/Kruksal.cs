using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
    public class Kruksal
    {
        public List<Arc> ArcList;
        List<Node> visited;
        public List<Arc> TraversalArcList;


        public Kruksal(Graph graph)
        {

            List<Arc> arc_list = new List<Arc>();

            foreach (var Node in graph.AllNodes)
            {
                foreach (var Arc in Node.Arcs)
                {
                    arc_list.Add(Arc);
                }
            }


            arc_list = arc_list.OrderBy(w => w.Weigth).ToList();


            ArcList = arc_list;
            Traversal();
        }

        public void getListMbox()
        {
            string temp = "";
            foreach (var item in TraversalArcList)
            {
                temp += item.Parent.Name+ "-"+item.Child.Name +"\n" ;
            }

            System.Windows.Forms.MessageBox.Show(temp);
        }

        public void Traversal()
        {
            TraversalArcList = new List<Arc>();
            visited = new List<Node>();

            foreach (var Arc in ArcList)
            {
                Node child = visited.Find(a => a == Arc.Child);
                Node parent = visited.Find(a => a == Arc.Parent);

                if (child != null && parent != null)
                    continue;

                if (child == null || parent == null)
                    TraversalArcList.Add(Arc);

                if (child == null)
                    visited.Add(Arc.Child);

                if (parent == null)
                    visited.Add(Arc.Parent);
            }

        }



    }

}
