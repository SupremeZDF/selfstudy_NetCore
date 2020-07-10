using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orm.MVC.Model
{
    public class User
    {
        [Required]
        [StringLength(6,ErrorMessage="sssss")]
        public string name { get; set; }

        [StringLength(6,ErrorMessage ="dadad")]
        public string jieshao { get; set; }
    }
}
