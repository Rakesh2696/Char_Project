//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Char_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnsTable
    {
        public int Id { get; set; }
        public string Answers { get; set; }
        public Nullable<int> QTableId { get; set; }
    
        public virtual QTable QTable { get; set; }
    }
}
