using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringGraph
{
    public class GraphNode
    {
        private string id;
        private LinkedList<string> adjList;

        // Constructor: Initializes a new instance of the GraphNode class with the specified ID.
        public GraphNode(string id)
        {
            this.id = id;
            adjList = new LinkedList<string>();
        }

        // Gets or sets the ID of the node.
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        // Adds an edge between this node and the specified node.
        public void AddEdge(GraphNode to)
        {
            adjList.AddLast(to.ID);
        }

        // Returns the adjacency list of this node.
        public LinkedList<string> GetAdjList()
        {
            return adjList;
        }
    }
}
