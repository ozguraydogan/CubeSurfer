using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collect : MonoBehaviour
{
    
    [Header("Cube Information")]
    [SerializeField] private Transform insPosition; // Küpün oluşacağı pozisyon
    [SerializeField] private GameObject insCube; // Instantiate edilecek obje.
    [SerializeField] private GameObject cubes; // küplerin parent.
    
    private bool isTrigger; //bir kere çalışması için kotrol

    
    private void OnCollisionEnter(Collision other)
    {
        Cube cube = other.gameObject.GetComponent<Cube>();
        if (cube && !isTrigger)
        {
            CubeAdd();
            Destroy(this.gameObject);
            isTrigger = false;
        }

    }

    public void CubeAdd()
    {
        cubes.transform.Translate(0, 1, 0);
        GameObject ins = Instantiate(insCube, insPosition.position, transform.rotation);
        ins.transform.parent = cubes.transform;
        ins.gameObject.name = (LevelManager.instance.levels.Count + 1).ToString();
        LevelManager.instance.levels.Add(ins);
        Camera.main.transform.Translate(0,0.5f,-0.5f);
        Camera.main.transform.Rotate(1,0,0);
    }
}
