//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bloga.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_role
    {
        public int USERROLID { get; set; }
        public int ROLEID { get; set; }
        public int USERID { get; set; }
    
        public virtual role role { get; set; }
        public virtual user user { get; set; }
    }
}
