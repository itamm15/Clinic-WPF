//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Badania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Badania()
        {
            this.Skierowanie = new HashSet<Skierowanie>();
        }
    
        public int BadanieId { get; set; }
        public Nullable<int> PacjentId { get; set; }
        public Nullable<int> LekarzId { get; set; }
        public string TypBadania { get; set; }
        public Nullable<System.DateTime> DataBadania { get; set; }
    
        public virtual Lekarze Lekarze { get; set; }
        public virtual Pacjenci Pacjenci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skierowanie> Skierowanie { get; set; }
    }
}
