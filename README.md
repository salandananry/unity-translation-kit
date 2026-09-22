# unity-translation-kit [v1.0.0]
> `This Unity package was built using Unity Editor 6000.0.64f1.`

## **ABOUT**
Unity Translation Kit is a Unity package that provides a translation system for Unity games.

Translations are downloaded during Editor Play Mode, saved locally, and included in the final build for runtime use without requiring an internet connection.


##  **SET UP GUIDE**
### Download the Package
- Go to [**Release**](https://github.com/salandananry/unity-translation-kit/releases) and download the latest **Package**.

### **Get the Spreadsheet ID**
- Go to **Google Sheets** and create a new blank spreadsheet or select an existing one.
- Modify the General Access to **Anyone with the link** and the role to **Viewer**.
  > **File > Share > Share with others**
- Select the **Copy link** button and paste the link to a notepad.
- Your Spreadsheet ID will be between "**d/**" and "**/edit**".
  > `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`

### **Set Up the Spreadsheet**
- The first column contains the unique keys for each translated text.
- The succeeding columns contain the translations for each language.
- You can use multiple sheets for better organization.
> Example Setup
<img width="758" height="390" alt="{ECC5F764-C3B6-4FCA-8A91-8CDA60D024B5}" src="https://github.com/user-attachments/assets/7e1b8e1f-2126-4e4f-8cfc-c65526a827c0" />

### **Get the API Key**
- Go to **Google Cloud Console**.
- Create a new project or select an existing one
- Go to **API Library**.
  > **Navigation menu > APIs & Services > Library**
- Enable **Google Sheets API**.
  > **Under Google Workspace section > Google Sheets API > Enable**
- Go to **Credentials**.
  > **Navigation menu > APIs & Services > Credentials**
- Create **API key**.
  > **Create credentials > API key > Create**
  >>⚠️Recommended: Under API Restrictions, you can restrict the key and select Google Sheets API.

### **Set Up Unity**
- Create a new unity project or open an existing one.
- Import **newtonsoft** package.
  > **Window > Package Manager > install package from git URL**
  > ```
  > com.unity.nuget.newtonsoft-json
  > ```
- Import **TMP Essentials**
  > **Edit > Project Settings > TextMesh Pro > Import TMP Essentials**
- Import the **Package**
  > **Assets > Import Package > Custom Package > Select the Package**
- Configure the Translation Editor
  > Unity Translation Kit > Scripts > Editor > translation-editor-config.json 
  >>⚠️Recommended: Add translation-editor-config.json to .gitignore to keep your API key and Spreadsheet ID private.


## **CHANGELOG**
#### [v1.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v1.0.0) - 21-09-2026
- Full Revamp of the system.
  - Now, translation data is only downloaded during Editor Play Mode or development. The data is saved locally and included in the build, without exposing the API key or Spreadsheet ID.
#### [v0.1.1](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.1.1) - 22-04-2026
- Modified TranslationSheet.cs
  - Fixed an issue where, if there is an empty row between two translations in Google Sheets, the system would not continue retrieving the remaining translations after that empty row.
#### [v0.1.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.1.0) - 13-02-2026
- Added LICENSE text file.
- Modified LanguageDatabase.cs
  - Renamed Method LoadTranslationFile() to LoadLocalTranslationFile().
  - Renamed Method NormalizeTranslation() to RemoveEmptyTranslations().

#### [v0.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.0.0) — 06-01-2026
- Initial release.


⚠️`IMPORTANT: Never upload your API key or Spreadsheet ID to your repository. Keep them private and secure.`
