using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public float respawnDelay = 2.0f; // Delay before respawn
    public Transform respawnPoint; // The point where the player will respawn

    // Method to handle player death and start the respawn process
    public void HandlePlayerDeath(GameObject player)
    {
        StartCoroutine(RespawnCoroutine(player));
    }

    // Coroutine to respawn the player after a delay
    private IEnumerator RespawnCoroutine(GameObject player)
    {
        // Deactivate the player object
        player.SetActive(false);

        // Wait for the specified delay
        yield return new WaitForSeconds(respawnDelay);

        // Move the player back to the respawn point
        player.transform.position = respawnPoint.position;

        // Re-enable the player object
        player.SetActive(true);

        Debug.Log("Player respawned at " + respawnPoint.position);
    }
}
