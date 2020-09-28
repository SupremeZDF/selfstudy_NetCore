using System;
using System.Collections.Generic;
using System.Text;

namespace Swagger.JwtRepostory.Model
{
    public interface IBaseRepostory<T> where T : class, new()
    {
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<T> GetPageList(int pageindex, int pageSize);

        /// <summary>
        /// 获取单一的数据
        /// </summary>
        /// <returns></returns>
        T GetOnly(int id);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteData(int id);
    }
}
