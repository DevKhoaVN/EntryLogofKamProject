using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;


namespace EntryLogManagement.Service
{
    public class ScheduleService
    {

        public async Task Scheduler()
        {
              StdSchedulerFactory factory = new StdSchedulerFactory();
              var Scheduler = await factory.GetScheduler(); 
              await Scheduler.Start();

              IJobDetail job = JobBuilder.Create<PhatCanhBaoJob>()
                         .WithIdentity("Phat canh bao" , "Nhom 1") 
                        .Build();

              ITrigger trigger = TriggerBuilder.Create()
                                 .WithIdentity("PhatCanhBao" ,"Nhom 1")
                                 .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(19, 10))
                                 .Build();
            
             await Scheduler.ScheduleJob(job , trigger);
                                 
        }


    public class PhatCanhBaoJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        MailService mailService = new MailService();
        SoundService soundService = new SoundService();
        
        mailService.SendEmail();
        soundService.PlaySound();

        return Task.CompletedTask;
    }
}

       
    }
}