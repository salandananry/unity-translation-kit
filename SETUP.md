# SET UP [ WORK IN PROGRESS ]<br>

<details>
  <summary><strong>Acquire Google Sheets API key</strong></summary>
  
1. Create a new project if you don't have one yet. <br>
2. Select the project and open the navigation menu (top left). <br>
3. Under Products section, **APIs & Services** -> **Library**. <br>
><details>
>  <summary><strong>Visual guide</strong></summary>
> <div align="center"><strong>- START OF VISUAL GUIDE -</strong></div>
> [A] Hover over <strong>APIs & Services</strong> and select <strong>Library</strong> <br>
> <img width="1234" height="789" alt="Open Library 1" src="https://github.com/user-attachments/assets/7bd376bb-b3ff-4663-b1fd-caa77a7f368f" /> <br>
> [B] Select <strong>APIs & Services</strong> then select <strong>Library</strong> <br>
> <img width="1403" height="795" alt="Open Library 2" src="https://github.com/user-attachments/assets/ca1c6305-b1f7-4f07-bdff-6977629bfba7" /> <br>
> <div align="center"><strong>- END OF VISUAL GUIDE -</strong></div>

4. In API Library, look for **Google Workspace** section and select **Google Sheets API** and **Enable** it. <br>
><details>
>    <summary><strong>Visual guide</strong></summary>
> <div align="center"><strong>- START OF VISUAL GUIDE -</strong></div>
> <img width="3536" height="1650" alt="Enable Google Sheets API" src="https://github.com/user-attachments/assets/c1b17a77-3126-49d5-8689-14899d95d5bf" /> <br>
> <div align="center"><strong>- END OF VISUAL GUIDE -</strong></div>

5. Go to **Credentials** -> **Create credentials** then select **API Key**. <br>
><details>
>    <summary><strong>Visual guide</strong></summary>
> <div align="center"><strong>- START OF VISUAL GUIDE -</strong></div>
> <img width="1931" height="801" alt="Create API key" src="https://github.com/user-attachments/assets/b4f43ee9-ecc4-4d7d-84d0-015f144a5268" /> <br>
> <div align="center"><strong>- END OF VISUAL GUIDE -</strong></div>

6. Enter your key name and **Create**. <br>
> Under the **API restrictions** section, you can restrict your key so it only allows access to the **Google Sheets API**. <br>
><details>
>    <summary><strong>Visual guide</strong></summary>
> <div align="center"><strong>- START OF VISUAL GUIDE -</strong></div>
> <img width="1063" height="1680" alt="API restrictions" src="https://github.com/user-attachments/assets/50a1f945-7ee4-48f2-9299-1dc66b656970" /> <br>
> <div align="center"><strong>- END OF VISUAL GUIDE -</strong></div>
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
  <summary><strong>Unity Setup</strong></summary>
  <details>
    <summary><strong>Import the package</strong></summary>
1. Go to <a href="https://github.com/salandananry/unity-translation-kit/releases"> <strong>Release</strong></a> and download the latest package. <br>
2. Once downloaded, open your unity project > <strong>Assets</strong> > <strong>Import Package</strong> > <strong>Custom Package</strong> > and select the recently downloaded package. <br>
  </details>
  <details>
    <summary><strong>Import Newtonsoft Package</strong></summary>

> Go to <strong>Window</strong> > <strong>Package Manager</strong> > <strong>Click the + sign (top left)</strong> > <strong>Install package from git URL</strong> > Paste this <strong> com.unity.nuget.newtonsoft-json <strong> <br>
  </details>
</details>
</details>

<details>
  <summary><strong>Spreadsheet Example</strong></summary>

  <img width="1943" height="1315" alt="image" src="https://github.com/user-attachments/assets/6359cf0a-17c0-4830-ad4d-ef2df8a2b82d" /> <br>
  > First column would be your **keys**, each must be unique. <br>
  > You can add multiple sheets. <br>
  > Second column and so on would be your translations for each language. <br>
  
</details>

