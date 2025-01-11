# Guessing Game 2.0

Enhanced C# number guessing game with GUI interface and expanded features.

## Features
- Windows Forms GUI
- Multiple game modes
- Player profiles
- Achievement system
- Global leaderboard

## Implementation
```csharp
public class EnhancedGuessingGame
{
    private readonly Random _random = new();
    private readonly GameMode _gameMode;
    private readonly ILeaderboard _leaderboard;
    
    public GameResult PlayRound(int guess, Player player)
    {
        var result = ValidateGuess(guess);
        UpdateStats(player, result);
        CheckAchievements(player);
        return result;
    }
    
    private void CheckAchievements(Player player)
    {
        // Achievement logic
    }
}
```

## Structure
```
GuessingGame2.0/
├── Program.cs
├── Forms/
│   ├── MainForm.cs
│   └── GameForm.cs
├── Logic/
│   └── GameEngine.cs
├── Models/
│   ├── Player.cs
│   └── Achievement.cs
└── Data/
    └── Leaderboard.cs
```

## Enhancements from v1.0
- Graphical user interface
- Player profiles and statistics
- Achievement system
- Global high scores
- Multiple game modes

## Installation
1. Clone repository
2. Open in Visual Studio
3. Build and run

## License
MIT License
