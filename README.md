# AIUB Ideas Gateway

Welcome to the **AIUB Ideas Gateway** - for sharing blog posts, showcasing projects, and posting job opportunities for the AIUB community. This API application is built using ASP.NET, adhering to SOLID principles, ensuring scalability, maintainability, and performance.

Note: For Api-Endpoints please refer to the [`API-Doc`](https://github.com/sadhiin/AIUB_Ideas_Gateway/blob/master/API-doc.md)
## Features

### General:

1. **Blog Posts**:
    * Users can share their ideas, experiences, and knowledge through blog posts.
    * CRUD (Create, Read, Update, Delete) operations available for each user on their respective posts.
  
2. **Project Showcases**:
    * Users can display their projects, giving others the opportunity to view, appreciate, and collaborate.
    * CRUD operations available for each user on their showcased projects.

3. **Job Postings**:
    * Users can post job opportunities for the community.
    * CRUD operations available for each user on their job postings.

### User Specific:

1. **Registration**: New users can register for an account.
2. **Login & Logout**: Secure login and logout functionality through the API.
3. **Authentication & Authorization**: 
    * User actions are authenticated using a token-based system.
    * Authorization ensures users can only modify or delete their own posts and job listings.

### Admin Specific:

1. **Oversee All Content**:
    * View all blog posts, projects, and job postings.
    * Edit or delete any post or job listing.
  
2. **User Management**:
    * View all registered users.
    * Temporarily or permanently ban a user.
  
3. **Insightful Statistics**:
    * See the number of currently logged-in users.
    * View the total number of posts, projects, jobs, and users.

## Technical Overview

**Technology Stack**:

- **Backend**: ASP.NET
- **Architecture**: SOLID principles

**Security**:

- Token-based authentication and authorization to ensure data security and user privacy.

## Getting Started

### Prerequisites

- Ensure you have the .NET SDK installed.
- A suitable IDE for .NET development (e.g., Visual Studio).

### Installation & Setup

1. Clone the repository: 
```
git clone https://github.com/sadhiin/AIUB_Ideas_Gateway.git
```
2. Navigate to the project directory and restore the required packages:
```
cd AIUB-Ideas-Gateway
dotnet restore
```
3. Run the application:
```
dotnet run
```
4. The API endpoints will be available at `http://localhost:[port]`.

## Contribution

To contribute to this project:

1. Fork the repository.
2. Create a new branch.
3. Commit your changes and push to the branch.
4. Create a pull request.

## License


This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- The AIUB community for inspiring the creation of this platform.
- All contributors and developers who made this project possible.

---

<a href="https://github.com/remarkablemark/html-react-parser/graphs/contributors">
  <img src="https://opencollective.com/html-react-parser/contributors.svg?width=890&button=false">
</a>

We hope the **AIUB Ideas Gateway** serves as an effective platform for the AIUB community to connect, share, and grow.
