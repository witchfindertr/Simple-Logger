# Simple Logger
A simple key logger written in C# that utilizes low level keyboard hooking to capture key strokes

## How does it work?
When a session is launched, a global hook is installed on the computer using the Windows API (specifically user32.dll). This allows keystrokes to be captured regardless of what the user is doing. These keystrokes are then processed and converted from virtual key codes to readable characters. Once this has been accomplished, keystrokes are then written to a randomly generated file found in the directory "C:\ProgramData\Log Data".

## How do I recover the recorded keystrokes?
You have two options
* Manually recover the saved files from the computer itself 
* Utilize the inbuilt emailing function to email yourself the recorded keystrokes once a day.

## How do I use the inbuilt email function?
* Allow your email account to access "less secure apps" in other words allow it to send emails using an SMTP library - https://www.google.com/settings/security/lesssecureapps (if you are using a gmail account)
* Open App.config and change the value of "email" to your email address and the value of "password" to your email password
* Recompile the project

## How do I use Simple Logger?
* Open the project solution in Visual Studio 2017
* Compile it  (Change debug to release)
* Run the Simple Logger.exe file it creates in the release directory (Simple-Logger\Simple Logger\bin\Release)

#### Please note I do not condone you using Simple Logger for anything that may be considered illegal.
