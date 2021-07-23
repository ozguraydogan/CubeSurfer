using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    public Transform character;
    private bool isTrigger=false; //bir kere çalışması için kotrol
    private float rotationAmount;
    public float counter ;
    private bool isTrue=false;

    private CharacterController _characterController;
    private void Start()
    {
        rotationAmount = counter;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (rotationAmount <counter )
        {
            character.transform.localRotation= Quaternion.Euler(0,rotationAmount,0);
        }
        if (isTrue)
        {
            rotationAmount +=Time.deltaTime*360;    
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Cube cube = other.gameObject.GetComponent<Cube>();
        if (cube && !isTrigger)
        {
            Debug.Log("Rotate ");
           // character.transform.localRotation=Quaternion.Euler(0,90,0);
            rotationAmount = 0;
            counter -=character.transform.rotation.y;
            isTrue = true;
            isTrigger = true;
        }
    }
}
