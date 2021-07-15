using UnityEngine;

public class Obstacle : MonoBehaviour
{
    bool isTrigger;
    
    public void OnCollisionEnter(Collision other)
    {
        Cube cube = other.gameObject.GetComponent<Cube>();
        if (cube && !isTrigger)
        {
            cube.transform.parent = null;
            isTrigger = true;
            LevelManager.instance.levels.Remove(cube.gameObject);
            Camera.main.transform.Translate(0,-0.5f,0.5f);
            Camera.main.transform.Rotate(-1,0,0);
        }
    }
}
