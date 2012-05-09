# Slouch Interceptor

## What is it?

A simple program to remind you to take small regular breaks from working at your computer, i.e it intercepts your slouchiness ;)

## Requirements

At least Windows XP, .NET Framework 2.0 and motivation to obey the program...

## Download / Installation

Download and install the latest version: [Slouch Interceptor 1.2.1](https://bitbucket.org/mikoro/slouchinterceptor/downloads/Slouch%20Interceptor%201.2.1.msi).

Older versions can be found from the [downloads page](https://bitbucket.org/mikoro/slouchinterceptor/downloads).

## Instructions

- The program will start automatically when starting Windows
- Click the program icon in the taskbar to show the context menu
- You can test the program with the _Start Break_ menu entry
- If you want to close the overlay window before the timeout either press Alt+F4 or press the Windows key, click the taskbar icon and select _Stop Break_
- The break interval timer can be enabled/disabled with the _Enable/Disable Timer_ menu entry
- Configuration options:
    - **BreakDuration** is the duration of the break in minutes (can be fractional)
    - **BreakInterval** is the time between the breaks in minutes (can be fractional)
    - **IdleDetectionThreshold** is the idle time in minutes after which the break interval timer is reset (can be fractional) (you didn't use the computer and the program takes it as a break)
    - **BreakNotificationTime** is the time in minutes when a notification should be shown before the actual break (can be fractional)
    - **AutoLock** sets whether the computer is locked after the break ends (useful if you leave the computer during the break)
    - **DisableClose** makes the overlay windows ignore normal closing attempts (can be closed with the taskbar context menu)
    - **DisableSwitch** keeps the overlay window topmost all the time (combining with DisableClose makes closing the overlay windows almost impossible)
    - **EnableBreakNotification** shows a balloon tip notification before the actual break begins

## Version history

### 1.3.0 (5/xx/2012)

- Added support for AutoLock
- Added support for DisableClose
- Added support for DisableSwitch
- Added support for BreakNotification
- Changed the configuration menu interface
- Added support for minute fractions in the configuration options

### 1.2.1 (3/21/2012)

- Attempt to fix a bug that starts a break immediately after resuming the computer and logging in
- Updated the readmes and the installer
- Added a license to the project

### 1.2.0 (2/29/2012)

- Some changes to the taskbar menu and little bug fixes

### 1.1.0 (2/28/2012)

- Added configuration options and support for user idle detection

### 1.0.0 (2/26/2012)

- Initial version
