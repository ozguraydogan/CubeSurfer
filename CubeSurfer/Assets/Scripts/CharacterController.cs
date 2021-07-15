using System;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [Header("Swap")]
    private Vector3 firsPosition;
    private Vector3 lastPosition;
    private float move;
    [Header("Swerve")]
    public float swerveSpeed;
    [SerializeField] private float amount=2;
    [Header("Move")]
    public float moveSpeed;

    private void Update()
    {
        #region Swap

        if (Input.GetMouseButtonDown(0))
        {
            firsPosition=Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        
        else if (Input.GetMouseButton(0))
        {
            lastPosition= Camera.main.ScreenToViewportPoint(Input.mousePosition);
            move = lastPosition.x - firsPosition.x;
        }
        
        else if (Input.GetMouseButtonUp(0))
        {
            move = 0;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * move;
        swerveAmount = Mathf.Clamp(swerveAmount, -amount, amount);
        
        transform.Translate(swerveAmount, 0, 1 * Time.deltaTime * moveSpeed);
    }
}
