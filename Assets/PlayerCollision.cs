
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;
    public float impactForceToLose = 30;
    private void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Obstacle") {
            Debug.Log(collisionInfo.relativeVelocity.magnitude);
        }
        if (collisionInfo.collider.tag == "Obstacle" && collisionInfo.relativeVelocity.magnitude >= impactForceToLose ) {
            Debug.Log("You lose!");
            rb.AddExplosionForce(15, collisionInfo.transform.position, 10, 1, ForceMode.Impulse);
            Debug.Log(collisionInfo.impulse);
            movement.enabled = false;
        }
    }
}
