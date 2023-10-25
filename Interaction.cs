using UnityEngine;

public class PushOnCollision : MonoBehaviour
{
    public float pushForce = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a Rigidbody
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate the direction from this object to the colliding object
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            // Apply a force to push the colliding object away
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }
}
