## Doctor Appointment System 

**Description:**

This web application is a doctor appointment system built using ASP.NET Web API with Entity Framework. It allows users to schedule appointments with doctors based on their availability and department. The system follows a CRUD (Create, Read, Update, Delete) operation pattern with Master-Details functionality and image upload capabilities. Notably, it implements JSON Web Token (JWT) for secure authentication and authorization.

**Key Features:**

* **User Management:** Users can register and log in to the system to access appointment scheduling functionalities.
* **Doctor Management:** Doctors can manage their profiles, schedules, and appointments.
* **Department Management:** Departments can be created and managed to categorize doctors and their specialties.
* **CRUD Operations:** Doctors and departments can be created, edited, viewed, and deleted.
* **Master-Details:** Doctors are associated with their respective departments, providing a hierarchical view of the system.
* **Image Upload:** Doctors can upload their profile pictures.
* **JWT Authentication:** Users are authenticated using JWT tokens, ensuring secure access to the system.

**Technologies:**

* ASP.NET Web API
* Entity Framework
* .NET Framework 4.8
* JSON Web Token (JWT)
* OWIN (Open Web Interface for .NET)
* Visual Studio 2022

**Getting Started:**

1. Download the project from the master branch on GitHub (or another branch if preferred).
2. Create a folder named "roslyn" within the "bin" folder of the project (due to GitHub ignoring the Roslyn folder).
3. Modify the SQL Server connection string in the configuration files ("Web.config" file).
4. Open the Package Manager Console in Visual Studio and run the command `update-database`.
5. Run the project in Visual Studio.

**Note:**

* Ensure you have the necessary pre-requisites installed, such as .NET Framework 4.8 and SQL Server.
* Refer to the project code for detailed information on specific features and functionalities.


**Feedback and Contributions:**

You are welcome to give your valueable feedback and contributions to improve this project. Feel free to open issues or pull requests on the GitHub repository.



