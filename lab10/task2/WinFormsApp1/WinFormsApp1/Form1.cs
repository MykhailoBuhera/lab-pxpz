using System;
using System.Collections.Generic; // Додано для List<T>
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Graph g;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGraphData();

            PopulateGrids();
        }


        private void InitializeGraphData()
        {
            int V = 6;
            string[] vertexNames = { "a", "b", "c", "d", "e", "f" };
            g = new Graph(V, vertexNames); 

            g.AddEdge(0, 0); 
            g.AddEdge(0, 1); 
            g.AddEdge(1, 1); 
            g.AddEdge(1, 2); 
            g.AddEdge(1, 5); 
            g.AddEdge(2, 2); 
            g.AddEdge(2, 5); 
            g.AddEdge(3, 3); 
            g.AddEdge(3, 5); 
            g.AddEdge(4, 4); 
            g.AddEdge(4, 2); 
            g.AddEdge(5, 3); 
        }


        private void PopulateGrids()
        {

            int[,] adjMatrix = g.GetAdjacencyMatrix();
            int[,] incMatrix = g.GetIncidenceMatrix();


            PopulateDataGridView(dgvAdjacency, adjMatrix, g.VertexNames, g.VertexNames);
            PopulateDataGridView(dgvIncidence, incMatrix, g.VertexNames, g.EdgeNames);
        }
//dodatkova metod dla zapocnennya table
        private void PopulateDataGridView(DataGridView dgv, int[,] matrix, string[] rowHeaders, string[] colHeaders)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            foreach (var colName in colHeaders)
            {
                dgv.Columns.Add(colName, colName);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].HeaderCell.Value = rowHeaders[i];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dgv.Rows[rowIndex].Cells[j].Value = matrix[i, j];
                }
            }
        }
    }

    public class Graph
    {
        public int NumVertices { get; }
        public string[] VertexNames { get; }
        public List<Edge> Edges { get; }
        public string[] EdgeNames { get; private set; }

        public class Edge
        {
            public int From { get; }
            public int To { get; }
            public Edge(int from, int to) { From = from; To = to; }
        }

        public Graph(int numVertices, string[] vertexNames)
        {
            NumVertices = numVertices;
            VertexNames = vertexNames;
            Edges = new List<Edge>();
            EdgeNames = new string[0];
        }

        public void AddEdge(int from, int to)
        {
            Edges.Add(new Edge(from, to));
            UpdateEdgeNames();
        }

        private void UpdateEdgeNames()
        {
            EdgeNames = new string[Edges.Count];
            for (int i = 0; i < Edges.Count; i++)
            {
                EdgeNames[i] = $"e{i + 1}";
            }
        }

        public int[,] GetAdjacencyMatrix()
        {
            int[,] matrix = new int[NumVertices, NumVertices];
            foreach (var edge in Edges)
            {
                matrix[edge.From, edge.To] = 1;
            }
            return matrix;
        }

        public int[,] GetIncidenceMatrix()
        {
            int numEdges = Edges.Count;
            int[,] matrix = new int[NumVertices, numEdges];

            for (int j = 0; j < numEdges; j++)
            {
                var edge = Edges[j];
                if (edge.From == edge.To)
                {
                    matrix[edge.From, j] = 0; // Петля
                }
                else
                {
                    matrix[edge.From, j] = 1;  // Виходить
                    matrix[edge.To, j] = -1; // Входить
                }
            }
            return matrix;
        }
    }
}