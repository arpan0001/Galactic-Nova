using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;
    public static StartGameDelegate onReSpawnPickup;
    public static StartGameDelegate onReSpawnEnemy;


    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void ScorePointsDelegate(int amt);
    public static ScorePointsDelegate onScorePoints;

    public static void StartGame()
    {
        
        if(onStartGame != null)
            onStartGame();
    }

    public static void ReSpawnPickup()
    {
        if(onReSpawnPickup != null)
             onReSpawnPickup();
    }

     public static void ReSpawnEnemy()
    {
        if(onReSpawnEnemy != null)
             onReSpawnEnemy();
    }


    public static void TakeDamage(float amt)
    {
       
        if(onTakeDamage != null)
            onTakeDamage(amt);
    }

    public static void PlayerDeath()
    {
        Debug.Log("Player Died");
        if(onPlayerDeath != null)
            onPlayerDeath();
    }

    public static void ScorePoints(int score)
    {
       
        if(onScorePoints != null)
            onScorePoints(score);
    }
}
