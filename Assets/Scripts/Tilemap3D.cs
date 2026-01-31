using UnityEngine;

public class Tilemap3D : MonoBehaviour
{
    public Grid grid;
    public Transform tileParent;
    public GameObject[] tilePrefabs;

    // Col·loca un tile a la cel·la més propera
    public void PlaceTile(Vector3 worldPos, int tileIndex)
    {
        Vector3Int cell = grid.WorldToCell(worldPos);
        Vector3 tilePos = grid.CellToWorld(cell);

        Instantiate(tilePrefabs[tileIndex], tilePos, Quaternion.identity, tileParent);
    }

    // Elimina un tile de la cel·la
    public void RemoveTile(Vector3 worldPos)
    {
        Vector3Int cell = grid.WorldToCell(worldPos);
        Vector3 cellCenter = grid.GetCellCenterWorld(cell);

        Collider[] hits = Physics.OverlapSphere(cellCenter, 0.1f);

        foreach (var hit in hits)
        {
            Destroy(hit.gameObject);
        }
    }
}