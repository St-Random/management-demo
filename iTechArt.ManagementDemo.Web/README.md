
# Welcome

This is demo application for basic 3-Layer architecture that uses **ASP.NET Core 2.2 MVC**, **EF Core 2.2**, **Automapper**, and **Fluent Validation**. Frontend is quite basic and uses server rendering, **jQuery**, [Tabulator](http://tabulator.info/) plugin for tables, and **EasyAutocomplete** pluging for autocompletes. There is no package manager for js libs and VS default bundler is used for bundling and minification (see _bundleconfig.json_). Beware cause it doesn't support arrow functions.

If you run application for the first time, you can create database & seed it with test data by changing **ApplyMigrationsOnStartup** setting to _true_. By default application is configured to use local **SQL Express** installation. You can also enable SQL queries Interception/Logging to Debug console by setting **LogSqlQueries** parameter to _true_.

Tables support search (case-insensitive contains on string properties), multiple sort and pagination.

*   You can select columns for a search by pressing button to the right of the _Search_ button.
*   You can sort by mutiple columns by clicking column header with **Ctrl+Shift** keys pressed.
*   You can also navigate to corresponding details pages by clicking table rows (they will open in new tab/window).

