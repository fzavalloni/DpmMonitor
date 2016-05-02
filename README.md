# DpmMonitor

Nagios Plugin to monitor backup Jobs of System Center Data Protection Manager 2012.

# Settings

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <DPMConnectionString>server=127.0.0.1\mssqldpm01;Trusted_Connection=yes;database=DPMDB_lwdpm_0001;connection timeout=30</DPMConnectionString>
</configuration>
```

# Parameters

DpmMonitor.exe /CheckStorageSpace -Threshold:100 (Size in GB) - Free Available Storage

DpmMonitor.exe /CheckFailedJobs - Alerts to Failed Jobs

DpmMonitor.exe /CheckAlerts - Sincronization Jobs

