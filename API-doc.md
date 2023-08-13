# AIUB Ideas Gateway API Documentation

Welcome to the **AIUB Ideas Gateway** API documentation. Here, you'll find the detailed specifications for each endpoint and how to utilize them.

## General Endpoints

### 1. Retrieve All Posts

- **Endpoint**: `api/home`
- **Method**: `HttpGet`
- **Response**: List of JSON objects of all the posts

### 2. Search for Posts

- **Endpoint**: `api/home/search/post/{query}`
- **Method**: `HttpGet`
- **Parameters**: 
  - `query`: Search query (Data type: string)
- **Response**: List of JSON objects of matched title posts

### 3. Search for Jobs

- **Endpoint**: `api/home/search/job/{query}`
- **Method**: `HttpGet`
- **Parameters**: 
  - `query`: Search query (Data type: string)
- **Response**: List of JSON objects of matched job titles

## Authentication Endpoints

### 4. Login

- **Endpoint**: `api/login`
- **Method**: `HttpPost`
- **Body**: 
  - `LoginModel`: Object of the LoginModel class
- **Response**: Access token (Data type: string)

### 5. Register

- **Endpoint**: `api/register`
- **Method**: `HttpPost`
- **Body**: 
  - `RegisterModel`: Object of the RegisterModel class
- **Response**: Success message (Data type: string)

### 6. Logout

- **Endpoint**: `api/logout`
- **Method**: `HttpPost`
- **Response**: Logout message

## Admin Endpoints

### 7. Retrieve a Job Post

- **Endpoint**: `api/admin/jobpost/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: JobDTO object

### 8. Update a Post

- **Endpoint**: `api/admin/post/update`
- **Method**: `HttpPost`
- **Body**: 
  - `postDTO`: Object of the postDTO class
- **Response**: Message (Data type: string)

### 9. Retrieve Total Number of Job Posts

- **Endpoint**: `api/admin/job/totalpost`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: Total number of posts (Data type: number)

### 10. Retrieve Number of Active Users

- **Endpoint**: `api/admin/active`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: Number of active users (Data type: number)

### 11. Delete a Job Post

- **Endpoint**: `api/admin/jobpost/delete/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: Message

### 12. Update a Job Post

- **Endpoint**: `api/admin/jobpost/update`
- **Method**: `HttpPost`
- **Body**: 
  - `JobDto`: Object of the JobDTO class
- **Response**: Message

## Job Endpoints

### 13. Retrieve All Job Posts

- **Endpoint**: `api/jobs`
- **Method**: `HttpGet`
- **Response**: List of JSON objects of all the job posts

### 14. Retrieve an Individual Job Post

- **Endpoint**: `api/job/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the job post (Data type: number)
- **Response**: JSON object of the job

### 15. Create a Job Post (Logged-in Users Only)

- **Endpoint**: `api/job/create`
- **Method**: `HttpPost`
- **Body**: 
  - `JobDTO`: Object of the JobDTO class
- **Response**: Message (Data type: string)

### 16. Update a Job Post (Own Posts Only)

- **Endpoint**: `api/job/update`
- **Method**: `HttpPost`
- **Body**: 
  - `JobDTO`: Object of the JobDTO class
- **Response**: Message (Data type: string)

### 17. Delete a Job Post (Own Posts Only)

- **Endpoint**: `api/job/delete`
- **Method**: `HttpPost`
- **Body**: 
  - `JobDTO`: Object of the JobDTO class

### 18. Retrieve a Post (Admin Only)

- **Endpoint**: `api/admin/post/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)

### 19. Create a Post (Admin Only)

- **Endpoint**: `api/admin/post/create`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)

### 20. Delete a Post (Admin Only)

- **Endpoint**: `api/admin/post/delete/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: Message

## Comment Endpoints

### 21. Retrieve All Comments

- **Endpoint**: `api/comment/all`
- **Method**: `HttpGet`
- **Response**: JSON object of all comments

### 22. Create a Comment

- **Endpoint**: `api/comment/create`
- **Method**: `HttpPost`
- **Body**: 
  - Comment object
- **Response**: Boolean indicating success or failure

### 23. Retrieve a Comment

- **Endpoint**: `api/comment/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the comment (Data type: number)
- **Response**: JSON object of the comment

### 24. Delete a Comment

- **Endpoint**: `api/comment/delete/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the comment (Data type: number)

### 25. Retrieve Comments of a Post

- **Endpoint**: `api/comment/post/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)

### 26. Retrieve Comments of a Job

- **Endpoint**: `api/comment/job/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the job (Data type: number)

### 27. Retrieve Comments by a User

- **Endpoint**: `api/comment/user`
- **Method**: `HttpGet`

### 28. Retrieve Comments by a Specific User

- **Endpoint**: `api/comment/user/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the user (Data type: number)

### 29. Retrieve Comments for a Specific User's Post

- **Endpoint**: `api/comment/userpost/{postId}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `postId`: ID of the post (Data type: number)

### 30. Retrieve Comments for a Specific User's Job

- **Endpoint**: `api/comment/userjob/{jobId}`
- **Method**: `HttpPost`
-

 **Parameters**: 
  - `jobId`: ID of the job (Data type: number)

### 31. Retrieve Comment Count for a Post

- **Endpoint**: `api/comment/postcount/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the post (Data type: number)
- **Response**: Number of comments for the post

### 32. Retrieve Comment Count for a Job

- **Endpoint**: `api/comment/jobcount/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the job (Data type: number)
- **Response**: Number of comments for the job

### 33. Update a Comment

- **Endpoint**: `api/comment/update/{id}`
- **Method**: `HttpPost`
- **Parameters**: 
  - `id`: ID of the comment (Data type: number)

---

This documentation provides an overview of the available endpoints for the **AIUB Ideas Gateway**.