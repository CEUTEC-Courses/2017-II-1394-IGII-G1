//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoSoft2.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AreasPorCentro
    {
        public int IdAreasPorCentro { get; set; }
        public int IdArea { get; set; }
        public int IdCentro { get; set; }
    
        public virtual Areas Areas { get; set; }
        public virtual Centros Centros { get; set; }
    }
}
