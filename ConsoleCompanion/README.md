# The Star wars Companion

## The Console Companion

The console companion is developed in dotnet core 2.
The Program class Start the application and calls the method that manages the menu or the user

In the Menu, the user can call the functions to:
1 - Show all ships
2 - Download all ships to a csv File.
3 - Check stops for a desired distence
4 - Check stops for a desired distance - all ships
9 - Check and configure the app settings
ESC - Exit the application

## The functions

### 1 - Show all Ships

When the user select to show all ships, the application will connect to the api and list all ships to the user.

### 2 - Download all ship

This options connect to the api, get all ships and then, prompt user to inform a folder to save the file.

### 3 - Check stops for a desired distance

This will prompt user with two questions, one is to get the desired distance (for eg: 1000000) and the ship id (eg 10).

### 4 - Check stops for a desired distance - all ships

This will prompt user with two questions, one is to get the desired distance (for eg: 1000000) and show all ships with how many stops it needs to cover the distance.
Ships with an unkown MGLT, will be displayed as "unkown"

## Architeture

## Why the custom api

When designing this "companion" my thoughts were: I need to standardize my income data if I want to use this in more than one application.

With this in mind, I decided to create an Api (also in dotnet core) to fill my needs.

## Execting the Console Companion

To run this companion, first, we need to run the StarShipApi (attached to this project).
Open the cmd and then:
cd <folder to this console>.
dotnet run
