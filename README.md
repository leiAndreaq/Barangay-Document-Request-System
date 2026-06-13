# Barangay Management System

A desktop application built with **C# Windows Forms (.NET 8)** designed to digitize and streamline barangay-level operations in the Philippines.

## Features

- **Role-Based Access Control** — Separate dashboards for Admin, Staff, and Purok Leaders
- **Resident Records Management** — Register, view, edit, and search residents
- **Purok Leader Management** — Manage purok assignments and leaders
- **Service Requests** — Track and manage barangay service requests with date filtering
- **Endorsements** — Generate and manage resident endorsement documents exported as PDF
- **QR Code System** — Generate unique QR codes per resident and scan them via webcam using live camera feed
- **PDF Generation** — Export records and endorsements using iText7 and PDFsharp
- **Staff & Account Management** — Create and manage staff users and roles

## Tech Stack

|    Layer     |             Technology             |
|--------------|------------------------------------|
| Language     | C# (.NET 8)                        |
| UI Framework | Windows Forms                      |
| Database     | Microsoft SQL Server (SQL Express) |
| PDF Export   | iText7, PDFsharp                   |
| QR Code      | QRCoder, ZXing.Net                 |
| Camera Input | AForge.Video, OpenCvSharp4         |

## Requirements

- Windows OS
- .NET 8 SDK
- Microsoft SQL Server Express
- A webcam (for QR scanning feature)

## Database

The system connects to a local SQL Server instance (`brgy-sys` database). You will need to configure the connection string in the source files to match your local SQL Server instance.
