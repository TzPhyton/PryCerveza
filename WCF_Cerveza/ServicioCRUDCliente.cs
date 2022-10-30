using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Cerveza
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCRUDCliente" en el código y en el archivo de configuración a la vez.
    public class ServicioCRUDCliente : IServicioCRUDCliente
    {
        CERVECERIA_CLLEntities Cerveceria = new CERVECERIA_CLLEntities();

        public List<ClienteDC> ListarCliente()
        {
            try
            {
                List<ClienteDC> objListaClienteDC = new List<ClienteDC>();

                var query = (from miCliente in Cerveceria.TB_Cliente
                             orderby miCliente.ape_cli
                             select miCliente).ToList();
                foreach (var objCliente in query)
                { 
                    ClienteDC objClienteDC = new ClienteDC();
                    objClienteDC.id_cliente = objCliente.id_cliente;
                    objClienteDC.id_Ubigeo = objCliente.id_Ubigeo;
                    objClienteDC.Departamento = objCliente.TB_Ubigeo.Departamento;
                    objClienteDC.Provincia = objCliente.TB_Ubigeo.Provincia;
                    objClienteDC.Distrito = objCliente.TB_Ubigeo.Distrito;
                    objClienteDC.tipo_cli = objCliente.tipo_cli;
                    objClienteDC.nom_cli = objCliente.nom_cli;
                    objClienteDC.ape_cli = objCliente.ape_cli;
                    objClienteDC.ruc_cli = objCliente.ruc_cli;
                    objClienteDC.dni_cli = objCliente.dni_cli;
                    objClienteDC.direccion_cli = objCliente.direccion_cli;
                    objClienteDC.raz_soc_cli = objCliente.raz_soc_cli;
                    objClienteDC.fec_reg_cli = Convert.ToDateTime(objCliente.fec_reg_cli);
                    objClienteDC.usu_reg_cli = objCliente.usu_reg_cli;
                    objClienteDC.fec_ultm_mod_cli = Convert.ToDateTime(objCliente.fec_ultm_mod_cli);
                    objClienteDC.usu_ultm_mod_cli = objCliente.usu_ultm_mod_cli;
                    objClienteDC.estado_cli = objCliente.estado_cli;
                    objListaClienteDC.Add(objClienteDC);
                }
                return objListaClienteDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarCliente(ClienteDC objClienteDC)
        {
            try
            {
                Cerveceria.usp_InsertarCliente
                    (objClienteDC.id_Ubigeo,objClienteDC.tipo_cli,objClienteDC.nom_cli,objClienteDC.ape_cli
                    ,objClienteDC.ruc_cli,objClienteDC.dni_cli,objClienteDC.direccion_cli,objClienteDC.raz_soc_cli,objClienteDC.usu_reg_cli,objClienteDC.estado_cli);

                Cerveceria.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarCliente(ClienteDC objClienteDC)
        {
            try
            {
                Cerveceria.usp_ActualizarCliente
                    (
                        objClienteDC.id_cliente,objClienteDC.id_Ubigeo,objClienteDC.tipo_cli,objClienteDC.nom_cli,objClienteDC.ape_cli,objClienteDC.ruc_cli,objClienteDC.dni_cli,
                        objClienteDC.direccion_cli,objClienteDC.raz_soc_cli,objClienteDC.usu_ultm_mod_cli,objClienteDC.estado_cli
                    );

                Cerveceria.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarCliente(String strCodigo)
        {
            try
            {
                Cerveceria.usp_EliminarCliente(strCodigo);

                Cerveceria.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
