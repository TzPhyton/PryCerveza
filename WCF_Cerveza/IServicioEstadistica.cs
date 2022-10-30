using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Cerveza
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioEstadistica" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioEstadistica
    {
        [OperationContract]
        List<ProductoEstadistica> RankingProducto(Int16 año, Int16 top);

        [OperationContract]
        List<ClienteEstadistica> RankingClienteOrdenesAño(DateTime fec_ini, DateTime fec_fin);

        [OperationContract]
        List<EstadisticaDepartamento> RankingDepartamentoOrdenDespacho();

        [OperationContract]
        List<EstadisticaDespachoAño> CantidadOrdenDespachoAño(Int16 año);

    }
    [DataContract]
    [Serializable]
    
    public class ProductoEstadistica
    {
        
        [DataMember]
        public String nom_producto { get; set; } //Por editar
        [DataMember]
        public Int16 cantidad { get; set; } //Por editar
    }
    [DataContract]
    [Serializable]
    public class ClienteEstadistica
    {
        [DataMember]
        public String nom_cli { get; set; }
        [DataMember]

        public Int16 cantidad_des { get; set; }
    }
    [DataContract]
    [Serializable]
    public class EstadisticaDepartamento
    {
        
        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public Int16 Total_Ordenes { get; set; }
    }
    public class EstadisticaDespachoAño
    {
        [DataMember]
       
        public Int16 cantidad_des { get; set; }
    }
}
