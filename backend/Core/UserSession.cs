//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSession
    {
        public int Id { get; set; }
        public string SessionHash { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public int Role { get; set; }
    
        public virtual User User { get; set; }
    }
}
