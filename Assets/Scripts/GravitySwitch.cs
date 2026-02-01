using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CubeMover mover = other.GetComponent<CubeMover>();

        if (mover != null)
        {
            mover.ToggleGravity();
        }
        gameObject.SetActive(false);
    }
}