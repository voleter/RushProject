using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzle;
    public float fireRate = 0.5f;

    private float nextFireTime;

    void Update()
    {
        // Check if the fire button is pressed and enough time has passed since the last shot
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1 / fireRate;  // Calculate the next allowed firing time
        }
    }

    void Shoot()
    {
        // Instantiate a projectile at the muzzle position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);

        // Access the rigidbody of the projectile and give it a forward velocity
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            // Adjust the forward velocity according to your requirements
            projectileRigidbody.velocity = muzzle.forward * 20f;  // Example velocity
        }

        // Destroy the projectile after a certain time (e.g., 2 seconds)
        Destroy(newProjectile, 2f);
    }
}
