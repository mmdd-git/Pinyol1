using UnityEngine;

public class InvisibilityPickup : MonoBehaviour
{
    public float invisDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        CubeMover player = other.GetComponent<CubeMover>();

        if (player != null)
        {
            player.MakeInvisible(invisDuration);
           // Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }
}