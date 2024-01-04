using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_B;

namespace stringGraph
{
    public class Graph
    {
        // a list that will hold the nodes in the graph
        private LinkedList<GraphNode> nodes;

        // constructor to set the list of nodes to an empty list
        public Graph()
        {
            nodes = new LinkedList<GraphNode>();
        }

        // method to add a node to the graph
        public void AddNode(string id)
        {
            // Create a new GraphNode with the specified ID and add it to the list of nodes
            nodes.AddLast(new GraphNode(id));
        }

        // method to remove a node from the graph and update adjacency lists
        public void RemoveNode(string id)
        {
            GraphNode nodeToRemove = null;

            // Find the node to remove
            foreach (GraphNode node in nodes)
            {
                if (node.ID == id)
                {
                    nodeToRemove = node;
                    break;
                }
            }

            if (nodeToRemove != null)
            {
                // Remove the node from the list
                nodes.Remove(nodeToRemove);

                // Remove the connections to the node from other nodes' adjacency lists
                foreach (GraphNode node in nodes)
                {
                    if (node.GetAdjList().Contains(id))
                    {
                        node.GetAdjList().Remove(id);
                    }
                }
            }
        }

        // return node when ID specified
        public GraphNode GetNode(string id)
        {
            foreach (GraphNode node in nodes)
            {
                if (id.CompareTo(node.ID) == 0)
                    return node;
            }

            return null;
        }

        // add a directed edge between node "from" and node "to" (specified by their IDs)
        public void AddEdge(string from, string to)
        {
            // Get the GraphNode that corresponds to the node with ID = from
            GraphNode node1 = GetNode(from);

            // Get the GraphNode that corresponds to the node with ID = to
            GraphNode node2 = GetNode(to);

            // Add a directed edge from node1 to node2
            node1.AddEdge(node2);
        }

        // check if the graph is empty
        public bool IsEmptyGraph()
        {
            // If the number of elements within the list of nodes is equal to 0, return true; else return false
            return nodes.Count == 0;
        }

        // get the number of nodes in the graph
        public int NumberOfNodes()
        {
            return nodes.Count;
        }

        // display the adjacency nodes of a given node
        public List<string> DisplayAdjNodes(string inputID)
        {
            // Define a list where we are going to store the adjacency list of the node
            LinkedList<string> friends = new LinkedList<string>();

            // Get the GraphNode of the node with ID = inputID
            GraphNode n = GetNode(inputID);

            // Get and store the adjacency list of the node in "friends"
            friends = n.GetAdjList();

            // Convert the adjacency list to a list of node IDs
            List<string> nodeIds = new List<string>();
            foreach (string ni in friends)
            {
                nodeIds.Add(ni);
            }
            return nodeIds;
        }

        // return true only if the node with the specific ID (passed as argument) is present in the graph
        public bool ContainsGraph(string ID)
        {
            foreach (GraphNode n in nodes)
            {
                // Check if the ID of node "n" is equal to the ID passed as the input argument
                if (n.ID.CompareTo(ID) == 0)
                    return true;
            }

            // The foreach loop completed, but the node has not been found, so return false
            return false;
        }

        // method to display the graph
        public List<string> DisplayGraph()
        {
            List<string> nodeIds = new List<string>();
            foreach (GraphNode n in nodes)
            {
                nodeIds.Add(n.ID);
            }
            return nodeIds;
        }

        public List<string> DepthFirstTraverse(string startID)
        {
            LinkedList<string> adj;
            Stack<string> toVisit = new Stack<string>();
            toVisit.Push(startID);
            string currentID;
            List<string> visited = new List<string>();

            while (toVisit.Count != 0)
            {
                // Get the ID of the current node from toVisit
                currentID = toVisit.Pop();

                // Store the ID of the current node in "visited"
                visited.Add(currentID);

                // Get the adjacency list of the current node
                GraphNode currentNode = GetNode(currentID);
                adj = currentNode.GetAdjList();

                // Add each node "n" in the adjacency list to toVisit
                // (only if "n" is not in "visited" and not in "toVisit")
                foreach (string n in adj)
                {
                    if (!visited.Contains(n) && !toVisit.Contains(n))
                    {
                        toVisit.Push(n);
                    }
                }
            }

            return visited;
        }




    }
}
