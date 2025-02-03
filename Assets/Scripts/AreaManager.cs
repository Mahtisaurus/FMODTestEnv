using UnityEngine;

public class AreaManager : MonoBehaviour
{
    // Static instance to allow global access.
    public static AreaManager Instance;

    [Tooltip("The name of the current area where the player is located.")]
    public string currentArea;

    private void Awake()
    {
        // Ensure that there is only one instance of AreaManager in the scene.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Updates the current area when the player enters a new area trigger.
    /// </summary>
    /// <param name="areaName">The name of the new area.</param>
    public void UpdatePlayerArea(string areaName)
    {
        currentArea = areaName;
        Debug.Log("Player entered area: " + currentArea);
    }
}
