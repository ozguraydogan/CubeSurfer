using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<GameObject> levels;
    private int scor;
    public CharacterController _characterController;
    
    [Header("UI")]
    [SerializeField] private GameObject endGame;

    [SerializeField] private GameObject gameOver;
    
    public int activeLevel;
    [Header("Start Cube")]
    [SerializeField] private GameObject cube;

    [Header("End Game or Game Over")]
    public bool isTrue;
    private void Start()
    {
        _characterController.enabled = true;
        levels.Add(cube);
        instance = this;
        activeLevel = 0;
    }

    private void Update()
    {
       // LevelComplate();
       // Debug.Log(levels.Count);
    }

    private int Scor()
    {
        scor = levels.Count - 1;
        return scor;
    }

    public void LevelComplate()
    { 
        if (levels.Count  <= 0 && isTrue)
        {
            _characterController.enabled = false;
            endGame.SetActive(true);
        }
        
        else if(levels.Count  <=0 && !isTrue)
        {
            _characterController.enabled = false;
            gameOver.SetActive(true);
        }
    }
    

    public void NextLevelButton()
    {
        GameManager.Manager.LevelCompleted(activeLevel);
        Destroy(this.gameObject);
    }

    public void RetryButton()
    {
        GameManager.Manager.LevelRetry(activeLevel);
    }
}