# Crave for Ecdysis

A Unity skin collection and customization system built with the MVP (Model-View-Presenter) architectural pattern. This project allows users to browse, unlock, and select skins organized in collections.

## Overview

"Crave for Ecdysis" is a skin management system where users can:
- Browse through multiple skin collections organized in pages
- View skin details and previews
- Unlock random skins from the current collection
- Select and apply skins
- Persist skin states and selections across sessions

## Architecture

The project follows the **MVP (Model-View-Presenter)** pattern for clean separation of concerns:

- **Model**: Handles data logic, persistence, and business rules (`MainViewModel`)
- **View**: Manages UI presentation and user interactions (`MainView`)
- **Presenter**: Coordinates between Model and View (`MainViewPresenter`)

### Core Components

- **MVP Framework** (`Assets/Scripts/Core/MVP/`): Reusable MVP interfaces and base presenter class
- **Save System** (`Assets/Scripts/Core/SaveSystem.cs`): JSON-based persistence using Newtonsoft.Json
- **Skin Data** (`Assets/Scripts/SkinData/`): Data models and ScriptableObject definitions
- **Views** (`Assets/Scripts/Views/`): UI implementations following MVP pattern
- **Components** (`Assets/Scripts/Components/`): Reusable UI controllers

## Features

- 📚 **Multi-Collection Catalog**: Browse skins organized in collections with pagination
- 🔓 **Unlock System**: Randomly unlock locked skins from the current collection
- ✅ **Selection System**: Select and highlight skins with visual feedback
- 💾 **Data Persistence**: Save and load skin states (locked/unlocked, selected) using JSON
- 🎨 **ScriptableObject-Based**: Configure skins and collections via Unity's ScriptableObject system
- 🔄 **Dependency Injection**: Proper dependency management for serialized data

## Project Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── MVP/              # MVP pattern interfaces and base classes
│   │   │   ├── IModel.cs
│   │   │   ├── IView.cs
│   │   │   ├── IData.cs
│   │   │   └── Presenter.cs
│   │   └── SaveSystem.cs     # JSON save/load system
│   ├── SkinData/             # Skin data models and ScriptableObjects
│   │   ├── Skin.cs
│   │   ├── SkinSO.cs
│   │   ├── SkinCollection.cs
│   │   └── SkinCollectionSO.cs
│   ├── Views/
│   │   └── MainView/         # Main view MVP implementation
│   │       ├── MainView.cs
│   │       ├── MainViewModel.cs
│   │       ├── MainViewPresenter.cs
│   │       └── MainViewData.cs
│   ├── Components/           # UI controllers
│   │   ├── CatalogController.cs    # Pagination system
│   │   ├── SkinViewController.cs   # Skin grid management
│   │   └── SkinOverview.cs         # Skin preview/details
│   └── EntryPoint.cs         # Application entry point
├── Resources/
│   └── SkinData/             # Skin ScriptableObject assets
│       └── Collections/      # Skin collection assets
└── Scenes/
    └── Main.unity            # Main scene
```

## Setup

### Prerequisites

- Unity 6.0.2 or other compatible version

### Installation

1. Open the project with Unity 6.0.2 or later

2. Open the main scene:
   - Navigate to `Assets/Scenes/Main.unity`

3. Play :D

## Usage

### Creating Skin Data

1. **Create a Skin ScriptableObject**:
   - Right-click in Project window → `Create → Data → SkinData`
   - Configure the skin's image sprite and default state (locked/unlocked)

2. **Create a Skin Collection**:
   - Right-click in Project window → `Create → Data → SkinDataCollection`
   - Add multiple `SkinSO` references to the collection
   - Save the collection in `Assets/Resources/SkinData/Collections/`

3. **Load Collections**:
   - The system automatically loads all `SkinCollectionSO` assets from `Resources/SkinData/Collections/`
   - Collections are loaded in alphabetical order

### Runtime Behavior

- **Pagination**: Use Next/Previous buttons to navigate between collections
- **Unlock Random Skin**: Click the unlock button to randomly unlock a locked skin from the current collection
- **Select Skin**: Click on any unlocked skin to select it and view details
- **Auto-Save**: Skin states are automatically saved when the view closes

### Save Data Location

Save data is stored in:
- **Windows**: `%USERPROFILE%\AppData\LocalLow\<CompanyName>\<ProductName>\SkinData.json`
- **macOS**: `~/Library/Application Support/<CompanyName>/<ProductName>/SkinData.json`
- **Linux**: `~/.config/unity3d/<CompanyName>/<ProductName>/SkinData.json`

## Technical Details

### Data Flow

1. **Initialization**: `EntryPoint` creates `MainViewPresenter` which initializes `MainViewModel`
2. **Data Loading**: `MainViewModel` loads skin collections from Resources and attempts to load saved data
3. **View Update**: Model notifies View via `OnDataChanged` event
4. **User Interaction**: View components handle user input and update the data model
5. **Persistence**: Data is saved to JSON when the view closes

### Key Design Patterns

- **MVP Pattern**: Separation of data logic, presentation, and coordination
- **Observer Pattern**: Event-driven communication between components
- **Dependency Injection**: ScriptableObject dependencies injected after deserialization
- **Factory Pattern**: (TODO: mentioned in `SkinViewController.PopulateElements`)

## Dependencies

- **Newtonsoft.Json**: For JSON serialization/deserialization
- **Unity TextMeshPro**: For text rendering (included in project)

## Development Notes

- The project follows best practices with proper separation of concerns
- Code is organized into logical namespaces
- Components are designed to be reusable and extensible
- TODO: Factory pattern implementation for element creation (see `SkinViewController.cs`)


