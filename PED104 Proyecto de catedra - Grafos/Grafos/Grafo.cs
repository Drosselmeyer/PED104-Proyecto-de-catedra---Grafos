using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PED104_Proyecto_de_catedra___Grafos.Grafos
{
    class Grafo
    {
        public Grafo()
        {
            m_nodeSet = new Dictionary<string, Nodo>();
            nodes = new List<Nodo>();
            edges = new List<Edge>();
            m_eventListeners = new List<Object>();
            m_adjacencySet = new Dictionary<string, Dictionary<string, List<Edge>>>();
        }
        public void Clear()
        {
            nodes.Clear();
            edges.Clear();
            m_adjacencySet.Clear();
        }
        public Nodo AddNodo(Nodo iNodo)
        {
            if (!m_nodeSet.ContainsKey(iNodo.ID))
            {
                nodes.Add(iNodo);
            }

            m_nodeSet[iNodo.ID] = iNodo;
            notify();
            return iNodo;
        }

        public Edge AddEdge(Edge iEdge)
        {
            if (!edges.Contains(iEdge))
                edges.Add(iEdge);


            if (!(m_adjacencySet.ContainsKey(iEdge.Source.ID)))
            {
                m_adjacencySet[iEdge.Source.ID] = new Dictionary<string, List<Edge>>();
            }
            if (!(m_adjacencySet[iEdge.Source.ID].ContainsKey(iEdge.Target.ID)))
            {
                m_adjacencySet[iEdge.Source.ID][iEdge.Target.ID] = new List<Edge>();
            }


            if (!m_adjacencySet[iEdge.Source.ID][iEdge.Target.ID].Contains(iEdge))
            {
                m_adjacencySet[iEdge.Source.ID][iEdge.Target.ID].Add(iEdge);
            }

            notify();
            return iEdge;
        }
        public void CreateNodos(List<DatosGrafo> iDataList)
        {
            for (int listTrav = 0; listTrav < iDataList.Count; listTrav++)
            {
                CreateNodo(iDataList[listTrav]);
            }
        }

        public void CreateNodos(List<string> iNameList)
        {
            for (int listTrav = 0; listTrav < iNameList.Count; listTrav++)
            {
                CreateNodo(iNameList[listTrav]);
            }
        }

        public void CreateEdges(List<Object> iDataList)
        {
            for (int listTrav = 0; listTrav < iDataList.Count; listTrav++)
            {
                //if (!m_nodeSet.ContainsKey(iDataList[listTrav].first))
                //    return;
                //if (!m_nodeSet.ContainsKey(iDataList[listTrav].second))
                //    return;
                //Nodo node1 = m_nodeSet[iDataList[listTrav].first];
                //Nodo node2 = m_nodeSet[iDataList[listTrav].second];
                //CreateEdge(node1, node2, iDataList[listTrav].third);
            }
        }

        //public void CreateEdges(List<Object> iDataList)
        //{
        //    for (int listTrav = 0; listTrav < iDataList.Count; listTrav++)
        //    {
        //        if (!m_nodeSet.ContainsKey(iDataList[listTrav].first))
        //            return;
        //        if (!m_nodeSet.ContainsKey(iDataList[listTrav].second))
        //            return;
        //        Nodo node1 = m_nodeSet[iDataList[listTrav].first];
        //        Nodo node2 = m_nodeSet[iDataList[listTrav].second];
        //        CreateEdge(node1, node2);
        //    }
        //}

        public Nodo CreateNodo(DatosGrafo data)
        {
            Nodo tNewNodo = new Nodo(m_nextNodoId.ToString(), data);
            m_nextNodoId++;
            AddNodo(tNewNodo);
            return tNewNodo;
        }

        public Nodo CreateNodo(string label)
        {
            DatosGrafo data = new DatosGrafo();
            data.label = label;
            Nodo tNewNodo = new Nodo(m_nextNodoId.ToString(), data);
            m_nextNodoId++;
            AddNodo(tNewNodo);
            return tNewNodo;
        }

        public Edge CreateEdge(Nodo iSource, Nodo iTarget, EdgeData iData = null)
        {
            if (iSource == null || iTarget == null)
                return null;

            Edge tNewEdge = new Edge(m_nextEdgeId.ToString(), iSource, iTarget, iData);
            m_nextEdgeId++;
            AddEdge(tNewEdge);
            return tNewEdge;
        }

        public Edge CreateEdge(string iSource, string iTarget, EdgeData iData = null)
        {
            if (!m_nodeSet.ContainsKey(iSource))
                return null;
            if (!m_nodeSet.ContainsKey(iTarget))
                return null;
            Nodo node1 = m_nodeSet[iSource];
            Nodo node2 = m_nodeSet[iTarget];
            return CreateEdge(node1, node2, iData);
        }


        public List<Edge> GetEdges(Nodo iNodo1, Nodo iNodo2)
        {
            if (m_adjacencySet.ContainsKey(iNodo1.ID) && m_adjacencySet[iNodo1.ID].ContainsKey(iNodo2.ID))
            {
                return m_adjacencySet[iNodo1.ID][iNodo2.ID];
            }
            return null;
        }

        public List<Edge> GetEdges(Nodo iNodo)
        {
            List<Edge> retEdgeList = new List<Edge>();
            if (m_adjacencySet.ContainsKey(iNodo.ID))
            {
                foreach (KeyValuePair<string, List<Edge>> keyPair in m_adjacencySet[iNodo.ID])
                {
                    foreach (Edge e in keyPair.Value)
                    {
                        retEdgeList.Add(e);
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, List<Edge>>> keyValuePair in m_adjacencySet)
            {
                if (keyValuePair.Key != iNodo.ID)
                {
                    foreach (KeyValuePair<string, List<Edge>> keyPair in m_adjacencySet[keyValuePair.Key])
                    {
                        foreach (Edge e in keyPair.Value)
                        {
                            retEdgeList.Add(e);
                        }
                    }

                }
            }
            return retEdgeList;
        }

        public void RemoveNodo(Nodo iNodo)
        {
            if (m_nodeSet.ContainsKey(iNodo.ID))
            {
                m_nodeSet.Remove(iNodo.ID);
            }
            nodes.Remove(iNodo);
            DetachNodo(iNodo);

        }
        public void DetachNodo(Nodo iNodo)
        {
            edges.ForEach(delegate (Edge e)
            {
                if (e.Source.ID == iNodo.ID || e.Target.ID == iNodo.ID)
                {
                    RemoveEdge(e);
                }
            });
            notify();
        }

        public void RemoveEdge(Edge iEdge)
        {
            edges.Remove(iEdge);
            foreach (KeyValuePair<string, Dictionary<string, List<Edge>>> x in m_adjacencySet)
            {
                foreach (KeyValuePair<string, List<Edge>> y in x.Value)
                {
                    List<Edge> tEdges = y.Value;
                    tEdges.Remove(iEdge);
                    if (tEdges.Count == 0)
                    {
                        m_adjacencySet[x.Key].Remove(y.Key);
                        break;
                    }
                }
                if (x.Value.Count == 0)
                {
                    m_adjacencySet.Remove(x.Key);
                    break;
                }
            }
            notify();

        }

        public Nodo GetNodo(string label)
        {
            Nodo retNodo = null;
            nodes.ForEach(delegate (Nodo n)
            {
                if (n.Datos.label == label)
                {
                    retNodo = n;
                }
            });
            return retNodo;
        }

        public Edge GetEdge(string label)
        {
            Edge retEdge = null;
            edges.ForEach(delegate (Edge e)
            {
                if (e.Data.label == label)
                {
                    retEdge = e;
                }
            });
            return retEdge;
        }
        public void Merge(Grafo iMergeGraph)
        {
            foreach (Nodo n in iMergeGraph.nodes)
            {
                Nodo mergeNodo = new Nodo(m_nextNodoId.ToString(), n.Datos);
                AddNodo(mergeNodo);
                m_nextNodoId++;
                mergeNodo.Datos.origID = n.ID;
            }

            foreach (Edge e in iMergeGraph.edges)
            {
                Nodo fromNodo = nodes.Find(delegate (Nodo n)
                {
                    if (e.Source.ID == n.Datos.origID)
                    {
                        return true;
                    }
                    return false;
                });

                Nodo toNodo = nodes.Find(delegate (Nodo n)
                {
                    if (e.Target.ID == n.Datos.origID)
                    {
                        return true;
                    }
                    return false;
                });

                Edge tNewEdge = AddEdge(new Edge(m_nextEdgeId.ToString(), fromNodo, toNodo, e.Data));
                m_nextEdgeId++;
            }
        }

        public void FilterNodos(Predicate<Nodo> match)
        {
            foreach (Nodo n in nodes)
            {
                if (!match(n))
                    RemoveNodo(n);
            }
        }

        public void FilterEdges(Predicate<Edge> match)
        {
            foreach (Edge e in edges)
            {
                if (!match(e))
                    RemoveEdge(e);
            }

        }

        public void AddGraphListener(Object iListener)
        {
            m_eventListeners.Add(iListener);
        }

        private void notify()
        {
            foreach (Object listener in m_eventListeners)
            {
                //listener.GraphChanged();
            }
        }

        public List<Nodo> nodes
        {
            get;
            private set;
        }
        public List<Edge> edges
        {
            get;
            private set;
        }

        private Dictionary<string, Nodo> m_nodeSet;
        private Dictionary<string, Dictionary<string, List<Edge>>> m_adjacencySet;

        private int m_nextNodoId = 0;
        private int m_nextEdgeId = 0;
        private List<Object> m_eventListeners;
    }

}
}

