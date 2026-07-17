# Project: iTransition Fake Data Generator

## Overview
A C# ASP.NET MVC web application that generates fake user data (names, addresses, phone numbers) with configurable parameters. Users can control region, seed, error rate, and export data to CSV.

## Mode
brownfield — existing functional application being redesigned for modern UI/UX.

## Tech Stack
- **Backend:** C# ASP.NET Core MVC (.NET 7+)
- **Frontend:** Razor Views, Bootstrap 5, Bootstrap Icons, vanilla JavaScript
- **Data Generation:** Bogus library for fake data
- **Export:** CSV file generation

## Current State
- Functional MVC application with default Bootstrap light theme
- Single page with form controls (region, seed, errors, limit) and data table
- Infinite scroll for data loading
- CSV export functionality
- No design system — default Bootstrap styling

## Goals
- Complete UI redesign with dark theme and glassmorphism effects
- Material Design-inspired components with custom color palette
- Modern styling with border radius, meaningful icons
- Information architecture principles for optimal UX flows
- Consistent design system applied across all pages
