//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entradas
    {
        public int IdEntrada { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public int Cantidad { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
