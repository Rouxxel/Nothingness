# Nothingness

A Unity 2D space shooter where you pilot a spaceship through endless space, battling enemies and avoiding obstacles while collecting power-ups to survive as long as possible.

This game features dynamic difficulty scaling, a buff/debuff system, and persistent high score tracking. Navigate through space using 8-directional movement controls while managing various power-ups that can either help or hinder your survival.

---

## ✨ Key Features

- 🚀 **8-Directional Movement**: WASD controls with full diagonal movement support for precise spaceship control
- 👾 **Enemy System**: Two distinct enemy ship types with dynamic spawning that increases over time
- ☄️ **Obstacle System**: Asteroids and comets that pose collision hazards
- ⚡ **Buff/Debuff System**: Three power-up types including shield (invincibility), speed boost, and speed reduction
- 💾 **Data Persistence**: Automatic high score saving with game state management
- 🎵 **Audio System**: Background music and comprehensive sound effects for all game events
- ⏸️ **Pause/Resume**: Full game flow control with pause functionality
- 💀 **Game Over Screen**: End game state with survival time display and restart options

---

## 📁 Project Structure

```
Nothingness/
│
├── Assets/
│   ├── Scenes/
│   │   └── level1.unity              # Main game scene
│   │
│   ├── scripts/
│   │   ├── Datapersistence/          # Save/load system
│   │   │   ├── Datapersistencemanager.cs
│   │   │   ├── FileDataHandler.cs
│   │   │   ├── Gamedata.cs
│   │   │   └── Interfacedatapersistence.cs
│   │   │
│   │   ├── Logic manager/            # Game state and flow control
│   │   │   └── logicscript.cs
│   │   │
│   │   ├── Player, Item and enemy manager/  # Core gameplay logic
│   │   │   ├── playerscript.cs
│   │   │   ├── enemyscript.cs
│   │   │   ├── enemy2script.cs
│   │   │   ├── obstaclescript.cs
│   │   │   ├── cometscript.cs
│   │   │   └── bufferscript.cs
│   │   │
│   │   └── Spawners manager/         # Enemy and obstacle spawning
│   │       ├── enemyspawnerscript.cs
│   │       ├── enemy2spawnerscript.cs
│   │       ├── obstaclespawner.cs
│   │       ├── cometspawner.cs
│   │       └── bufferspawner.cs
│   │
│   ├── prefabs/
│   │   ├── animatedprefabs/          # Animated game objects
│   │   └── originalprefabs/          # Base prefabs
│   │
│   ├── sprites/                      # Visual assets and animations
│   │   ├── animation/                # Sprite animations
│   │   ├── Buttons/                  # UI button sprites
│   │   └── [game sprites]            # Player, enemies, obstacles
│   │
│   ├── adiosource/                   # Audio files (music and SFX)
│   │   ├── music/
│   │   ├── player/
│   │   ├── enemy1/
│   │   ├── enemy2/
│   │   ├── obstacle/
│   │   ├── buffer/
│   │   └── Buttons/
│   │
│   └── Font/                         # UI fonts
│
├── ProjectSettings/                  # Unity project configuration
├── Packages/                         # Unity package dependencies
└── README.md                         # This file
```

---

## 🚀 Getting Started

### Prerequisites

- **Unity Version**: 2022.3.22f1 (LTS)
- **Platform**: Windows/Mac/Linux
- **Git**: For cloning the repository

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Nothingness
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Add" and select the Nothingness folder
   - Ensure Unity 2022.3.22f1 is installed (download from Unity Hub if needed)
   - Open the project

3. **Open the main scene**
   - Navigate to `Assets/Scenes/`
   - Double-click `level1.unity` to open the main game scene

### Running the Game

1. With `level1.unity` open in the Unity Editor, click the Play button (▶️) at the top center
2. The game will start immediately in the Game view
3. Use WASD keys to control your spaceship
4. Press ESC to pause/resume the game

---

## 🎮 Controls

