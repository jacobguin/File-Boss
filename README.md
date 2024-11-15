# File Boss - A C# File Manager

File Boss is a file management tool built with C# designed to simplify file and folder operations. Developed with various scenarios in mind, File Boss aims to provide an intuitive interface and robust feature set to meet the needs of everyone, from content creators and students to parents and grandparents.

## Features

### File Management
- **Add a File**: Create new files easily with just a few clicks.
- **File Deletion**: Quickly delete files when you no longer need them.
- **Rename File**: Change file names or extensions to better organize your files.
- **File Copying**: Duplicate files to share with others or move to different locations.
- **Undo Action**: Easily revert changes in case of mistakes.

### Folder Management
- **Create a Folder**: Organize files into custom folders for easy access.
- **Zip a Folder**: Compress folders for easier file sharing and storage.
- **Unzip a Folder**: Extract contents from zip files for easy access.
- **Sort**: Arrange folders and files based on name criteria to stay organized.

### View and Access Files
- **Open with Specified Application**: Choose specific applications to open files.
- **Open File Properties**: View and edit metadata and properties for individual files.
- **Change View**: Customize how files and folders are displayed for easier navigation.
- **Scroll Bar**: Smooth scrolling for easy file browsing.
- **Favorites**: Mark frequently accessed files and folders as favorites for quick access.

### Navigation
- **Create Shortcut to Desktop**: Generate desktop shortcuts for faster access.
- **Copy Path of File**: Copy a file path to use in other applications or functions.
- **Change Path**: Effortlessly navigate through directories and subdirectories.
- **Drive Search**: Search across all drives to locate files and folders quickly.
- **Open a New Tab**: Work with multiple tabs to manage different directories at the same time.
- **Homepage**: Start from a central location for easier navigation across File Boss.

### File Sharing
- **Send via Email**: Quickly attach files and send them via email.

### Additional Functionalities
- **Upload File**: Transfer photos and files from external devices, like cameras, to your computer.
- **Bulk Select**: Select multiple files or folders for quick actions, such as deletion or copying.

## Getting Started

### From Release

1. **Download the Latest Release**:
   - Navigate to the [Releases](https://github.com/jacobguin/File-Boss/releases) page on the GitHub repository.

2. **Extract Files**:
   - After downloading the `.zip` file, extract it to a directory of your choice.

3. **Run the Application**:
   - Locate the extracted folder and double-click on `File Boss.exe` to launch the application.

### Building From Source Code

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/jacobguin/File-Boss.git
   ```
2. **Move Directory**:
   ```bash
   cd "File-Boss\File Boss"
   ```
3. **Build Code**:
   ```bash
   dotnet build -c Release
   ```
4. **Move To Build Result**:
   ```bash
   cd bin\Release\net8.0-windows
   ```
5. **Run App**:
   ```bash
   exec "File Boss.exe"
   ```
