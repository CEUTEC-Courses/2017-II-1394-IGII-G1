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
    
    public partial class Respuestas
    {
        public int IdRespuesta { get; set; }
        public Nullable<int> IdPregunta { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Preguntas Preguntas { get; set; }
    }
}
