using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PED104_Proyecto_de_catedra___Grafos.Grafos
{
    class Nodo
    {
        //Definimos las propiedades
        public string ID { get; set; }
        public DatosGrafo Datos { get; set; }
        public bool Fijo { get; set; }


        //Definimos el constructor
        public Nodo(string iId, Object iData = null)
        {
            ID = iId;
            Datos = new DatosGrafo(); //Este objeto sera de las clases del proyecto

            if (iData != null)
            {
                //Por definir aun en las clases de la base de datos

            }
        }

         public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Nodo p = obj as Nodo;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == p.ID);
        }

        public bool Equals(Nodo p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == p.ID);
        }

        //public static bool operator(Nodo a, Nod0 b)
        //{
        //    // If both are null, or both are same instance, return true.
        //    if (System.Object.ReferenceEquals(a, b))
        //    {
        //        return true;
        //    }

        //    // If one is null, but not both, return false.
        //    if (((object)a == null) || ((object)b == null))
        //    {
        //        return false;
        //    }

        //    // Return true if the fields match:
        //    return a.ID == b.ID;
        //}

    }
}
