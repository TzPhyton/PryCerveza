using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Cerveza
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioCRUDCliente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioCRUDCliente
    {
        [OperationContract]
        List<ClienteDC> ListarCliente();

        [OperationContract]
        Boolean InsertarCliente(ClienteDC objClienteDC);

        [OperationContract]
        Boolean ActualizarCliente(ClienteDC objClienteDC);

        [OperationContract]
        Boolean EliminarCliente(String strCodigo);
    }
    [DataContract]
    [Serializable]
    public class ClienteDC
    {
        [DataMember]
        public String id_cliente { get; set; }
        [DataMember]
        public String id_Ubigeo { get; set; }
        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public String Provincia { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String tipo_cli { get; set; }
        [DataMember]
        public String nom_cli { get; set; }
        [DataMember]
        public String ape_cli { get; set; }
        [DataMember]
        public String ruc_cli { get; set; }
        [DataMember]
        public String dni_cli { get; set; }
        [DataMember]
        public String direccion_cli { get; set; }
        [DataMember]
        public String raz_soc_cli { get; set; }
        [DataMember]
        public DateTime fec_reg_cli { get; set; }
        [DataMember]
        public String usu_reg_cli { get; set; }
        [DataMember]
        public DateTime fec_ultm_mod_cli { get; set; }
        [DataMember]
        public String usu_ultm_mod_cli { get; set; }
        [DataMember]
        public String estado_cli { get; set; }
    }
}
