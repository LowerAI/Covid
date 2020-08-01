using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid.Shared.Dtos
{
    public class EmployeeAddOrUpdateDto
    {
        [Display(Name = "工号")]
        [Required(ErrorMessage = "{0}时必填项")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "{0}的长度必须是{1}")]
        public string No { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}时必填项")]
        [StringLength(50, ErrorMessage = "{0}的长度不能超过{1}")]
        public string Name { get; set; }

        [Display(Name = "照片地址")]
        [StringLength(500, ErrorMessage = "{0}的长度不能超过{1}")]
        public string PictureUrl { get; set; }

        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
    }
}
