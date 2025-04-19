# Quartz.NET Background Job Scheduler Example

This project demonstrates how to use **Quartz.NET** with **.NET 9** to schedule background jobs.

It defines **three jobs**:
- `NotiDayEndJob`
- `RemindDueDateJob`
- `SampleTaskJob`

Each job simulates calling a remote API asynchronously.

---

## 🚀 Features

- **NotiDayEndJob**: Runs daily at **10:00 AM** (Monday to Friday only, skips weekends).
- **RemindDueDateJob**: Runs at **6:00 PM** on the **7th, 17th, and 29th** of each month, except **February** (runs on 7th, 17th, and 27th).
- **SampleTaskJob**: Runs **every minute** without restrictions.

Each job calls a shared method `CallApiAsync` which simulates an API request.

---

## 📦 Required NuGet Packages

Make sure to install the following package:

```bash
dotnet add package Quartz
dotnet add package Quartz.Extensions.DependencyInjection
dotnet add package Quartz.Extensions.Hosting
