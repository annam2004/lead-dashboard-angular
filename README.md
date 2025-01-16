# lead-dashboard-angular
This is a web application built with Angular to manage, view, and interact with lead data. The application provides features for displaying lead information, sending notifications via email and text, and exporting lead data to Excel. The dashboard is integrated with a REST API that handles real-time lead updates.

Technologies Used
Frontend: Angular, HTML, CSS, Bootstrap 5
Backend: ASP.NET Core (API)
Excel Export: ExcelJS

Steps to Run the Angular Project Locally
1. Clone the repository to your local machine:
    git clone https://github.com/your-username/angular-dashboard.git
2. Navigate into the project directory:
   cd lead-dashboard-angular
3. Install the project dependencies:
   npm install
   npm install exceljs
   npm install bootstrap
4. Run the application locally

Configuration for Backend API:
Update the apiUrl to point to your local API in:  src/environments/environment.ts 

API Documentation
You can use tools like Swagger for testing API.

POST /api/leads: Submit a new lead.
GET /api/leads: Retrieve all leads.
GET /api/leads/{id}: Retrieve a specific lead by ID.

To test Lead Creation
The lead data should include:
- Name (Required)
- PhoneNumber (Required, valid formats: 1234567890 or 123-456-7890)
- ZipCode (Required)
- HasEmailPermission (Required, boolean)
- HasTextPermission (Required, boolean)
- Email (Optional, must follow a valid email format if provided)

Send a valid POST:
{
  "name": "Name",
  "phoneNumber": "555-555-5555",
  "zipCode": "12345",
  "hasEmailPermission": true,
  "hasTextPermission": true,
  "email": "test@gmail.com"
}

   
