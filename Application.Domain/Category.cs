using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{
    public class Category:BaseEntity
    {        
        public string Name { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public Int64? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        [NotMapped]
        public string ParentCategoryName { get; set; }
    }
}
