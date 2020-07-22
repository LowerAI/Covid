using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Server.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "部门")]
        [Required(ErrorMessage = "{0}时必填项")]
        [MaxLength(50, ErrorMessage = "{0}的长度不能超过{1}")]
        public string Name { get; set; }
    }
}
