using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzBackgroundService.Services;
using Quartz.Impl.Calendar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "QuartzBackground Service",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        }
    });
});

builder.Services.AddHealthChecks();

// 1. ติดตั้ง Quartz
builder.Services.AddQuartz(q =>
{
    //q.UseMicrosoftDependencyInjectionJobFactory();

    // --- NotiDayEnd Job ---
    var notiJobKey = new JobKey("NotiDayEndJob");
    q.AddJob<NotiDayEndService>(opts => opts.WithIdentity(notiJobKey));
    q.AddTrigger(opts => opts
        .ForJob(notiJobKey)
        .WithIdentity("NotiDayEndTrigger")
        .WithCronSchedule(GetCron.GetNotiDayEndCron())
    );

    // --- RemindDueDate Job ---
    var remindJobKey = new JobKey("RemindDueDateJob");
    q.AddJob<RemindDueDateService>(opts => opts.WithIdentity(remindJobKey));
    q.AddTrigger(opts => opts
        .ForJob(remindJobKey)
        .WithIdentity("RemindDueDateTrigger")
        .WithCronSchedule(GetCron.GetRemindDueDateCron())
    );

    // --- SampleTask Job ---
    var sampleTaskJobKey = new JobKey("SampleTaskJob");
    q.AddJob<SampleTaskService>(opts => opts.WithIdentity(sampleTaskJobKey));
    q.AddTrigger(opts => opts
        .ForJob(sampleTaskJobKey)
        .WithIdentity("SampleTaskTrigger")
        .WithSimpleSchedule(x => x
            .WithIntervalInMinutes(1)   // ทุก 1 นาที
            .RepeatForever())
    );
});

// 2. Host Quartz
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();
