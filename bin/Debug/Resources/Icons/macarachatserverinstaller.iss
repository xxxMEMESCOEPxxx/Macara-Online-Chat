; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Macara Chat Server"
#define MyAppVersion "1.0"
#define MyAppPublisher "Andrew Maney"
#define MyAppExeName "Server.exe"
#define MyAppAssocName MyAppName + " Setup"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{057EB8D5-C467-483E-9D06-51F041450D66}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Users\andre\Desktop\Macara-Server-Installer
OutputBaseFilename=Macara Chat Server Setup
SetupIconFile=C:\Users\andre\Downloads\Macara-Online-Chat\ChatClient\ChatClient\bin\Debug\Resources\Icons\appicon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\concrt140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140chs.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140cht.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140deu.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140enu.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140esn.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140fra.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140ita.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140jpn.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140kor.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140rus.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfc140u.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfcm140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\mfcm140u.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\msvcp140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\msvcp140_1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\msvcp140_2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\msvcp140_atomic_wait.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\msvcp140_codecvt_ids.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\vcamp140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\vccorlib140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\vcomp140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\vcruntime140.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\andre\Downloads\Macara-Online-Chat\Server\x64\Release\vcruntime140_1.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

