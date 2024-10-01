;NSIS Modern User Interface
;Basic Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Order Processing App"
  OutFile "OrderProcessingWPF_Installer.exe"
  Unicode True

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\Order Processing App"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Order Processing App" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING
  !define MUI_ICON "Order_Processing.ico"
;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Base application" SecDummy

  SetOutPath "$INSTDIR"
  
  ;ADD YOUR OWN FILES HERE...
  File "..\OrderProcessingWPF\bin\x64\Development\net8.0-windows\OrderProcessingWPF.exe"
  File "..\OrderProcessingWPF\bin\x64\Development\net8.0-windows\OrderProcessingWPF.dll"
  File "..\OrderProcessingWPF\bin\x64\Development\net8.0-windows\Model.dll"
  File "..\OrderProcessingWPF\bin\x64\Development\net8.0-windows\Newtonsoft.Json.dll"
  File "..\OrderProcessingWPF\bin\x64\Development\net8.0-windows\ViewModel.dll"

  ;Store installation folder
  WriteRegStr HKCU "Software\Order Processing App" "" $INSTDIR
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecDummy ${LANG_ENGLISH} "A section"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete "$INSTDIR\OrderProcessingWPF.exe"
  Delete "$INSTDIR\OrderProcessingWPF.dll"
  Delete "$INSTDIR\Model.dll"
  Delete "$INSTDIR\Newtonsoft.Json.dll"
  Delete "$INSTDIR\ViewModel.dll"

  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Order Processing App"

SectionEnd