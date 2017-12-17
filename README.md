# Simple-Logger
A simple key logger written in C# that utilizes low level keyboard hooking to capture key strokes

## How does it work?
When a session is launched, a global hook is installed on the computer using the Windows API (specifically user32.dll). This allows keystrokes to be captured regardless of what the user is doing. These keystrokes are then processed and converted from virtual key codes to readable characters. Once this has been accomplished, keystrokes are then written to a randomly generated file found in the directory "C:\ProgramData\Log Data".

## How do I receive the recorded keystrokes?
You have two options here
* Manually recover the saved files from the computer itself 
* Utilize the inbuilt emailing function to email yourself the recorded keystrokes once a day.

## How do I use the inbuilt email function?
* Allow your email account to access "less secure apps" in other words allow it to send emails from SMTP library - https://www.google.com/settings/security/lesssecureapps
* Open Email.cs and put in your email login and password
* Recompile the project and your good to go

## How do I use this?
* Open the project solution in Visual Studio 2017
* Compile it  (Change debug to release)
* Run the .exe file it creates in the release directory

#### Please not I do not condone you using this for anything that may be considered illegal.
