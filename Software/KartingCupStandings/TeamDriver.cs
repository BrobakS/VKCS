//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KartingCupStandings
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamDriver
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int DriverId { get; set; }
    
        public virtual Driver Driver { get; set; }
    }
}
