using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace NetcoreMvc.Model.TASK
{
    [PersistJobDataAfterExecution]  //保存上一次业务数据
    [DisallowConcurrentExecution]  //不允许重叠执行
    public class OneTask:IJob
    {
        /// <summary>
        /// 任务 发消息
        /// </summary>
        /// 
        public OneTask() 
        {
            Console.WriteLine("1");
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var a = context.JobDetail.JobDataMap.GetString("a");

            var b = context.Trigger.JobDataMap.GetString("b");

            var c = context.MergedJobDataMap.GetString("c");

            await Task.Run(() =>
            {
                Console.WriteLine("第一次任务执行");
            });
            //保存参数 提供下一次使用
            context.JobDetail.JobDataMap.Put("123",123);
        }
    }


    public class SayHI : IJob
    {

        public SayHI() 
        {
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {

            var a = context.JobDetail.JobDataMap.GetString("");
            context.MergedJobDataMap.GetString("");
            var key = context.JobDetail.Key;  //jobkey

            await Task.Run(() => 
            {
                Console.WriteLine("123456");
            });
        }
    }
}
