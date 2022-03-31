using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PED104_Proyecto_de_catedra___Grafos.Grafos
{
    class DatosGrafo : GraphData
    {
        public DatosGrafo() : base()
        {
            Object objeto = new Object();
        }
        public float mass
        {
            get;
            set;
        }
    
        //Por definir cuando se decida el algoritmo de recorrido
        public Object initialPostion
        {
            get;
            set;
        }
        public string origID
        {
            get;
            set;
        }

    }
    public class EdgeData : GraphData
    {
        public EdgeData() : base()
        {
            length = 1.0f;
        }
        public float length
        {
            get;
            set;
        }
    }
    public class GraphData
    {
        public GraphData()
        {
            label = "";
        }


        public string label
        {
            get;
            set;
        }


    }
}
