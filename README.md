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
    <ol>
      <li>Go to <a href="https://github.com/salandananry/unity-translation-kit/releases">Release</a> and download the latest <strong>Package</strong>.</li>
    </ol>
  </details>
      <details>
    <summary><strong>How to get Spreadsheet ID</strong></summary>
    <ol>
      <li>Go to <strong>Google Sheets</strong> and create a new blank spreadsheet (or select an existing one).</li>
      <li>Modify the General Access to <strong>Anyone with the link</strong> and the role to <strong>Viewer</strong>.</li>
      <li>Select the <strong>Copy link</strong> button and paste the link to a notepad.</li>
      <li>Your Spreadsheet ID will be between <strong>"d/"</strong> and <strong>"/edit"</strong>.</li>
      <blockquote>
        <code>https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing</code>
      </blockquote>
    </ol>
  </details>
    <details>
      <summary><strong>How to set up Spreadsheet</strong></summary>
      <ol>
        <li>The first column contains the unique keys for each translated text.</li>
        <li>The succeeding columns contain the translations for each language.</li>
        <li>You can use multiple sheets for better organization.</li>
        <blockquote>
          <em>Set up example (Click image to expand)</em>
          <br>
          <img 
            width="601" 
            height="368" 
            alt="image" 
            src="https://github.com/user-attachments/assets/cb9a7f65-a73e-43e1-ac45-0c74e6009b3e" />
        </blockquote>
      </ol>
    </details>
  <details>
      <summary><strong>How to get API key</strong></summary>
    <ol>
      <li>Go to <strong>Google Cloud Console</strong>.</li>
      <li>Create a new project (or select an existing one).</li>
      <li>Go to <strong>API Library</strong>.</li>
      <blockquote>
        Navigation menu -> APIs & Services -> Library
      </blockquote>
      <li>Enable <strong>Google Sheets API</strong>.</li>
      <blockquote>
        Under Google Workspace section -> Google Sheets API -> Enable
      </blockquote>
      <li>Go to <strong>Credentials</strong>.</li>
      <blockquote>
        Navigation menu -> APIs & Services -> Credentials
      </blockquote>
      <li>Create <strong>API key</strong>.</li>
      <blockquote>
        Create credentials -> API key -> Create
        <br>
        <strong>⚠️ Recommended: Under API Restrictions, you can restrict the key and select Google Sheets API ⚠️</strong>
      </blockquote>
    </ol>
  </details>
    <details>
      <summary><strong>How to set up Unity Project</strong></summary>
      <ol>
        <li>Create a new unity project (or select an existing one).</li>
        <li>Import <strong>newtonsoft</strong> package.</li>
        <blockquote>
          Window -> Package Manager -> install package from git url
          <br>
          <pre><code>com.unity.nuget.newtonsoft-json</code></pre>
        </blockquote>
        <li>Import <strong>TMP Essentials</strong>.</li>
        <blockquote>
          Edit -> Project Settings -> TextMesh Pro -> Import TMP Essentials
        </blockquote>
        <li>Import the <strong>Package</strong>.</li>
        <blockquote>
          Assets -> Import Package -> Custom Package -> Select the package
        </blockquote>
        <li>Configure the <strong>Translation editor window</strong></li>
        <blockquote>
          Tools -> Salandananry -> Unity Translation Kit -> Translation Window
        </blockquote>
        <li><strong>Language Selector</strong> set up</li>
        <blockquote>
          <strong>Attach LanguageSelector script to your Language Selection UI</strong>
          <blockquote>
            <em>Set up example (Click image to expand)</em>
            <br>
          <img 
            width="478" 
            height="67" 
            alt="Example set up" 
            src="https://github.com/user-attachments/assets/ed33a82c-7a7b-4609-ac76-91dc41c6d78b" />
          </blockquote>
          <strong>Configure Language Selection Buttons</strong>
          <blockquote>
            <ol type ="a">
              <li>For each language button, add an entry to its On Click() event.</li>
              <li>Assign the GameObject containing the LanguageSelector script to the object field.</li>
              <li>Select LanguageSelector -> ChangeLanguage (string) from the function dropdown.</li>
              <li>Enter the language code in the string field (e.g, english, japanese, indonesian etc.)</li>
            <strong>Note: The language code must exactly match the corresponding language name/code used in your Google Sheets.</strong>
            <blockquote>
              <em>Set up example (Click image to expand)</em>
              <br>
              <img 
                width="942" 
                height="241" 
                alt="image" 
                src="https://github.com/user-attachments/assets/ad74ef39-d674-4e62-b706-5e1889796df3" />
            </blockquote>
            </ol>
          </blockquote>
        </blockquote>
      </ol>
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
