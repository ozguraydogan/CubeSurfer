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
            LevelManager.instance.LevelComplate();
            Camera.main.transform.Translate(0,-0.2f,0.2f);
            Camera.main.transform.Rotate(-1,0,0);
        }
    }
}
