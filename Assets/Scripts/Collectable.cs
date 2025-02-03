using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Spin Settings")]
    [Tooltip("If true, the collectable will spin continuously.")]
    public bool shouldSpin = true;
    public float spinSpeed = 90f;

    void Update()
    {
        // If enabled, spin the collectable around the Y-axis.
        if (shouldSpin)
        {
            transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        }
    }

    // When the player enters the trigger, destroy this collectable.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, you can add particle effects or sounds here.
            Destroy(gameObject);
        }
    }
}
