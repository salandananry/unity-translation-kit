# unity-translation-kit [v2.1.0]
> `This Unity package was built using Unity Editor 6000.0.64f1.`

<details open>
  <summary><strong>ABOUT</strong></summary>
Unity Translation Kit is an editor-based tool I developed to simplify translation management for Unity games using Google Sheets. <br><br>
The custom Editor Window lets developers configure their Google Sheets API key and spreadsheet ID, manually fetch translations, and monitor updates through an activity log. Translations are saved locally for use at runtime, including in offline builds.
</details>

<details>
  <summary><strong>SET UP GUIDE</strong></summary>
  <blockquote>
  <details>
    <summary><strong>How to download the package</strong></summary>
    <ul>
      <li>Go to <a href="https://github.com/salandananry/unity-translation-kit/releases">Release</a> and download the latest <strong>Package</strong>.</li>
    </ul>
  </details>
      <details>
    <summary><strong>How to get Spreadsheet ID</strong></summary>
    <ul>
      <li>Go to <strong>Google Sheets</strong> and create a new blank spreadsheet (or select an existing one).</li>
      <li>Modify the General Access to <strong>Anyone with the link</strong> and the role to <strong>Viewer</strong>.</li>
      <li>Select the <strong>Copy link</strong> button and paste the link to a notepad.</li>
      <li>Your Spreadsheet ID will be between <strong>"d/"</strong> and <strong>"/edit"</strong>.</li>
      <blockquote>
        <code>https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing</code>
      </blockquote>
    </ul>
  </details>
  </blockquote>
</details>
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
- Configure the **Translation Editor**
  > Tools > Unity Translation Kit > Translation Window > Input the API key and Spreadsheet ID
  >><del>⚠️Recommended: Add translation-editor-config.json to .gitignore to keep your API key and Spreadsheet ID private.</del>


## **CHANGELOGS**
#### [v2.1.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v2.1.0) - October 28, 2026
- Removed configuration file dependency by passing credentials directly from the Editor Window to the translation updater.
- Organized the Editor menu under Tools/Salandananry/Unity Translation Kit/Translation Window.
#### [v2.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v2.0.0) - October 19, 2026
- Added a dedicated Editor Window for configuration management, manual translation fetching, and activity logging.
  - Translation updates are now managed manually through a dedicated Editor Window, giving developers full control over when to fetch translations from Google Sheets.
#### [v1.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v1.0.0) - September 21, 2026
- Full Revamp of the system.
  - Now, translation data is only downloaded during Editor Play Mode or development. The data is saved locally and included in the build, without exposing the API key or Spreadsheet ID.
#### [v0.1.1](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.1.1) - April 22, 2026
- Modified TranslationSheet.cs
  - Fixed an issue where, if there is an empty row between two translations in Google Sheets, the system would not continue retrieving the remaining translations after that empty row.
#### [v0.1.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.1.0) - February 13, 2026
- Added LICENSE text file.
- Modified LanguageDatabase.cs
  - Renamed Method LoadTranslationFile() to LoadLocalTranslationFile().
  - Renamed Method NormalizeTranslation() to RemoveEmptyTranslations().

#### [v0.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.0.0) — January 06, 2026
- Initial release.


⚠️`IMPORTANT: Never upload your API key or Spreadsheet ID to your repository. Keep them private and secure.`
