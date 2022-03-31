using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PED104_Proyecto_de_catedra___Grafos.Grafos
{
    class Edge
    {
        public Edge(string iId, Nodo iSource, Nodo iTarget, EdgeData iData)
        {
            ID = iId;
            Source = iSource;
            Target = iTarget;
            Data = (iData != null) ? iData : new EdgeData();
            Directed = false;
        }

        public string ID
        {
            get;
            private set;
        }
        public EdgeData Data
        {
            get;
            private set;
        }

        public Nodo Source
        {
            get;
            private set;
        }

        public Nodo Target
        {
            get;
            private set;
        }

        public bool Directed
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Edge p = obj as Edge;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == p.ID);
        }

        public bool Equals(Edge p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == p.ID);
        }

        public static bool operator ==(Edge a, Edge b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.ID == b.ID;
        }

        public static bool operator !=(Edge a, Edge b)
        {
            return !(a == b);
        }
    }
}
