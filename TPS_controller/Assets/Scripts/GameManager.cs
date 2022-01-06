using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action onGameStarted;
    public bool hasStarted;
    private void Awake()
    {
        instance = this;
    }
    
    public void StartGame()
    {
        hasStarted = true;
        onGameStarted?.Invoke();
    }
}
