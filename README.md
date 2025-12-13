# Snake Game

**Snake Game** is a multiplayer snake game application developed using .NET and C#.  It offers users an engaging multiplayer-gaming experience with support for both human players and AI opponents, featuring networked gameplay through a client-server architecture.

## Features

- **Multiplayer Gameplay**: Connect with friends or AI opponents in competitive snake matches through networked play. 

- **Client-Server Architecture**: Robust networking implementation allowing multiple clients to connect to a central game server.

- **AI Integration**: Includes an AI client that can autonomously play the game, providing single-player practice or filling in for additional opponents.

- **Model-View Architecture**: Clean separation of game logic and presentation layer for maintainable and extensible code.

- **User-Friendly Interface**: Navigate through the application with an intuitive GUI designed for seamless gameplay.

## Installation

### Prerequisites

- .NET Framework (version compatible with C#)
- Visual Studio or compatible C# IDE

### Steps

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Celestron1123/snake-game.git
   ```

2. **Navigate to the Project Directory**:
   ```bash
   cd snake-game
   ```

3. **Open the Project in Visual Studio**:
   - Launch Visual Studio. 
   - Open the `Snake.sln` file located in the project directory.

4. **Build and Run**:
   - Configure the project using the appropriate settings for your system.
   - Build the project (may take a few minutes).
   - Run the server application first, then launch client instances.

## Usage

To play the game: 

1. **Start the Server**:  Launch `Server.exe` to host a game session.
2. **Connect Clients**: Run the GUI client to connect as a human player, or use `AIClient.exe` to add AI opponents.
3. **Gameplay**: Control your snake to collect food and grow while avoiding collisions with walls and other snakes.

The game supports multiple simultaneous players, each controlling their own snake in a shared arena. 

## Project Structure

The project is organized into distinct components:

- **GUI**: Contains the client application with user interface components. 
  - `.cs` files: Contain the game logic and networking code.
  - GUI components: Define the user interface layouts and rendering. 
- **ModelTests**: Unit tests for game model validation.
- **Server and Client executables**: Pre-built binaries for quick gameplay. 
- **settings.xml**: Configuration file for game parameters.

## Contributors

- [**Elijah Potter**](https://github.com/Celestron1123) – Developer

## License

This project is available for educational and personal use. 

## Acknowledgments

Thanks to the development community for inspiration and support in creating this multiplayer snake game implementation. 
