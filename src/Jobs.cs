namespace HangfireExample;

[ManagementPage(MenuName = "Jobs", Title = nameof(Jobs))]
public class Jobs : IJob
{
    [DisplayName("Job1")]
    [Description("Do something")]
    [Queue("something")]
    public async Task Handle1(
        PerformContext context,
        IJobCancellationToken cancellationToken,
        [DisplayData(Label = "Await Time [ms]", IsRequired = true)] int time)
    {
        Console.WriteLine(context.BackgroundJob.Id);
        await Task.Delay(time, cancellationToken.ShutdownToken);
    }
}