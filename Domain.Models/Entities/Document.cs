using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    internal class Document
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
        public int? Course_Id { get; set; }
        public int? Module_Id { get; set; }
        public int? Activity_Id { get; set; }
        
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public DateTime UploadTime { get; set; }
        public string UploadBy { get; set; } // borde inte det vara en User?
        
        public string FileUrl { get; set; } // nånting som den här borde kanske finnas?

        // Navigational properties
        public ApplicationUser? User { get; set; }
        public Course? Course { get; set; }
        public Module? Module { get; set; }
        public ModuleActivity? Activity { get; set; }

    }
}
