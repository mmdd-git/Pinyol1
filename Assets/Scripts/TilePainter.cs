using UnityEngine;

public class TilePainter : MonoBehaviour
{
    public Camera cam;
    public Tilemap3D tilemap;
    public int selectedTile = 0;

    void Update()
    {
        if (Input.GetMouseButton(0)) // pintar
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                tilemap.PlaceTile(hit.point, selectedTile);
            }
        }

        if (Input.GetMouseButton(1)) // esborrar
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                tilemap.RemoveTile(hit.point);
            }
        }
    }
}