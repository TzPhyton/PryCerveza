using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WCF_Cerveza
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioEstadistica" en el código y en el archivo de configuración a la vez.
    public class ServicioEstadistica : IServicioEstadistica
    {
        //DECLARAMOS UNA INSTANCIA DEL MODELO 1233
        CERVECERIA_CLLEntities modelo = new CERVECERIA_CLLEntities();

        public List<ProductoEstadistica> RankingProducto(Int16 año, Int16 top)
        {
            try
            {
                List<ProductoEstadistica> objLista = new List<ProductoEstadistica>();

                var query = (from producto in modelo.vw_VistaProducto
                             orderby producto.Stock descending
                             select new
                             {
                                 producto.Descripcion,
                                 producto.Stock
                             }
                             ).Take(top);
                foreach (var item in query)
                {
                    ProductoEstadistica objProductoEstadistica = new ProductoEstadistica();
                    objProductoEstadistica.nom_producto = item.Descripcion;
                    objProductoEstadistica.cantidad = (short)Convert.ToSingle(item.Stock);
                    objLista.Add(objProductoEstadistica);
                }
                return objLista;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ClienteEstadistica> RankingClienteOrdenesAño(DateTime fec_ini, DateTime fec_fin)

        {
            try
            {
                List<ClienteEstadistica> objLista = new List<ClienteEstadistica>();
                var query = modelo.SpRankingCliente(fec_ini, fec_fin);
                foreach (var item in query)
                {
                    ClienteEstadistica objClienteEstadistica = new ClienteEstadistica();
                    objClienteEstadistica.nom_cli = item.nom_cli;
                    objClienteEstadistica.cantidad_des = (short)Convert.ToSingle(item.cantidad_des);
                    objLista.Add(objClienteEstadistica);
                }
                return objLista;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }

        }



          public List<EstadisticaDepartamento> RankingDepartamentoOrdenDespacho()
          {

              try
              {
                  List<EstadisticaDepartamento> objLista = new List<EstadisticaDepartamento>();
                var query = modelo.usp_DepartamentoMasOrdenDespacho();
                foreach (var item in query)
                  {
                      
                      EstadisticaDepartamento objEstadisticaDepartamento = new EstadisticaDepartamento();
                      objEstadisticaDepartamento.Departamento = item.Departamento;
                    objEstadisticaDepartamento.Total_Ordenes = (short)Convert.ToSingle(item.Total_Ordenes);
                    
                    /*objEstadisticaDepartamento.cantidad_des = (short)Convert.ToSingle(item.cantidad_des);*/
                      objLista.Add(objEstadisticaDepartamento);
                  }
                  return objLista;
              }
              catch (EntityException ex)
              {
                  throw new Exception(ex.Message);
              }
          }

        public List<EstadisticaDespachoAño> CantidadOrdenDespachoAño(Int16 año )
        {
        try
        {
            List<EstadisticaDespachoAño> objLista = new List<EstadisticaDespachoAño>();

                var query = (from despacho in modelo.vw_VistaOrdenDespacho
                             orderby despacho.cantidad_des descending
                             select new
                             {
                                                 despacho.cantidad_des
                             }
                             ).Take(año);
                foreach (var item in query)
                {
                    EstadisticaDespachoAño objEstadisticaDespachoAño = new EstadisticaDespachoAño();
                    
                    objEstadisticaDespachoAño.cantidad_des = (short)Convert.ToSingle(item.cantidad_des);
                    objLista.Add(objEstadisticaDespachoAño);
                }
                return objLista;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
