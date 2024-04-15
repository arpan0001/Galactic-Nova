using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;

    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public static void StartGame()
    {
        Debug.Log("Game Start");
        if(onStartGame != null)
            onStartGame();
    }

    public static void TakeDamage(float amt)
    {
        Debug.Log("Take Damage: " + amt);
        if(onTakeDamage != null)
            onTakeDamage(amt);
    }

    public static void PlayerDeath()
    {
        Debug.Log("Player Died");
        if(onPlayerDeath != null)
            onPlayerDeath();
    }
}
