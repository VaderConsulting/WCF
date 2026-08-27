# WCF

VB.NET Visual Studio 2008 solution for a duplex WCF license-oriented service and a matching WinForms client. The `LicenseServer` host (`frmMain` titled “WCF Server”) opens a `ServiceHost` for `LicenseService` on a configurable `net.tcp` address with Start/Stop buttons; the service contract (`IService` / `IServiceCallback`) exposes session-based Authenticate, SendData, GetConfig, and CloseConnection operations with duplex callbacks, but the method bodies are still TODO stubs. The `Client` project is an empty “WCF Client” WinForms shell with no call logic yet. Binding uses `netTcpBinding` with reliable sessions and security mode None, throttled to 10,000 concurrent sessions.

**Source last updated:** 2008-08-21 · **Language:** VB.NET · **Target:** .NET Framework 3.5 · **Output:** WinForms executables (`WinExe`)

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `LicenseServer` (`Server/LicenseServer.vbproj`) | VB.NET | WinForms exe (`net35`, WCF) | Hosts `LicenseService` over `netTcpBinding`; Start/Stop UI. |
| `Client` (`Client/Client.vbproj`) | VB.NET | WinForms exe (`net35`) | Stub “WCF Client” form; no service proxy wired yet. |

## How to open

Open `WCF.sln` in Visual Studio 2008 or later (solution format 10.00 / ToolsVersion 3.5). Build both projects; run `Server` first. Default listen address in `Server` settings/`app.config` is `net.tcp://localhost:22222/...` (settings file uses path `/WCFServer`, `app.config` applicationSettings uses `/Service`). Requires .NET Framework 3.5 and `System.ServiceModel`.

## Attribution and provenance

Working copy from Dave Robinson's OneDrive Historical Dev folder `WCF`. Assembly company/copyright still show the Visual Studio template defaults (Microsoft 2008). Project names `LicenseServer` / `Client`; namespaces `Server` / `Client`; service type `LicenseService`.

## License

MIT © 2026 VaderConsulting. See `LICENSE`.
