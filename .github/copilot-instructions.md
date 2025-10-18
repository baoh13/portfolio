# AI Coding Agent Instructions for Portfolio Codebase

Welcome to the Portfolio codebase! This document provides essential guidance for AI coding agents to be productive in this repository. Follow these instructions to understand the architecture, workflows, and conventions.

## Big Picture Architecture

This repository contains a Blazor WebAssembly application for building a personal portfolio site. The solution is structured as follows:

- **BlazorApp**: The main frontend application built with Blazor WebAssembly. Key directories include:
  - `Components/`: Contains reusable UI components like `About.razor`, `Portfolio.razor`, and `Footer.razor`.
  - `Models/`: Defines data models such as `Project`, `AboutMe`, and `SiteProperties`.
  - `Services/`: Includes services like `HeroImageService` for managing data.
  - `wwwroot/`: Static assets including CSS, images, and sample data in JSON format.
- **MyPortfolio.AppHost**: Hosts the application and manages configuration.
- **MyPortfolio.ServiceDefaults**: Provides shared extensions and defaults for the application.

### Data Flow
- JSON files in `wwwroot/sample-data/` (e.g., `aboutme.json`, `projects.json`) provide data for components.
- Services like `HeroImageService` handle data retrieval and processing.
- Components consume data via dependency injection and render it dynamically.

### Why This Structure?
- Separation of concerns: Components, models, and services are modular and reusable.
- Static data in JSON format simplifies customization without requiring backend changes.

## CSS Framework and Styling Structure

### CSS Framework
- **Bootstrap**: The project uses Bootstrap as its primary CSS framework. Referenced in the index.html file via:
  ```html
  <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
  ```

### Styling Structure
- **Global Styles**: Global styles are defined in `wwwroot/css/app.css`
- **Component-Specific Styles**: Each component can have its own scoped CSS file using the `.razor.css` naming convention (e.g., `Header.razor.css`)
- **Blazor Scoped Styles**: Component-specific styles are bundled into `BlazorApp.styles.css`, which is automatically referenced in index.html
- **Style Hierarchy**:
  1. Bootstrap provides the base styling framework
  2. Global styles in app.css customize and extend Bootstrap
  3. Component-specific styles apply to individual components

### CSS References
- **Bootstrap**: `wwwroot/css/bootstrap/bootstrap.min.css`
- **Global Application Styles**: `wwwroot/css/app.css`
- **Compiled Component Styles**: `BlazorApp.styles.css`
- **Favicon**: `favicon.png`

## Developer Workflows

### Building the Project
Use the provided VS Code tasks:
- **Build**: `dotnet build src/BlazorApp/BlazorApp.csproj`
- **Watch**: `dotnet watch run --project src/BlazorApp/BlazorApp.csproj`

### Running the Application
- Use the `watch` task to start the development server.
- Open the application in your browser at the specified port (default: 4280).

### Deploying the Application
- Deploy to Azure Static Web Apps or GitHub Pages using the provided configurations.

### Testing
- Ensure all components render correctly with the provided sample data.
- Validate JSON data integrity in `wwwroot/sample-data/`.

## Project-Specific Conventions

### Component Design
- Components are self-contained and follow the Blazor naming convention (`[Name].razor`).
- CSS files for components are colocated (e.g., `Header.razor.css`).

### Data Models
- Models represent the structure of JSON data files.
- Keep models in sync with their corresponding JSON files.

### Static Assets
- Store images in `wwwroot/images/`.
- Use meaningful filenames and update references in JSON files.

## Integration Points

### External Dependencies
- **Blazor WebAssembly**: Framework for building the frontend.
- **Azure Static Web Apps CLI**: Used for local development and deployment.

### Cross-Component Communication
- Use services for shared state and data retrieval.
- Pass data to components via parameters.

## Key Files and Directories
- `src/BlazorApp/Components/`: UI components.
- `src/BlazorApp/wwwroot/sample-data/`: JSON files for site content.
- `src/BlazorApp/wwwroot/css/`: Stylesheets.
- `src/BlazorApp/Services/`: Data services.

## Examples

### Adding a New Project
1. Update `wwwroot/sample-data/projects.json`:
   ```json
   {
     "title": "New Project",
     "description": "Description of the new project.",
     "url": "https://example.com"
   }
   ```
2. Verify the `Portfolio` component renders the new project.

### Customizing the Header
1. Edit `Components/Header.razor` to update the markup.
2. Modify `Header.razor.css` for styling changes.

### Adding Custom Styles
1. For global styles, add them to `wwwroot/css/app.css`
2. For component-specific styles, add or modify the component's `.razor.css` file
3. To override Bootstrap styles, use more specific CSS selectors in your custom CSS files

---

For further details, refer to the [README.md](../README.md).