#  Municipal Services App (Final POE 3 Submission)

###  Module: PROG7312 — Application Development  
**Student:** Rubben Shisso (ST10345300)  
**Institution:** Varsity College Cape Town  
**Project Type:** Windows Forms (.NET Framework 4.8)  
**GitHub Repository:** [VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp](https://github.com/VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp)

---

## 🧾 Overview

The **Municipal Services App** is a desktop application that enables citizens to:
- Report service delivery issues to their municipality.
- Track the status of reported issues.
- View community events and notices.
- Access a dashboard visualizing issue trends.

It’s designed to **promote transparency, accountability, and efficiency** between residents and municipal departments.

---

##  Technologies Used

| Component | Technology |
|------------|-------------|
| UI Framework | Windows Forms (.NET Framework 4.8) |
| Language | C# |
| Charting | System.Windows.Forms.DataVisualization.Charting |
| JSON Data Storage | Newtonsoft.Json |
| IDE | Visual Studio 2022 |
| Source Control | Git & GitHub |

---

##  Features

###  Report an Issue  
- Citizens can log service issues (Water, Electricity, Roads, Waste, etc.).  
- Includes **file attachment** (e.g., photo evidence).  
- Automatically stores issue data in a JSON file (`/Data/issues.json`).

###  Service Status Tracking  
- Displays all reported issues with their current status.  
- Statuses: `Pending`, `In Progress`, `Completed`.  
- Pagination for improved readability.

###  Community Events  
- Displays up to **6 events per page**.  
- Users can mark events as attended.  
- Automatically saves event state.

###  Dashboard  
- Interactive data visualizations:
  - **Bar Chart:** Issues per Category.
  - **Pie Chart:** Issues per Status.
- Graphs auto-update as new issues are reported.

###  Attachments  
- Added in **ReportIssuesForm**.  
- Allows users to attach supporting photos/documents.  
- Displays the file name after upload.

###  Exit & Navigation Buttons  
- Each form includes an **Exit** button.  
- Clean transitions between forms (Main Menu → Report / Track / Events / Dashboard).

---

##  Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp.git
   ```

2. **Open the project in Visual Studio 2022.**
   - Double-click the `.sln` file.

3. **Ensure these NuGet packages are installed:**
   ```bash
   Install-Package Newtonsoft.Json
   ```

4. **Run the App:**
   - Press `F5` in Visual Studio.
   - The **Main Menu Form** will load.

---

## 🧩 File Structure

```
MunicipalServicesAppPoe_3/
│
├── Models/
│   └── IssueReport.cs
│
├── Services/
│   ├── IssueManager.cs
│   ├── EventManager.cs
│   └── InMemoryRepository.cs
│
├── Forms/
│   ├── MainMenuForm.cs
│   ├── ReportIssuesForm.cs
│   ├── ServiceStatusForm.cs
│   ├── EventsForm.cs
│   └── DashboardForm.cs
│
├── Data/
│   ├── issues.json
│   └── events.json
│
└── README.md
```


##  How to Run the Application
1. Open the solution file  
   ```
   MunicipalServicesAppPoe_3.sln
   ```
   in **Visual Studio 2022** (or newer).

2. Set the project as **Startup Project** and build.

3. Run  to launch the **Main Menu**, where you can:
   - Report a new issue  
   - Track requests  
   - View community events  
   - Open the analytics dashboard

---

##  Data Flow Summary
```
User Input → IssueManager / EventManager → JSON Storage → UI Display → Charts
```
All data updates are **automatically persisted** between sessions.

---

##  Concepts Demonstrated
- **Data Persistence** using JSON.  
- **Dynamic UI Rendering** with custom GDI+ graphics.  
- **Encapsulation & OOP Structure** (separate Models and Services).  
- **Data Visualization** using Charts.  
- **User Experience** with paginated navigation & glass-morphic styling.

---

##  Credits & Acknowledgments
Developed by **Rubben Shisso (ST10345300)**  
for **VCCT – Varsity College Cape Town**  
Module: **PROG7312 – Programming 3B (2025)**  
Group: **VCCT-PROG7312-2025-G2**

