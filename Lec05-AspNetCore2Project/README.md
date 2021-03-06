# CourseWork
Web application for managing students and courses.

#### 1 Setup solution
1.1 ASP.net Core with full .NET Framework.

1.1.1 New Project -> Installed -> Visual C# -> .NET Core - ASP.NET Core Web Application
**Make sure** `.NET Framework 4.7` is targeted.

1.1.2 
**Make sure** `.NET Framework` is selected in first list. 

1.1.3
Second drop down should be `ASP.NET Core 2.0` which is somewhat confusing.

1.1.4
Web Application (Model-View-Controller)

1.2 Remove production CSS and JS. It's confusing for now.

1.3 Remove contact and about pages. It makes to much noise.

1.4 Put two links that look like a button on home page.

1.5 Add links to navigation bar.

#### 2 Manage students

2.1 Add student controller and placeholder page. Make sure that controller and view are wired up nicely.

2.2 Hook up Entity Framework 6.

2.3 Seed students to the database.

2.3.1 Install Tynamix.ObjectFiller from NuGet

2.3.2 Use test method on student controller to get number of students in a database. Idea is to check if students really exist in Students table in the database.

2.4 Create student list view.

2.5 Show student details.

2.6 Show student gender.

2.7 Refactor to repository.

2.8 Change name and namespace for ErrorViewModel. Remove unused using statements.

2.9 Remove student from database. Confirm action. Write success message.

2.10 Enable student editing.

2.11 Refill gender options on validation error.

2.12 Enable client side validation.

2.13 Be able to add a student.

2.14 Refactor create and edit student to partial view.



#### 3. Manage courses

3.1 Seed database with courses. Show list and course details.



#### 4. Enroll students to a course

4.1 Seed database with course enrollments. Show list of students enrolled in a course.

4.2 Enable adding student to course. Write nice message to user on success.

4.3 Enable removing student from course. Write nice message to user on success.



#### 5. Turn tables in searchable grid

5.1 Hook up DataTables to existing tables.
