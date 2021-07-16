using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static List<GameObject> levels;
    public static GameManager Manager;

    private void Start()
    {
        Manager = this;
    }

    [SerializeField] private int scor;
    
    public int levelCounter=0;
    
    public void LevelCompleted(int counter)
    {
        Destroy(levels[counter]);
        Instantiate( levels[counter+1] );
    }

    public void LevelRetry(int counter)
    {
        Destroy(levels[counter]);
        Instantiate(levels[counter]);
    }
    
}
