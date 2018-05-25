using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace graph_theory_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] Buttons;
        int[] ButtonsID;
        Kruksal kuruskal;
        Prim prim;
        Graph graph;
       
        BFS bfs;
        DFS dfs;
        private void Form1_Load(object sender, EventArgs e)
        {


            Graph SocialGraph = new Graph();

            SocialNetwork s = new SocialNetwork(SocialGraph);

            Node Anode = SocialGraph.CreateRoot("A",0);
            s.CreateSocialNetworkNode(Anode, "Olivia", "Doctor");
            Node Bnode = SocialGraph.CreateNode("B",1);
            s.CreateSocialNetworkNode(Bnode, "Celine", "Engineer");
            Node Cnode = SocialGraph.CreateNode("C",2);
            s.CreateSocialNetworkNode(Cnode, "Winston", "Politician");
            Node Dnode = SocialGraph.CreateNode("D",3);
            s.CreateSocialNetworkNode(Dnode, "Chloe", "Architect");
            Node Enode = SocialGraph.CreateNode("E",4);
            s.CreateSocialNetworkNode(Enode, "John", "Officer");
            Node Fnode = SocialGraph.CreateNode("F",5);
            s.CreateSocialNetworkNode(Fnode, "Jack", "Professor");

            Anode.AddArc(Bnode, 5).AddArc(Enode, 12).AddArc(Fnode, 8);
            Bnode.AddArc(Fnode, 6).AddArc(Cnode, 10);
            Cnode.AddArc(Fnode, 16).AddArc(Dnode, 15);
            Dnode.AddArc(Fnode, 4).AddArc(Enode, 9);
            Enode.AddArc(Fnode, 7);
            DrawSocialGraph(s);

            dijkstra d2 = new dijkstra(Anode, Dnode, SocialGraph);
            label7.Text = d2.getListText();

            graph = new Graph();
            Node aNode = graph.CreateRoot("A");
            Node bNode = graph.CreateNode("B");
            Node cNode = graph.CreateNode("C");
            Node dNode = graph.CreateNode("D");
            Node eNode = graph.CreateNode("E");

            aNode.AddArc(cNode, 1).AddArc(bNode, 2);
            bNode.AddArc(cNode, 3);
            cNode.AddArc(dNode, 1).AddArc(eNode, 4);
            dNode.AddArc(eNode, 1);

            kuruskal = new Kruksal(graph);
            prim = new Prim(aNode, graph);
           
           
            

        }
        public void DrawSocialGraph(SocialNetwork graph)
        {
            Buttons = new Button[graph.AllsnNode.Count];
            Buttons[0] = button1;
            Buttons[1] = button2;
            Buttons[2] = button3;
            Buttons[3] = button4;
            Buttons[4] = button5;
            Buttons[5] = button6;
            ButtonsID = new int[40];

            int i = 0;
            int j = 0;

            foreach (var node in graph.AllsnNode)
            {
                Buttons[i].Text = node.UserName +"\n"+node.Job +"\n"+node.Node.Name;
                i++;
                foreach (var arc in node.Node.Arcs)
                {
                    ButtonsID[j] = arc.Parent.ID;
                    j++;
                    ButtonsID[j] = arc.Child.ID;
                    j++;
                }
            }


        }



        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = panel1.CreateGraphics();
            Brush b = new SolidBrush(Color.Green);
            Pen p = new Pen(Color.Black, 2);
           for(int i = 0; i<ButtonsID.Length-1;i++)
            {
                Point p1 = new Point(Buttons[ButtonsID[i]].Location.X, Buttons[ButtonsID[i]].Location.Y);
                Point p2 = new Point(Buttons[ButtonsID[i+1]].Location.X, Buttons[ButtonsID[i+1]].Location.Y);
                gObject.DrawLine(p, p1, p2);
            }
               
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kuruskal.getListMbox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            prim.getListMbox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Node Node1 = new Node("defualt");
            foreach (var item in graph.AllNodes)
            {
                if(item.Name == textBox1.Text)
                {
                     Node1 = item;
                }
            }
            dijkstra d = new dijkstra(Node1, Node1, graph);
            d.getListMbox(textBox2.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Node Node1 = new Node("defualt");
            foreach (var item in graph.AllNodes)
            {
                if (item.Name == textBox3.Text)
                {
                    Node1 = item;
                }
            }
            bfs = new BFS(Node1, graph);
            bfs.getListMbox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Node Node1 = new Node("defualt");
            foreach (var item in graph.AllNodes)
            {
                if (item.Name == textBox4.Text)
                {
                    Node1 = item;
                }
            }
            
          
            dfs = new DFS(Node1,graph);
            dfs.getListMbox();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            EdmonsKarp e1 = new EdmonsKarp();

            int[,] capacityMatrix = new int[7, 7];

            int[,] legalFlows;

            capacityMatrix[1, 2] = 3;
            capacityMatrix[2, 1] = 3;
            capacityMatrix[1, 3] = 5;
            capacityMatrix[3, 1] = 5;
            capacityMatrix[2, 4] = 3;
            capacityMatrix[3, 5] = 6;
            capacityMatrix[4, 5] = 9;
            capacityMatrix[5, 4] = 9;
            capacityMatrix[5, 6] = 8;
            capacityMatrix[4, 6] = 10;
            capacityMatrix[6, 5] = 8;
            capacityMatrix[6, 4] = 10;


            Dictionary<int, List<int>> neighbors = new Dictionary<int, List<int>>();

            List<int> bir = new List<int>();
            bir.Add(2);
            bir.Add(3);

            List<int> iki = new List<int>();
            iki.Add(4);
            iki.Add(1);

            List<int> uc = new List<int>();
            uc.Add(1);
            uc.Add(5);

            List<int> dört = new List<int>();
            dört.Add(2);
            dört.Add(5);
            dört.Add(6);

            List<int> bes = new List<int>();
            bes.Add(3);
            bes.Add(4);
            bes.Add(6);

            List<int> altı = new List<int>();
            altı.Add(4);
            altı.Add(5);


            neighbors.Add(1, bir);
            neighbors.Add(2, iki);
            neighbors.Add(3, uc);
            neighbors.Add(4, dört);
            neighbors.Add(5, bes);
            neighbors.Add(6, altı);


            int source = 1;

            int sink = 6;


            int a = e1.FindMaxFlow(capacityMatrix, neighbors, source, sink, out legalFlows);

            MessageBox.Show("maksimum akış (EdmondsKarp):"+a.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FordFulkerson a1 = new FordFulkerson();
            a1.cap = new int[6, 6];

            a1.cap[0, 1] = 3;
            a1.cap[1, 0] = 3;
            a1.cap[0, 2] = 5;
            a1.cap[2, 0] = 5;
            a1.cap[1, 3] = 3;
            a1.cap[2, 4] = 6;
            a1.cap[3, 4] = 9;
            a1.cap[4, 3] = 9;
            a1.cap[4, 5] = 8;
            a1.cap[3, 5] = 10;
            a1.cap[3, 4] = 8;
            a1.cap[5, 3] = 10;

            a1.fordF(6, 0, 5);

        }

      
    }
}
