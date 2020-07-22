using Covid.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Server.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Display(Name = "工号")]
        [Required(ErrorMessage = "{0}时必填项")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0}的长度必须是{1}")]
        public string No { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}时必填项")]
        [StringLength(50, ErrorMessage = "{0}的长度不能超过{1}")]
        public string Name { get; set; }

        [Display(Name = "图片地址")]
        [StringLength(500, ErrorMessage = "{0}的长度不能超过{1}")]
        public string PictureUrl { get; set; }

        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
    }
}
