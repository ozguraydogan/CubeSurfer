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
    
    [Header("UI")]
    [SerializeField] private GameObject endGame;

    [SerializeField] private GameObject gameOver;
    private Text scoreText;
    public int activeLevel;
    private void Start()
    {
        instance = this;
        activeLevel = 0;
    }

    private void Update()
    {
        Debug.Log(levels.Count);
    }

    private int Scor()
    {
        scor = levels.Count - 1;
        return scor;
    }

    private void LevelComplate()
    {
        
        CharacterController _characterController = GetComponent<CharacterController>(); 
        scoreText.text="Scor: " + scor;
        _characterController.swerveSpeed = 0;
        _characterController.moveSpeed = 0;
        endGame.SetActive(true);
        
    }

    private void GameOver()
    {
        CharacterController _characterController = GetComponent<CharacterController>();
        gameOver.SetActive(true);
        _characterController.swerveSpeed = 0;       
        _characterController.moveSpeed = 0;
    }

    void NextLevelButton()
    {
        GameManager.Manager.LevelCompleted(activeLevel);
        Destroy(this.gameObject);
    }

    void RetryButton()
    {
        GameManager.Manager.LevelRetry(activeLevel);
    }
}
