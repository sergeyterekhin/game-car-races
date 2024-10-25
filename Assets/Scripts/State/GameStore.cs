using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;


public enum GameState { Life, Died }

public class GameStore
{
    private static GameStore Instance;    
    public Theme Theme = new();
    public float timeAcceleration = 0f;
    public GameState stateMainPlayer;

    public static GameStore getInstance()
    {
        if (Instance == null)
            Instance = new GameStore();
        return Instance;
    }
    
}
