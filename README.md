# BadPhrasePlugin for ReSharper
[![ReSharper](https://img.shields.io/jetbrains/plugin/v/RESHARPER_PLUGIN_ID.svg?label=ReSharper&colorB=0A7BBB&style=for-the-badge&logo=resharper)](https://plugins.jetbrains.com/plugin/RESHARPER_PLUGIN_ID)

The Bad Phrase Plugin is a ReSharper extension designed to improve code quality by detecting and suggesting replacements for discouraged or suboptimal phrases found within code comments. This plugin supports C# projects within JetBrains ReSharper environments.

## Features

- **Phrase Detection**: Automatically highlights discouraged phrases in code comments.
- **Quick Fixes**: Offers quick-fix suggestions to easily replace bad phrases with recommended alternatives.
- **Customizable Phrase List**: Users can define their own list of discouraged phrases and corresponding replacements.
- **Dynamic Updates**: Monitors specified directories for updates to the phrase list, ensuring the plugin is always using the most current data.

## Installation

To install the Bad Phrase Plugin, follow these steps:

1. Download the latest release from the [GitHub Release page](https://github.com/bmajosek/BadPhrasePlugin).
2. In ReSharper, go to **Extensions** -> **Manage Extensions**.
3. Click on **Install from Disk** and select the downloaded `.nupkg` file.
4. Restart ReSharper to activate the plugin.

## Usage

Once installed, the plugin will automatically start scanning open files in your project. Detected bad phrases will be highlighted, and a quick fix will be suggested:

1. **View Suggestions**: Hover over the highlighted phrase to see the suggested replacement.
2. **Apply Quick Fix**: Click on the light bulb icon or press `Alt+Enter` to open the action menu, then select the suggested replacement to apply it instantly.

## Configuration

### Customizing Phrases

To add or modify the list of phrases, follow these steps:

1. Navigate to the configured directory for phrase definitions (see Configuration Settings below).
2. Edit existing `.txt` files or add new ones, following the format: `Bad Phrase ==> Good Replacement`.
3. Save changes. The plugin will automatically update to reflect the changes.

### Configuration Settings

Modify plugin settings by navigating to **ReSharper** -> **Options** -> **Bad Phrase Plugin Settings**:

- **Directory Path**: Set the path to the directory where your custom phrase definition files are stored.
