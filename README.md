# Unity Translation Kit [WIP]
A robust translation system for Unity games using the Google Sheets API.

# Getting Started
### Unity Set Up
* Download the package from the [RELEASES](https://github.com/salandananry/unity-translation-kit/releases) and import it to your unity project.
* Import Newtonsoft Package to your unity project.
  > **Window** ➜ **Package Manager** ➜ **Install Package from git URL**
  ```
  com.unity.nuget.newtonsoft-json
  ```
* Option: Import font assets for **Non - Latin scripts**.

### Google Sheet API key
* Go to **Google Cloud Console** and create or select a project.
* Go to **APIs & Services** and select **Library**.
* Under **Google Workspace** section, select **Google Sheets API** and **Enable** it.
* Go to **Credentials** ➜ **Create Credentials** ➜ **API Key**.
  > Under **API Restriction** section, select **Google Sheets API**.

### Spreadsheet ID
* Go to **Google Sheets** and create or select spreadsheet.
* Change the **General Access** to **Anyone with the link [Viewer]**.
  > **File** ➜ **Share** ➜ **Share with others**.
* Copy the share link and paste it to a **notepad**.
* Your **Spreadsheet ID** would be between **"d/"** and **"/edit"**.
  > For example: `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`.

# How to use
Inside **"Unity Translation kit"** folder, open the Demo scene to see how to set up the system.

# Changelog

## Version 0.1.0 [12-14-2025]
- Unity Package available.
  
## Version 0.0.0 [12-06-2025]
- Initial release of the kit.
