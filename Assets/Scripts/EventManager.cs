using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action GameOver;
    public static event Action RestartGame;


    public static void onGameOver()
    {
        GameStore.getInstance().stateMainPlayer = GameState.Died;
        GameOver?.Invoke();
    }

    public static void onRestartGame()
    {
        GameStore.getInstance().timeAcceleration = 0f;
        GameStore.getInstance().stateMainPlayer = GameState.Life;
        GameManager.ChangeTheme();
        RestartGame?.Invoke();
    }
}
