//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Cerveza
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Producto()
        {
            this.TB_OrdenDespacho = new HashSet<TB_OrdenDespacho>();
        }
    
        public string ID_Producto { get; set; }
        public string id_UnidadMedida { get; set; }
        public string tipo_producto { get; set; }
        public string Descripcion { get; set; }
        public string Presentacion { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<int> Stock_min { get; set; }
        public Nullable<System.DateTime> fec_reg_pro { get; set; }
        public string usu_reg_pro { get; set; }
        public Nullable<System.DateTime> fec_ultm_mod_pro { get; set; }
        public string usu_ultm_mod_pro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_OrdenDespacho> TB_OrdenDespacho { get; set; }
    }
}
