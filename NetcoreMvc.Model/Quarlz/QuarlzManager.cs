using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NetcoreMvc.Model.TASK;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading.Tasks;
using static Quartz.Logging.OperationName;

namespace NetcoreMvc.Model.Quarlz
{
    public class QuarlzManager
    {
        /// <summary>
        /// 任务调度器工厂
        /// </summary>
        public async static void SchedulerFactory() 
        {
            //创建单元(时间线/载体)
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            //作业
            IJobDetail jobDetail = JobBuilder.Create<OneTask>().WithIdentity("cwJob","groupOne").WithDescription("this cw").Build();

            jobDetail.JobDataMap.Add("a","133");

            //时间策略  StartNow() 马上执行一次 执行四次 .StartNow()
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("cwTigger", "groupOne").
                WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(0).WithRepeatCount(2).RepeatForever()).Build();


            trigger.JobDataMap.Add("b","123");


            //承载 时间策略和作业 承载到单元上
            await scheduler.ScheduleJob(jobDetail,trigger);
            await scheduler.Shutdown();
        }

        /// <summary>
        /// 任务调度厂
        /// </summary>
        public async static void OneSchedulerFactory() 
        {
            StdSchedulerFactory stdSchedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await stdSchedulerFactory.GetScheduler();

            await scheduler.Start();

            //工作
            //DateBuilder dateBuilder = new DateBuilder()
            IJobDetail jobDetail = JobBuilder.Create<SayHI>().WithIdentity("myjob", "group1").Build();
            jobDetail.JobDataMap.Add("","");

            //触发器 事件策略
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("myTrigger", "group1").StartNow().WithCronSchedule("").WithSimpleSchedule(x=>x.WithIntervalInSeconds(30).RepeatForever()).Build();

            //trigger.start
            
        }


        public delegate void OneDeleGate();

        public class TwoName 
        {

            public  OneDeleGate Name;

            public void tWO() 
            {
                Name?.Invoke();
            }

            public void One() 
            {
                do
                {

                } while (true);
            }
        }

    }
}
