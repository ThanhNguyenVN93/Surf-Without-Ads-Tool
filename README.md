# Surf Without Ads Tool

A lightweight Windows utility that configures your system for ad-free browsing by setting up DNS-based ad blocking and disabling IPv6, all with a single click.

## Features

- **One-Click DNS Ad Blocking** — Configures Cloudflare (`1.1.1.1`) + AdGuard (`94.140.14.14`) DNS
- **IPv6 Disable** — Disables IPv6 binding, Teredo, 6to4, and ISATAP
- **DNS Verification** — Opens Cloudflare and AdGuard check pages in your browser
- **.NET 3.5 Auto-Check** — Detects and offers to install .NET Framework 3.5 if missing
- **Auto Admin Elevation** — Requests administrator privileges automatically on launch
- **Sequential Workflow** — Click once, all steps run automatically in order

## How It Works

```
Launch → Admin Check → .NET 3.5 Check → Main Form
                                            │
                                    Click "Enable Ad Blocker"
                                            │
                              ┌─────────────┼─────────────┐
                              ▼             ▼             ▼
                         Set DNS     Disable IPv6   Open Check Pages
                              │             │             │
                              └─────────────┼─────────────┘
                                            ▼
                                   Done → Exit
```

## System Requirements

- Windows 10 / 11
- .NET Framework 3.5+
- Administrator privileges

## Quick Start

1. Download `frmdnschange.exe` from [Releases](https://github.com/user/frmdnschange/releases)
2. Double-click to run (UAC will prompt for admin)
3. Click **"Enable Ad Blocker"**
4. Verify results in the browser windows that open
5. Done — the app exits automatically

## What Gets Changed

### DNS Servers
| Setting | Value |
|---------|-------|
| Primary DNS | `1.1.1.1` (Cloudflare) |
| Secondary DNS | `94.140.14.14` (AdGuard) |

### IPv6 Disabled Via
```
Disable-NetAdapterBinding -Name "*" -ComponentID ms_tcpip6
netsh interface ipv6 set teredo disabled
netsh interface ipv6 set 6to4 disabled
netsh interface ipv6 set isatap disabled
```

## Building from Source

**Prerequisites:** Visual Studio 2019+ with .NET desktop development workload

```bash
git clone https://github.com/user/frmdnschange.git
cd frmdnschange
```

Open `frmdnschange.sln` in Visual Studio, then **Build → Build Solution** (`Ctrl+Shift+B`).

The output will be in `bin\Release\frmdnschange.exe`.

## Project Structure

```
Form1.cs                 Main workflow and UI logic
Form1.Designer.cs        Windows Forms layout (4 buttons + log area)
Program.cs               Entry point, admin elevation
CheckDotNetForm.cs       .NET Framework 3.5 detection/installation
DnsChecker.cs            Opens browser verification pages
CreateInternetIcon.cs    Generates application icon at runtime
IconGenerator.cs         Bitmap-to-icon conversion
```

## Troubleshooting

| Problem | Solution |
|---------|----------|
| "Access denied" | Right-click → Run as administrator |
| DNS not changing | Your adapter may not be named "Ethernet" — edit `SetDnsServers()` in `Form1.cs` |
| IPv6 still active | Reboot after running the tool |
| Browser check fails | Verify internet connectivity first |

## License

[MIT](LICENSE)
