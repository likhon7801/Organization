
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ScholarshipHub.Models
{

using System;
    using System.Collections.Generic;
    
public partial class UniversityOffer
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public UniversityOffer()
    {

        this.ApplictionsToUniversities = new HashSet<ApplictionsToUniversity>();

    }


    public int id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string OfferedDegree { get; set; }

    public string Requirements { get; set; }

    public System.DateTime Deadline { get; set; }

    public System.DateTime StartDate { get; set; }

    public int UniversityId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ApplictionsToUniversity> ApplictionsToUniversities { get; set; }

    public virtual University University { get; set; }

}

}
