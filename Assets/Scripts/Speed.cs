using UnityEngine;

public class Speed : MonoBehaviour
{
    public float duration = 5f;
    public float speedMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        CubeMover player = other.GetComponent<CubeMover>();

        if (player != null)
        {
            player.StartSpeedBoost(duration, speedMultiplier);
           // Destroy(gameObject); // opcional
        }
    }
}