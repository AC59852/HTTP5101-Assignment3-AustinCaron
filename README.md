# HTTP5101-Assignment3-AustinCaron

## Description
This project was created as a school assignment. The goal is to create an API that accesses an SQL database
<br>
to receive data about teachers, and display that data in multiple ways: As a list of teachers using their names,
<br>
and a specific dynamic route to view an individual teacher and their specific data.

## Installation
- Clone/Fork the Repo
- Make sure you have Visual Studio, as well as the ASP.NET Core content downloaded
- Load the project, and run it in your browser using the top green arrow (>) icon
- Navigate to one of the routes listed below to view the content

## Routes
- /api/TeacherData/ListTeachers: To view the raw Teacher data
- /api/TeacherData/TeacherLogic/{teacherid}: To view the raw data on a specific teacher, where teacherid = a number
- /Teacher/List: To view an HTML page containing the list of teachers, wrapped in links to the specific teacher data
- /Teacher/Show/{id}: To view an HTML page containing the specific teacher data, where id = a number

## Tools
- MySQL: Using a database through an Apache local server
- C#: Used as the primary programming language to facilitate all interactions and connections
- CSHTML: Used to display the content received on a webpage

## Authors
- Austin Caron: Created the code using the in-class example of Authors as a base.
