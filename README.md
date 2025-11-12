# 🏙️ Municipal Services App (Final POE 3 Submission)

### Module: **PROG7312 — Application Development**

**Student:** Rubben Shisso (ST10345300)
**Institution:** Varsity College Cape Town
**Project Type:** Windows Forms (.NET Framework 4.8)
**GitHub Repository:** [VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp](https://github.com/VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp)

---

## 🧾 Overview

The **Municipal Services App** is a Windows Forms desktop solution that enables citizens to:

* Report and monitor service delivery issues.
* Track request statuses (`Pending / In Progress / Completed`).
* Explore community events and mark attendance.
* View analytical dashboards summarizing municipal performance.

It promotes **transparency**, **accountability**, and **efficiency** between residents and their local government.

---

## ⚙️ Technologies Used

| Component      | Technology                                        |
| -------------- | ------------------------------------------------- |
| UI Framework   | Windows Forms (.NET Framework 4.8)                |
| Language       | C#                                                |
| Charting       | `System.Windows.Forms.DataVisualization.Charting` |
| Data Storage   | `Newtonsoft.Json` (JSON files)                    |
| Algorithms     | Custom Data Structures + Kruskal MST              |
| IDE            | Visual Studio 2022                                |
| Source Control | Git + GitHub                                      |

---

## ✨ Key Features

### 📝 Report an Issue

* Citizens log municipal issues (Water, Electricity, Roads, Waste etc.).
* Optional **file attachment** for evidence.
* Saved locally in `/Data/issues.json`.

### 📊 Service Status Tracking

* Displays all issues with filterable status.
* Data auto-loads from JSON.
* Paginated UI for better readability.

### 🎉 Community Events

* Up to six events per page.
* Users can mark attendance.
* Saved automatically to `/Data/events.json`.

### 📈 Dashboard & Analytics

* **Bar Chart:** Issues by Category.
* **Pie Chart:** Issues by Status.
* Charts refresh dynamically as new issues are reported.

### 🧭 Route Optimizer (MST Algorithm)

* **New feature for POE 3** — integrated Kruskal’s Minimum Spanning Tree algorithm.
* Calculates the **most cost-efficient route** between municipal areas.
* Demonstrates advanced data-structure usage (Graphs + Union-Find).
* Accessible via the “🧭 Route Optimizer” button on the Dashboard.

### 🪟 Modern UI Enhancements

* Rounded corners and glass-morphic gradient design.
* Clean navigation buttons (Back / Exit / Route Optimizer).
* Responsive form layouts for clarity and usability.

---

## 🧰 Installation & Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/VCCT-PROG7312-2025-G2/ST10345300_MunicipalServicesApp.git
   ```

2. **Open in Visual Studio 2022**

   * Double-click `MunicipalServicesAppPoe_3.sln`.

3. **Install dependencies**

   ```bash
   Install-Package Newtonsoft.Json
   ```

4. **Run the App**

   * Press `F5` to launch.
   * Main Menu opens automatically.

---

## 📂 Project Structure

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
│   └── RouteOptimizer.cs        ← NEW (Kruskal MST feature)
│
├── Forms/
│   ├── MainMenuForm.cs
│   ├── ReportIssuesForm.cs
│   ├── ServiceStatusForm.cs
│   ├── EventsForm.cs
│   └── DashboardForm.cs         ← Updated with Route Optimizer button
│
├── Data/
│   ├── issues.json
│   └── events.json
│
└── README.md
```

---

## ▶️ Demonstration Video

🎥 YouTube Demo: [https://youtu.be/XmZ5xpFE0k0](https://youtu.be/XmZ5xpFE0k0)

---

## 🚀 How to Run

1. Open `MunicipalServicesAppPoe_3.sln` in Visual Studio 2022+.
2. Set the project as **Startup Project** → Build → Run (`F5`).
3. In the Main Menu, you can:

   * Report new issues
   * Track requests
   * View community events
   * Open the Dashboard and use the 🧭 Route Optimizer

---

## 🔄 Data Flow Summary

```
User Input
   ↓
IssueManager / EventManager
   ↓
JSON Storage
   ↓
UI Forms & Charts → Dashboard + MST Report
```

All data persists automatically between sessions.

---

## 💡 Concepts Demonstrated

* **Data Persistence** (JSON read/write)
* **Object-Oriented Programming** (models + services)
* **Custom Data Structures** (Binary Search Tree, Graph, MST)
* **Algorithmic Optimization** (Kruskal MST using Union-Find)
* **Dynamic UI Rendering** (GDI+ gradients & Charting)
* **User Experience Design** (glass-morphic forms + navigation buttons)
* **Version Control** (Git branching and rebasing workflow)

---

## 🕒 Changelog / Version History

### **POE Part 1 — Initial Prototype**

* Implemented base UI structure using WinForms.
* Added Issue Reporting form with JSON storage.
* Created IssueManager and EventManager services.
* Designed simple navigation (Main Menu, Report, Track, Events).

### **POE Part 2 — Feature Expansion**

* Enhanced UI layout with gradient backgrounds and rounded corners.
* Added Service Status tracking form and dynamic dashboard charts.
* Introduced community event functionality and pagination.
* Improved JSON data handling and error checking.

### **POE Part 3 — Final Submission (Data Structures & Optimization)**

* Added **RouteOptimizer.cs** implementing **Kruskal’s Minimum Spanning Tree (MST)** algorithm.
* Updated Dashboard with **🧭 Route Optimizer** button integration.
* Improved form responsiveness and styling consistency.
* Updated README documentation and project report.
* Completed Git workflow with feature commits and final push.

---

## 👏 Credits & Acknowledgments

Developed by **Rubben Shisso (ST10345300)**
for **Varsity College Cape Town — Programming 3B (PROG7312)**
Group Repository: **VCCT-PROG7312-2025-G2**
Final Deliverable: **POE Part 3 – Data Structures & Optimization**

