using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Orm.MVC.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Orm.MVC.Page
{
    public class T_QuestionPageModel : PageModel
    {
        //public readonly DataContenx _contenx;

        //public T_QuestionPageModel(DataContenx contenx)
        //{
        //    _contenx = contenx;
        //    t_Questions= _contenx.t_Questions.ToList(); 
        //}

        //public List<T_Question> t_Questions { get; set; }

        //public async Task IndexModel() 
        //{
        //    t_Questions = await _contenx.t_Questions.ToListAsync();
        //}

    }
}
