# Unity Translation Kit [WIP]
A robust translation system for Unity games using the Google Sheets API.

# Getting Started
### Unity Set Up
* Download the package from the [RELEASES](https://github.com/salandananry/unity-translation-kit/releases) and import it to your unity project.
* Import Newtonsoft Package to your unity project.
  > **Window** > **Package Manager** > **Install Package from git URL**
  ```
  com.unity.nuget.newtonsoft-json
  ```

### Google Sheet API key
* Go to **Google Cloud Console** and create or select a project.
* Go to **APIs & Services** and select **Library**.
* Under **Google Workspace** section, select **Google Sheets API** and **Enable** it.
* Go to **Credentials** then select **Create Credentials** > **API Key**.
  > Under **API Restriction** section, select **Google Sheets API**.

### Spreadsheet ID
* Go to **Google Sheets** and create or select spreadsheet.
* Change the **General Access** to **Anyone with the link [Viewer]**.
* Copy the share link and paste it to a **notepad**.
* Your **Spreadsheet ID** would be between **"d/"** and **"/edit"**.
  > For example: `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`.

# How to use
Inside Unity, go to **"Unity Translation kit"** folder and look for the demo scene. This demo scene can give you an idea on how the system works.

**TranslateText.cs** should be attached to text game objects that requires translation,
> Add the localiation key. <br>
> Add the Fallback text.
> > **Fallback text will be used if localization key or translation is missing**

**LanguageSelector.cs** should be attached to your language settings ui game object
> Each button represents a language option. <br>
> > Inside each button’s OnClick() event, drag the GameObject that has the LanguageSelector script attached.
> > > From the function dropdown, select LanguageSelector → ChangeLanguage (string).
> > > > **The string value must be the same as the one defined in the spreadsheet (e.g., en or english).**

**LanguageDatabase.cs** and **TranslationSheet.cs** are responsible for getting the translation from the google sheets and downloading and saving it localy.
> LanguageDatabase.cs is recommended to be attached to the very first scene of your game that has text translation required or in a "Initiatlizer Scene".
> > [ **PLEASE DO NOT PUSH YOUR API KEY AND SPREADSHEET ID IN YOUR REPO** ]

## Optional
It's not required to also import **DebugHandler.cs** to your game and if you didn't, you will have to edit the script to use the default "Debug.Log".

# Changelog

## Version 0.1.0 [12-14-2025]
- Unity Package available.
  
## Version 0.0.0 [12-06-2025]
- Initial release of the kit.
