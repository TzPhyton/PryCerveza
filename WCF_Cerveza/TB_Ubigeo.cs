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
    
    public partial class TB_Ubigeo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Ubigeo()
        {
            this.TB_Cliente = new HashSet<TB_Cliente>();
        }
    
        public string id_Ubigeo { get; set; }
        public string idDepa { get; set; }
        public string idDistr { get; set; }
        public string idProv { get; set; }
        public string Departamento { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Cliente> TB_Cliente { get; set; }
    }
}