using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid.Shared.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Display(Name = "工号")]
        public string No { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "照片地址")]
        public string PictureUrl { get; set; }

        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
    }
}
