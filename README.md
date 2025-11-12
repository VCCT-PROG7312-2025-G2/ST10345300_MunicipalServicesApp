#  Municipal Services App (Final Submission – PROG7312 Part 3)

### Developer
**Rubben Shisso – ST10345300**  
VCCT – Bachelor of Computer & Information Sciences in Application Development  

---

##  Overview
The **Municipal Services App** is a C# Windows Forms application designed to streamline how community members interact with municipal services.  
It provides residents with a modern digital platform to **report issues**, **track service requests**, and **stay informed** about **community events**, supported by a visual **dashboard** for data analytics.

---

## 🚀 Features

###  Report Issues
- Citizens can log issues such as water leaks, potholes, or power outages.  
- Each issue includes a **category, location, description, and status**.  
- Issues are stored locally in a JSON file using the `IssueManager` service.

###  Track My Requests
- Displays all reported issues in a modern, glass-morphic interface.  
- Statuses can be toggled between **Pending → In Progress → Completed**.  
- Pagination prevents scroll overflow for smoother navigation.

###  Community Events
- View up to **six community events per page**, displayed in uniform frosted-glass cards.  
- Each card includes a title, date, and description with a small **“Mark as Attended”** button.  
- Data is handled through `EventManager`, stored persistently in JSON.

###  Dashboard Analytics
- Interactive **charts** visualize:
  - Issues by Category (Bar Graph)
  - Issues by Status (Pie Chart)
- Fully centered layout with visible navigation and exit buttons.

###  Additional Details
- Gradient backgrounds with frosted-glass cards and accent-colored hover effects.  
- All forms use rounded corners and a consistent aesthetic.  
- Each page includes an **Exit Button** for user convenience.

---

##  Technologies Used
| Layer | Technology |
|-------|-------------|
| Framework | **.NET Framework 4.8** |
| Language | **C# WinForms** |
| Data Storage | **JSON Serialization (Newtonsoft.Json)** |
| UI Design | **Custom GDI+ Drawing, Gradient Brushes, Rounded Corners** |
| Charts | **System.Windows.Forms.DataVisualization.Charting** |

---

##  Project Structure
```
MunicipalServicesAppPoe_3/
│
├── Models/
│   └── IssueReport.cs
│
├── Services/
│   ├── IssueManager.cs
│   ├── EventManager.cs
│   ├── InMemoryRepository.cs
│
├── Forms/
│   ├── MainMenuForm.cs
│   ├── ReportIssuesForm.cs
│   ├── ServiceStatusForm.cs
│   ├── EventsForm.cs
│   ├── DashboardForm.cs
│
├── Data/
│   ├── issues.json
│   └── events.json
│
├── MunicipalServicesAppPoe_3.sln
└── README.md
```

---

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

## 📊 Data Flow Summary
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

