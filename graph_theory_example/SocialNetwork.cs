using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class SocialNetwork
    {
        Graph graph;

        public List<SocialNetworkNode> AllsnNode;

        public SocialNetwork(Graph graph)
        {
            this.graph = graph;
            AllsnNode = new List<SocialNetworkNode>();
        }

        public Node CreateSocialNetworkNode(Node node,string username,string job)
        {    
            SocialNetworkNode socialNetworkNode = new SocialNetworkNode(node, username, job);
            AllsnNode.Add(socialNetworkNode);
           

            return node;

        }

        


       
    }

    public class SocialNetworkNode
    {
        public Node Node;
        public string UserName;
        public string Job;
        public SocialNetworkNode(Node node, string username,string job)
        {
            this.Node = node;
            this.UserName = username;
            this.Job = job;
        }
    }
}
