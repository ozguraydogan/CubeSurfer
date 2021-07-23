using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private bool isTrigger;
    public Text scoreText;
    
    public void OnCollisionEnter(Collision other)
    {
        Cube cube = other.gameObject.GetComponent<Cube>();
        if (cube && !isTrigger)
        {
            scoreText.text=(LevelManager.instance.levels.Count + 1).ToString();
            //LevelManager.instance.finish = true;
            isTrigger = true;
            LevelManager.instance.isTrue = true;
        }
    }
}
