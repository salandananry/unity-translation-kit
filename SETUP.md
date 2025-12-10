# SET UP <br>
# TABLE OF CONTENTS <br>
- [Acquire Google Sheets API key](#acquire-google-sheets-api-key)
- [Acquire Spreadsheet ID](#acquire-spreadsheet-id)

<details>
  <summary><strong>Acquire Google Sheets API key</strong></summary>
  
1. Create a new project if you don't have one yet. <br>
2. Select the project and open the navigation menu (top left). <br>
3. Under Products section, **APIs & Services** -> **Library**. <br>
> You can do these in 2 different ways
>> Hover over **APIs & Services** and select **Library** <br>
<img width="1234" height="789" alt="Open Library 1" src="https://github.com/user-attachments/assets/7bd376bb-b3ff-4663-b1fd-caa77a7f368f" /> <br>
>> or <br>
>>Select **APIs & Services** then select **Library** <br>
<img width="1403" height="795" alt="Open Library 2" src="https://github.com/user-attachments/assets/ca1c6305-b1f7-4f07-bdff-6977629bfba7" /> <br>
4. In API Library, look for **Google Workspace** section and select **Google Sheets API** and **Enable** it. <br>
<img width="3536" height="1650" alt="Enable Google Sheets API" src="https://github.com/user-attachments/assets/c1b17a77-3126-49d5-8689-14899d95d5bf" /> <br>
5. Go to **Credentials** -> **Create credentials** then select **API Key**. <br>
<img width="1931" height="801" alt="Create API key" src="https://github.com/user-attachments/assets/b4f43ee9-ecc4-4d7d-84d0-015f144a5268" /> <br>
6. Enter your key name and **Create**. <br>
> Under the **API restrictions** section, you can restrict your key so it only allows access to the **Google Sheets API**. <br>
<img width="1063" height="1680" alt="API restrictions" src="https://github.com/user-attachments/assets/50a1f945-7ee4-48f2-9299-1dc66b656970" /> <br>
  
</details>

<details>
  <summary><strong>Acquire Spreadsheet ID</strong></summary>
  
1. Go to **Google Sheets** and create a new blank spreadsheet. <br>
2. Change the **General Access** to **Anyone with the link [Viewer]**. <br>
3. Copy the share link and paste it to a notepad. <br>
4. Your Spreadsheet ID would be between "**d/**" and "**/edit**". <br>
> For example: `https://docs.google.com/spreadsheets/d/YOUR_SPREADSHEET_ID/edit?usp=sharing`. <br>
  
</details>

<details>
  <summary><strong>Unity set up</strong></summary>
<details>
  <summary><strong>Import the following scripts to your game</strong></summary>

  - LanguageDatabase.cs <br>
  - LanguageSelector.cs <br>
  - TranslateText.cs <br>
  - TranslationSheet.cs <br>
  - ConnectionStatus.cs <br>
  - IInitializer.cs <br>
  - AutoBootstrapper.cs <br>
  - InitializeManager.cs <br>

  - DebugHandler.cs (Optional) <br>
  >> If you didn't import this, you will have to adjust some of the scripts to use the default debug logs. <br>
  
</details>
<details>
  <summary><strong>Import the following packages</strong></summary>

  - TMP Essentials <br>
  - Newtonsoft.Json <br>
  > com.unity.nuget.newtonsoft-json
</details>
</details>

<details>
  <summary><strong>Spreadsheet Example</strong></summary>

  <img width="1943" height="1315" alt="image" src="https://github.com/user-attachments/assets/6359cf0a-17c0-4830-ad4d-ef2df8a2b82d" /> <br>
  > First column would be your **keys**, each must be unique. <br>
  > You can add multiple sheets. <br>
  > Second column and so on would be your translations for each language. <br>
  
</details>
