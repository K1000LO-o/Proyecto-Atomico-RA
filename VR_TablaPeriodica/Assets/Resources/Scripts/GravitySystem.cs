using UnityEngine;

public class GravitySystem : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 velocity;
    public float gravity = -9.81f;

    void Update() {
        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = -2f; // pequeñísimo empuje para mantener contacto
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
