//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Menu = new HashSet<Menu>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int State { get; set; }
        public int UserType { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public Nullable<int> LastModifierId { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
