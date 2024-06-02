using UnityEngine;

public class DeathObject : MonoBehaviour
{
    // Reference to the respawn manager
    private RespawnManager respawnManager;

    private void Start()
    {
        // Find the respawn manager in the scene
        respawnManager = FindObjectOfType<RespawnManager>();
        if (respawnManager == null)
        {
            Debug.LogError("RespawnManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player collided with death object!");

            // Notify the respawn manager
            if (respawnManager != null)
            {
                respawnManager.HandlePlayerDeath(other.gameObject);
            }
        }
    }
}
