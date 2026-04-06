# unity-translation-kit [v0.1.0]

## **ABOUT**
**Unity Translation Kit** is a Unity package that provides a robust translation system for Unity games. It uses **Google Sheets** as the source for all translation data and connects to them through the **Google Sheets API**.


##  **GETTING STARTED**
### DOWNLOAD THE PACKAGE
- Go to [**Release**](https://github.com/salandananry/unity-translation-kit/releases) and download the latest **Package**.

### **ACQUIRE SPREADSHEET ID**
- Go to **Google Sheets** and create a new blank spreadsheet or select an existing one.
- Modify the General Access to **Anyone with the link** and the role to **Viewer**.
  > **File > Share > Share with others**
- Select the **Copy link** button and paste the link to a notepad.
- Your Spreadsheet ID will be between "**d/**" and "**/edit**".
  > `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`

### **SET UP SPREADSHEET**
- The first column contains the unique keys for each translated text.
- The succeeding columns contain the translations for each language.
- You can use multiple sheets for better organization.
> Example Setup
<img width="758" height="390" alt="{ECC5F764-C3B6-4FCA-8A91-8CDA60D024B5}" src="https://github.com/user-attachments/assets/7e1b8e1f-2126-4e4f-8cfc-c65526a827c0" />

### **ACQUIRE API KEY**
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
  >> Option: Under API Restrictions, you can restrict the key and select Google Sheets API.

### **SET UP UNITY**
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

There is a demo scene showcasing how the system works + Small text guides

## **CHANGELOG**
#### [v0.1.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.1.0) - 2026-02-13
- Added LICENSE text file.
- Modified LanguageDatabase.cs
  - Renamed Method LoadTranslationFile() to LoadLocalTranslationFile().
  - Renamed Method NormalizeTranslation() to RemoveEmptyTranslations().

#### [v0.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.0.0) — 2026-01-06
- Initial release.

## **Note**
### Q: Does it support offline usage?
`A: Yes, Translations are saved locally after the first fetch, so the package works offline. An internet connection is only needed initially to download or update the data.`

### Q: Can I use this?
`A: Yes, This package is under the MIT License, which allows free use in both non-commercial and commercial projects.` [**LICENSE**](https://github.com/salandananry/unity-translation-kit?tab=MIT-1-ov-file).

### Q: Does this Support Runtime Language switching?
`A: Yes.`

### Q: Can I use multiple sheets?
`A: Yes, It’s recommended for better organization. All sheets in the spreadsheet are automatically fetched.`

### Q: What happens if a translation is missing?
`A: The system uses the fallback text you provide.`
