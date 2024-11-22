# PART3 POE

Project Overview

PART3_POE is the final implementation of a Contract Monthly Claim System. This application automates claim submission, calculation, verification, approval, and HR processing for lecturers, coordinators, managers, and HR staff.

This project was developed as part of a Portfolio of Evidence (POE) for academic evaluation at Rosebank College. It leverages ASP.NET Web Forms, MySQL, and VB.NET to deliver a functional and user-friendly solution.

Features

1. Lecturer View:

Automated claim submissions.

Pre-filled claim details for efficiency.



2. Coordinator View:

Claim verification and approval workflows.

Dashboard for pending claims.



3. Manager View:

Review and final approval of claims.

Notifications for claims requiring attention.



4. HR View:

Export claim data for payroll processing.

Historical claims tracking and reporting.



5. System Automation:

Automatic calculation of claim amounts.

Real-time status updates.




Technology Stack

Frontend: ASP.NET Web Forms

Backend: VB.NET

Database: MySQL (Hosted on Server=labG9AEB3\MSSQLSERVER01)

Styling: Minimal custom CSS

Libraries: jQuery for client-side interactivity


Installation Guide

1. Clone this repository:

git clone https://github.com/Makaphile/PART3_POE.git


2. Open the solution in Visual Studio 2022.


3. Configure the database connection:

Update the web.config file with your MySQL connection details.



4. Build and run the project.



Database Details

Database Name: LecturerClaimsDB

Tables:

LecturerClaims (Stores submitted claims)

Users (Stores user roles and credentials)

Approvals (Tracks claim approval status)


How to Use

1. Log in with appropriate credentials:

Lecturer, Coordinator, Manager, or HR roles.



2. Navigate through the system based on your assigned role.


3. Submit, verify, approve, or process claims using the provided views.


4. Export processed claims to integrate with payroll.

Development Practices

Version Control:

At least 10 commits with detailed messages.

Followed Git best practices for branching and merging.


Testing:

Extensive testing performed for each role's functionality.


Accessibility:

Implemented according to WCAG 2.0 standards for usability.


Future Enhancements

Add email notifications for claim status changes.

Implement API endpoints for external integration.

Improve user interface for a modern look and feel.


Contributors

Makaphile– Developer, Database Designer, and Tester
