CREATE DATABASE TrackDB
-- Students table
CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Department VARCHAR(50) NOT NULL,
    YearOfStudy INT NOT NULL CHECK (YearOfStudy BETWEEN 1 AND 5)
);

-- Courses table
CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL CHECK (Credits BETWEEN 1 AND 10),
    Semester VARCHAR(20) NOT NULL CHECK (Semester IN ('Fall','Spring','Summer','Monsoon','Winter'))
);

-- Enrollments table
CREATE TABLE Enrollments (
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATETIME NOT NULL DEFAULT(GETDATE()),
    Grade VARCHAR(5) NULL,
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
    CONSTRAINT UQ_Student_Course UNIQUE (StudentId, CourseId) -- prevent duplicate enrollments
);

INSERT INTO Students (FullName, Email, Department, YearOfStudy) VALUES
('Rohit', 'rohit@gmail.com', 'Computer Science', 2),
('gill', 'gill@gmail.com', 'Electronics', 3),
('suraya', 'suraya@gmail.com', 'Mechanical', 1),
('Nair', 'nair@gmail.com', 'Computer Science', 4),
('Hardik', 'hardik@gmail.com', 'Civil', 2);

-- Insert Courses
INSERT INTO Courses (CourseName, Credits, Semester) VALUES
('Data Structures', 4, 'Fall'),
('Database Systems', 3, 'Fall'),
('Operating Systems', 4, 'Spring'),
('Digital Signal Processing', 3, 'Spring'),
('Thermodynamics', 3, 'Fall'),
('Structural Analysis', 4, 'Spring');


INSERT INTO Enrollments (StudentId, CourseId, EnrollDate, Grade) VALUES
(1, 1, '2025-09-21', 'A'),
(1, 2, '2024-08-20', 'A'),
(2, 4, '2023-07-02', 'B+'),
(3, 5, '2022-06-05', 'C'),
(4, 1, '2021-05-03', 'A-'),
(4, 3, '2020-04-01', 'D'),
(5, 6, '2019-08-04', 'B');


create procedure usp_GetCoursesBySemester
    @semester NVARCHAR(50)
as
begin
    select CourseId,CourseName,Credits,Semester
    from Courses where Semester = @semester;
end;

