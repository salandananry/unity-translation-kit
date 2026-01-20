# unity-translation-kit [v0.0.0]
A robust translation system for Unity games using the Google Sheets API.


##  **GETTING STARTED**
### DOWNLOAD THE PACKAGE
- Go to [**Release**](https://github.com/salandananry/unity-translation-kit/releases) and download the latest **Release**.

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
#### [v0.0.0](https://github.com/salandananry/unity-translation-kit/releases/tag/v0.0.0) — 2026-01-06
- Initial release.

## **FAQ** (WIP)
### What happens if there's a missing key or translation
If a key or translation is missing, the system will fall back to the configured fallback value.
### What happens if there's no internet
If there is no internet connection:
- The system will use the fallback value if no local cache exists
- Otherwise, it will use the locally saved translations

  > Local cache may be out of date if changes were made to the source sheet, since an internet connection is required to update the local data.

### Can I use this in a commercial game?
Yes. This project is licensed under the MIT License, which allows commercial use. See the [**LICENSE**](https://github.com/salandananry/unity-translation-kit?tab=MIT-1-ov-file) file for details.
### Does this Support Runtime Language switching?
Yes



