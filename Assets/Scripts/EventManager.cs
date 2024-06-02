using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action MainPlayerDied;

    public static void OnPlayerDie()
    {
        GameStore.getInstance().stateMainPlayer = GameState.Died;
        MainPlayerDied?.Invoke();
    }
}
