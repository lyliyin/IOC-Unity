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
    
    public partial class Menu
    {
        public Menu()
        {
            this.User = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string SourcePath { get; set; }
        public int State { get; set; }
        public int MenuLevel { get; set; }
        public int Sort { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public Nullable<int> LastModifierId { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
    
        public virtual ICollection<User> User { get; set; }
    }
}
