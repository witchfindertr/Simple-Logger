# Simple Logger
A key logger written in C# that utilizes low level keyboard hooking to capture key strokes.

### How does it work?
* When a session is launched, a global hook is installed on the computer using the Windows API (specifically user32.dll.) 
* All keystrokes are then captured using the global hook
* The recorded keystrokes are converted from virtual key codes to readable chacters
* The readable keystrokes are then written to a randomly generated file found in the directory "C:\ProgramData\Log Data" 

### How do I recover the recorded keystrokes?
You have two options
* Manually recover the saved files from the computer itself 
* Recover the keystrokes via email

### How do I recover the keystrokes via email?
* If you are using Gmail allow your account to access "less secure apps" in other words allow emails to be sent using an SMTP library - https://www.google.com/settings/security/lesssecureapps
* Change the value of "service" to the SMTP server associated with your email address in App.config
* Change the value of "email" to your email address and the value of "password" to your email password in App.config

#### Please note I do not condone the useage of Simple Logger for anything that may be considered illegal.
