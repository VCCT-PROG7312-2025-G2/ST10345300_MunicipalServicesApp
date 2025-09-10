# ST10345300_MunicipalServicesApp

POE Part 1 Submission
Student: Rubben Shisso
Student Number: ST10345300
Module: Programming 7312

How to Compile and Run:
1. Open the "MunicipalServicesApp.sln" solution file in Visual Studio 2022.
2. Build the project (Ctrl + Shift + B).
3. Run the project (F5).

Application Overview:
- Main Menu:
  Provides entry to "Report Issues", "Community Notices" (disabled),
  and "Track My Requests" (plus extra View Issues button).

- Report Issues:
  Allows users to capture issue details:
    * Location (TextBox)
    * Category (ComboBox)
    * Description (RichTextBox)
    * File Attachment (Browse Button + Path display)
    * Submit and Cancel buttons
    * Progress bar feedback

- View Issues:
  Displays all submitted issues in a DataGridView.
  Issues are stored in a custom-built Queue (linked list implementation).
  "Remove Oldest Issue" button demonstrates FIFO behavior.

Data Structures:
- Custom Queue implemented in IssueQueue.cs (using linked nodes).
- Issues represented by Issue.cs.
- Demonstrates enqueue (Submit) and dequeue (Remove Oldest).

Notes:
- No database is used; all data is stored in memory.
- This project targets .NET 8 and compiles successfully in Visual Studio 2022.
