using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform playerCamera;

    void LateUpdate()
    {

        Vector3 lookDirection = playerCamera.position - transform.position;
        lookDirection.y = 0f; // Evita inclinarse hacia arriba/abajo
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-lookDirection);
            transform.rotation = targetRotation;
        }
    }
}
