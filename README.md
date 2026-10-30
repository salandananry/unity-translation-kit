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
    <details>
      <summary><strong>How to set up Spreadsheet</strong></summary>
      <ul>
        <li>The first column contains the unique keys for each translated text.</li>
        <li>The succeeding columns contain the translations for each language.</li>
        <li>You can use multiple sheets for better organization.</li>
        <blockquote>
          <strong>Example Setup</strong>
          <br>
          <img
            width="758"
            height="390"
            alt="Example Setup"
            src="https://github.com/user-attachments/assets/7e1b8e1f-2126-4e4f-8cfc-c65526a827c0"/>
        </blockquote>
      </ul>
    </details>
  <details>
      <summary><strong>How to get API key</strong></summary>
    <ul>
      <li>Go to <strong>Google Cloud Console</strong>.</li>
      <li>Create a new project (or select an existing one).</li>
      <li>Go to <strong>API Library</strong>.</li>
      <blockquote>
        <strong>Navigation menu -> APIs & Services -> Library</strong>
      </blockquote>
      <li>Enable <strong>Google Sheets API</strong>.</li>
      <blockquote>
        <strong>Under Google Workspace section -> Google Sheets API -> Enable</strong>
      </blockquote>
      <li>Go to <strong>Credentials</strong>.</li>
      <blockquote>
        <strong>Navigation menu -> APIs & Services -> Credentials</strong>
      </blockquote>
      <li>Create <strong>API key</strong>.</li>
      <blockquote>
        <strong>Create credentials -> API key -> Create</strong>
        <br>
        <strong>⚠️ Recommended: Under API Restrictions, you can restrict the key and select Google Sheets API ⚠️</strong>
      </blockquote>
    </ul>
  </details>
    <details>
      <summary><strong>How to set up Unity Project</strong></summary>
      <ul>
        <li>Create a new unity project (or select an existing one).</li>
        <li>Import <strong>newtonsoft</strong> package.</li>
        <blockquote>
          <strong>Window -> Package Manager -> install package from git url</strong>
          <br>
          <pre><code>com.unity.nuget.newtonsoft-json</code></pre>
        </blockquote>
        <li>Import <strong>TMP Essentials</strong>.</li>
        <blockquote>
          <strong>Edit -> Project Settings -> TextMesh Pro -> Import TMP Essentials</strong>
        </blockquote>
        <li>Import the <strong>Package</strong>.</li>
        <blockquote>
          <strong>Assets -> Import Package -> Custom Package -> Select the package</strong>
        </blockquote>
        <li>Configure the <strong>Translation editor window</strong></li>
        <blockquote>
          <strong>Tools -> Salandananry -> Unity Translation Kit -> Translation Window</strong>
        </blockquote>
      </ul>
    </details>
  </blockquote>
</details>

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
