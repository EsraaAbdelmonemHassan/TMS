# TMS Windows Onboarding (Option A)

This repository uses M# generation that depends on a Windows-friendly toolchain.
Use this guide to complete setup and finalize onboarding requirements from:

`Uzair_Farooqui_Dev_Onboarding_Global_11_5_2026MSharp_Progress (1).csv`

## 1) Prerequisites

- Windows 10/11
- Git
- .NET 6 SDK
- SQL Server Express (or SQL Server Developer)
- Visual Studio 2022 (recommended) with ASP.NET/.NET workload
- MSharp CLI tooling so `msharp-build` works in terminal

## 2) Clone and build

```bat
git clone https://github.com/EsraaAbdelmonemHassan/TMS
cd TMS
Build.bat
```

Expected result:
- M# code generation completes
- Solution builds without generation/runtime tool errors

## 3) Database and app config

- Open `Website/appsettings.json`
- Confirm connection string points to your SQL Server instance:

```json
"ConnectionStrings": {
  "Default": "Database=TMS.Temp; Server=.\\SQLExpress; Integrated Security=SSPI; MultipleActiveResultSets=True;"
}
```

If your SQL instance differs, replace `Server=.\\SQLExpress` accordingly.

## 4) Run the app

From terminal:

```bat
dotnet run --project Website/Website.csproj
```

Or run `Website` from Visual Studio.

Expected result:
- App starts and responds on localhost URL shown in console.

## 5) Finalize onboarding requirements

Use `MSHARP_PRACTICE_CHECKLIST.md` (or your CSV tracker) and mark items only after evidence.

Minimum evidence per practice:
- Code committed for that practice
- Feature verified in UI (or API/behavior where relevant)
- TDD completed if required for your onboarding process
- Reviewed by tech lead

## 6) Completion checklist

- [ ] Build passes on Windows using `Build.bat`
- [ ] App runs locally
- [ ] Database connection verified
- [ ] Practice items updated in checklist/CSV
- [ ] Ready for tech lead review
