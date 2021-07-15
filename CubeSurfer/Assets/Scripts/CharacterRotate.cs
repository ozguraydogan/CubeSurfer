using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    public Transform character;
    private bool isTrigger=false; //bir kere çalışması için kotrol
    private void OnCollisionEnter(Collision other)
    {
        Cube cube = other.gameObject.GetComponent<Cube>();
        if (cube && !isTrigger)
        {
            Debug.Log("Rotate ");
            character.transform.Rotate(0,90,0);
            isTrigger = false;
        }
    }
}
