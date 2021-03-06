; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "BigSmash247"
#define MyAppVersion "0.1"
#define MyAppPublisher "Solusi 247"
#define MyAppURL "http://www.solusi247.com/"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{868082EA-0F9D-46A6-B9C7-1DCB5AC698FC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={sd}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-Setup
SetupIconFile=C:\Users\solusi247\Documents\Visual Studio 2010\Projects\BigSmash247\BigSmash247\faviconBS247.ico
Compression=zip
SolidCompression=yes
; Tell Windows Explorer to reload the environment
ChangesEnvironment=yes
; Wizard Image
WizardImageFile=C:\Users\solusi247\Pictures\bs247_8bit.bmp
WizardSmallImageFile=C:\Users\solusi247\Pictures\bs247_small_8bit.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default247.isl"

[Files]    
Source: "C:\BigSmash247_Inno\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName} Control Panel"; Filename: "{app}\BigSmash247_CP.exe"
Name: "{group}\HGrid247"; Filename: "{app}\hgrid247-2.0\HGrid247.exe"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

[Run]
Filename: "{app}\tools\format-hdfs.cmd"; Description: "Initial Format HDFS"; StatusMsg: "Format HDFS..."; Flags: waituntilterminated
Filename: "{app}\tools\change-symlink.cmd"; Description: "Symlink conf to standadlone mode"; StatusMsg: "change symlink..."; Flags: waituntilterminated

[UninstallDelete]
Type: filesandordirs; Name: "{app}\hadoop-2.5.0"

[Registry]
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "BIGSMASH_HOME"; ValueData: "{app}"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "HGRID247_HOME"; ValueData: "{app}\hgrid247-2.0"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "JAVA_HOME"; ValueData: "{app}\jdk1.7.0_67"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "HADOOP_HOME"; ValueData: "{app}\hadoop-2.5.0"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "HADOOP_CONF_DIR"; ValueData: "{app}\hadoop-2.5.0\etc\hadoop"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "ZOOKEEPER_HOME"; ValueData: "{app}\zookeeper-3.4.6"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "STORM_HOME"; ValueData: "{app}\storm-0.9.2-incubating"; Flags: deletevalue uninsdeletevalue
Root: HKCU; Subkey: "Environment"; ValueType: string; ValueName: "SPARK_HOME"; ValueData: "{app}\spark-1.1.0"; Flags: deletevalue uninsdeletevalue
; Path
;Root: HKCU; Subkey: "Environment"; ValueType: expandsz; ValueName: "Path"; ValueData: "{olddata};{app}\jdk1.7.0_67\bin"; Check: NeedsAddPath(ExpandConstant('{app}\jdk1.7.0_67\bin'))
Root: HKCU; Subkey: "Environment"; ValueType: "expandsz"; ValueName: "Path"; ValueData: "{app}\jdk1.7.0_67\bin;{app}\hadoop-2.5.0\bin;{app}\storm-0.9.2-incubating\bin;{app}\spark-1.1.0\bin;{olddata}"; Check: NotOnPathAlready(); Flags: preservestringtype


; http://stackoverflow.com/questions/4711157/inno-setup-query-adding-a-path-to-registry-using-registry-section
[Code]                                                                                                 
function NotOnPathAlready(): Boolean;
var
  OrigPath: String;
  BinDir: String;
begin    
  if RegQueryStringValue(HKEY_CURRENT_USER, 'Environment', 'Path', OrigPath) then
  begin // Successfully read the value  
    BinDir := ExpandConstant('{app}\jdk1.7.0_67\bin;{app}\hadoop-2.5.0\bin;{app}\storm-0.9.2-incubating\bin;{app}\spark-1.1.0\bin');     
    Log('Looking for bin dir in %PATH%: ' + BinDir + ' in ' + OrigPath);
    if Pos(LowerCase(BinDir), Lowercase(OrigPath)) = 0 then
    begin
      Log('Did not find ' + BinDir + ' dir in %PATH% so will add it');
      Result := True;
    end
    else
    begin
      Log('Found ' + BinDir + ' dir in %PATH% so will not add it again');
      Result := False;
    end
  end
  else // The key probably doesn't exist
  begin
    Log('Could not access HKCU\Environment\Path so assume it is ok to add it');
    Result := True;
  end;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  BinDir, Path: String;
begin
  if (CurUninstallStep = usPostUninstall)
     and (RegQueryStringValue(HKEY_CURRENT_USER, 'Environment', 'PATH', Path)) then
  begin
    BinDir := ExpandConstant('{app}\jdk1.7.0_67\bin;{app}\hadoop-2.5.0\bin;{app}\storm-0.9.2-incubating\bin;{app}\spark-1.1.0\bin');
    if Pos(LowerCase(BinDir) + ';', Lowercase(Path)) <> 0 then
    begin
      StringChange(Path, BinDir + ';', '');
      RegWriteStringValue(HKEY_CURRENT_USER, 'Environment', 'PATH', Path);
    end;
  end;
end;

// http://stackoverflow.com/questions/3304463/how-do-i-modify-the-path-environment-variable-when-running-an-inno-setup-install  
function NeedsAddPath(Param: string): boolean;
var
  OrigPath: string;
begin
  if not RegQueryStringValue(HKEY_CURRENT_USER, 'Environment', 'Path', OrigPath)
  then begin
    Result := True;
    exit;
  end;
  // look for the path with leading and trailing semicolon
  // Pos() returns 0 if not found
  Result := Pos(';' + Param + ';', ';' + OrigPath + ';') = 0;
end;
