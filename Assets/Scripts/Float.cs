using UnityEngine;

public class Float : MonoBehaviour
{
    public float floatDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        CubeMover player = other.GetComponent<CubeMover>();

        if (player != null)
        {
            player.StartFloating(floatDuration);
           // Destroy(gameObject); // opcional
        }

        //gameObject.SetActive(false);
    }
}