## Doctor Appointment System

## Description:

This web application is a doctor appointment system built using ASP.NET Web API with Entity Framework. It empowers users to schedule appointments with doctors based on their availability and departments. The system adheres to the CRUD (Create, Read, Update, Delete) operation pattern with Master-Details functionality and image upload capabilities. Notably, it leverages JSON Web Token (JWT) for robust authentication and authorization.

## Key Features:

User Management: Users can register and log in to the system to schedule appointments with ease.
Doctor Management: Doctors have the ability to manage their profiles, schedules, and appointments effectively.
Department Management: Create and manage departments to categorize doctors and their specialties for a streamlined user experience.
CRUD Operations: Doctors and departments can be created, edited, viewed, and deleted, ensuring flexibility and data maintenance.
Master-Details: Doctors are associated with their corresponding departments, offering a hierarchical view of the system for better organization.
Image Upload: Doctors can upload profile pictures to personalize their online presence.
JWT Authentication: Users are authenticated using JWT tokens, safeguarding secure access to the system.
## Technologies:

ASP.NET Web API
Entity Framework
.NET Framework 4.8
JSON Web Token (JWT)
OWIN (Open Web Interface for .NET)
Visual Studio 2022

## Getting Started (Before running the application):

1. **Download the project from the master branch on GitHub (or another branch if preferred).**

2. [OPTIONAL] **Create a folder named "roslyn" within the "bin" folder of the project (due to GitHub ignoring the Roslyn folder).** 

3. **Modify the SQL Server connection string in the configuration files ("Web.config" file).**

   - Update the `dbconnection` in the `Web.config` file with your SQL Server connection string.

4. **Open the Package Manager Console in Visual Studio and run the following commands:**

   enable-migrations
   add-migration InitialCreate
   update-database
   
## Getting Started (After running the application):

1. Create a row in the ConsumerInfo table through the management studio with the following values:
(ConsumerName, Password, Role)
2. Generate a token via Postman (or similar apps) using the ConsumerName and Password values of the created row.

3. Upload an image via Postman (or similar apps).

4. Generate a new Department via Postman (or similar apps).

5. Generate a new Doctor via Postman (or similar apps).

## Note:

Ensure you have the necessary pre-requisites installed, such as .NET Framework 4.8 and SQL Server.
Refer to the project code for detailed information on specific features and functionalities.

## Feedback and Contributions:

You are welcome to give your valueable feedback and contributions to improve this project. Feel free to open issues or pull requests on the GitHub repository.
