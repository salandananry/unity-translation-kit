
# unity-translation-kit [v2.1.0]
> `This Unity package was built using Unity Editor 6000.0.64f1.`

<details open>
<summary><strong>ABOUT</strong></summary>

Unity Translation Kit is an editor-based tool I developed to simplify translation management for Unity games using Google Sheets. <br><br>

The custom Editor Window lets developers configure their Google Sheets API key and spreadsheet ID, manually fetch translations, and monitor updates through an activity log. Translations are saved locally for use at runtime, including in offline builds.

</details>

<details>
<summary><strong>SET UP GUIDE</strong></summary>

<details>
<summary><strong>How to download the package</strong></summary>

1. Go to <a href="https://github.com/salandananry/unity-translation-kit/releases">Release</a> and download the latest **Package**.

</details>

<details>
<summary><strong>How to get Spreadsheet ID</strong></summary>

1. Go to **Google Sheets** and create a new blank spreadsheet (or select an existing one).
2. Modify the General Access to **Anyone with the link** and the role to **Viewer**.
3. Select the **Copy link** button and paste the link to a notepad.
4. Your Spreadsheet ID will be between **"d/"** and **"/edit"**.

> `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`

</details>

<details>
<summary><strong>How to set up Spreadsheet</strong></summary>

1. The first column contains the unique keys for each translated text.
2. The succeeding columns contain the translations for each language.
3. You can use multiple sheets for better organization.

> *Set up example (Click image to expand)*

<img
  width="601"
  height="368"
  alt="image"
  src="https://github.com/user-attachments/assets/cb9a7f65-a73e-43e1-ac45-0c74e6009b3e" />

</details>

<details>
<summary><strong>How to get API key</strong></summary>

1. Go to **Google Cloud Console**.
2. Create a new project (or select an existing one).
3. Go to **API Library**.

   > Navigation menu -> APIs & Services -> Library

4. Enable **Google Sheets API**.

   > Under Google Workspace section -> Google Sheets API -> Enable

5. Go to **Credentials**.

   > Navigation menu -> APIs & Services -> Credentials

6. Create **API key**.

   > Create credentials -> API key -> Create

   > **⚠️ Recommended: Under API Restrictions, you can restrict the key and select Google Sheets API ⚠️**

</details>

<details>
<summary><strong>How to set up Unity Project</strong></summary>

1. Create a new unity project (or select an existing one).
2. Import **newtonsoft** package.

   > Window -> Package Manager -> install package from git url

   ```text
   com.unity.nuget.newtonsoft-json
   ```

3. Import **TMP Essentials**.

   > Edit -> Project Settings -> TextMesh Pro -> Import TMP Essentials

4. Import the **Package**.

   > Assets -> Import Package -> Custom Package -> Select the package

5. Configure the **Translation editor window**

   > Tools -> Salandananry -> Unity Translation Kit -> Translation Window

6. **Language Selector** set up

   **Attach LanguageSelector script to your Language Selection UI**

   > *Set up example (Click image to expand)*

   <img
     width="478"
     height="67"
     alt="Example set up"
     src="https://github.com/user-attachments/assets/ed33a82c-7a7b-4609-ac76-91dc41c6d78b" />

   **Configure Language Selection Buttons**

   a. For each language button, add an entry to its On Click() event.

   b. Assign the GameObject containing the LanguageSelector script to the object field.

   c. Select LanguageSelector -> ChangeLanguage (string) from the function dropdown.

   d. Enter the language code in the string field (e.g, english, japanese, indonesian etc.)

   **Note: The language code must exactly match the corresponding language name/code used in your Google Sheets.**

   > *Set up example (Click image to expand)*

   <img
     width="942"
     height="241"
     alt="image"
     src="https://github.com/user-attachments/assets/ad74ef39-d674-4e62-b706-5e1889796df3" />

7. **Translate Text** set up

   a. Add the TranslateText script to the Text (TMP) GameObject that requires translation.

   b. Enter the correct Translation Key. This must exactly match a key in the first column of your Google Sheets translation table.

   c. Fill in the Fallback field with the default text to display if the translation key is missing or no translation is available for the selected language.

   > **Note: The fallback text ensures that your UI still displays readable text even when a translation is unavailable.**

</details>

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
