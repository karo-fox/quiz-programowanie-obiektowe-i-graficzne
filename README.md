# quiz-programowanie-obiektowe-i-graficzne
A source code for the quiz app, created as the university assignment

# Running the App
## Importing the database schema
You have to import the database included in `database.sql` file. You can do this running this command in the console:

`mysql -u <username> -p quizDB < .\path\to\database.sql`

## Installing dependencies
In Visual Studio, search for Nuget Package Manager. Then, find MySql.Data package and add it to the project.

## Configuration
In VisualStudio, navigate to the project's Properties. Choose Settings and create or add new settings to `App.config`.
Required settings:


| Name     | Type      | Scope         | Value                       |
| -------- | --------- | ------------- | --------------------------- |
| server   | string    | Application   | `<server, eg: localhost>`   |
| database | string    | Application   | quizDB                      |
| user     | string    | Application   | `<MySQL user>`              |
| password | string    | Application   | `<MySQL password>`          |
| port     | uint      | Application   | `<port, eg: 3306>`          |