| Key | Action |
|-----|--------|
| **W** | Move Up |
| **A** | Move Left |
| **S** | Move Down |
| **D** | Move Right |
| **W + A** | Move Diagonal Up-Left |
| **W + D** | Move Diagonal Up-Right |
| **S + A** | Move Diagonal Down-Left |
| **S + D** | Move Diagonal Down-Right |
| **ESC** | Pause/Resume Game |

---

## 🎯 Gameplay

### Objective
Survive as long as possible by avoiding obstacles and enemy ships. Your survival time is tracked and automatically saved as your high score. The longer you survive, the more challenging the game becomes.

### Enemies
- **Enemy Ship Type 1**: Standard enemy vessel that moves across the screen
- **Enemy Ship Type 2**: Alternative enemy type with different movement patterns
- Enemies spawn more frequently as your survival time increases
- Collision with any enemy ship results in game over

### Obstacles
- **Asteroids**: Rotating space debris that must be avoided
- **Comets**: Fast-moving obstacles that cross the screen
- Collision with obstacles results in game over

### Power-Ups
The game features a random buff/debuff system with three types:

- **🛡️ Shield (Buff Type 0)**: Provides temporary invincibility against obstacles for 10 seconds
- **⚡ Speed Boost (Buff Type 1)**: Doubles movement speed AND provides obstacle invincibility for 10 seconds
- **🐌 Speed Reduction (Buff Type 2)**: Reduces movement speed by half for 10 seconds (debuff)

Power-ups are randomly assigned when collected, adding an element of risk and reward to the gameplay.

### Progression
The game features dynamic difficulty scaling:
- Enemy and obstacle spawn rates increase as your survival time grows
- The spawn rate adjusts based on your total saved survival time
- When you restart after a game over, the difficulty resumes at the appropriate level for your best time
- This ensures consistent challenge progression across multiple play sessions

---

## 🔧 Technical Details

### Technology Stack
- **Engine**: Unity 2022.3.22f1 (LTS)
- **Language**: C#
- **Platform**: 2D Game
- **Rendering**: Unity 2D Renderer
- **Physics**: Unity 2D Physics System

### Architecture
The project follows a component-based architecture with clear separation of concerns:

- **Logic Manager** (`logicscript.cs`): Handles game state, pause/resume functionality, game over logic, UI management, and audio control
- **Player Manager** (`playerscript.cs`): Controls player movement (8-directional), buff/debuff effects, collision detection, and audio feedback
- **Spawner Manager**: Multiple spawner scripts manage dynamic spawning of enemies, obstacles, and power-ups with time-based difficulty scaling
- **Data Persistence** (`Datapersistencemanager.cs`): JSON-based save system for high scores and game state using Unity's persistent data path

### Data Persistence
- High scores (survival time) are automatically saved to a JSON file
- Game state is persisted to maintain difficulty progression across sessions
- Save data location: Unity's `Application.persistentDataPath`
- The system uses an interface pattern (`Interfacedatapersistence`) for flexible data management
- Data is saved automatically when the application quits

### Key Design Patterns
- **Singleton Pattern**: Used in `Datapersistencemanager` for global access
- **Interface Pattern**: `Interfacedatapersistence` allows multiple scripts to participate in save/load operations
- **Component Pattern**: Unity's component-based architecture for modular game object behavior

---

## 📝 Notes

- The game automatically saves your highest survival time
- Difficulty scales based on total survival time, not just the current session
- All sprites, animations, and audio files are included in the project
- The buff/debuff system randomly selects effects, making each power-up collection unpredictable
- Music and sound effects can be toggled on/off during gameplay

---

## 👨‍💻 Development

This project was created as an exploration of Unity 2D game development, focusing on:
- **Player Movement Systems**: Implementing smooth 8-directional movement with diagonal support
- **Dynamic Spawning Systems**: Creating difficulty scaling through time-based spawn rate adjustments
- **Buff/Debuff Mechanics**: Designing a simple but effective power-up system with both positive and negative effects
- **Data Persistence**: Implementing save/load functionality in Unity using JSON serialization
- **Audio Integration**: Managing multiple audio sources for music and sound effects
- **Game State Management**: Handling pause/resume, game over, and restart functionality

---

**Unity Version**: 2022.3.22f1 (887be4894c44)
