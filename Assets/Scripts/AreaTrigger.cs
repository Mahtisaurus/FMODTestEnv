using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    [Tooltip("Name of this area.")]
    public string areaName = "Undefined Area";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player.
        if (other.CompareTag("Player"))
        {
            // Update the current area in the AreaManager.
            if (AreaManager.Instance != null)
            {
                AreaManager.Instance.UpdatePlayerArea(areaName);
            }
        }
    }
}
