using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class GameStore
{
    private static GameStore Instance;    
    public Theme Theme = new();
    public float timeAcceleration = 0f;
    
    public static GameStore getInstance()
    {
        if (Instance == null)
            Instance = new GameStore();
        return Instance;
    }
    
}
