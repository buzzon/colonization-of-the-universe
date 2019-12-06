using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject SectorPrefab;
    public int SectorsInLine;
    public float Offset;

    void Start()
    {
        BoxCollider collider = transform.gameObject.GetComponent<BoxCollider>();
        Vector3 sectorSize = SectorPrefab.GetComponent<Renderer>().bounds.size;
        Vector3 fullSectorSize = new Vector3(sectorSize.x + Offset, sectorSize.y + Offset, sectorSize.z + Offset);

        Create(fullSectorSize);
        SetBound(collider, fullSectorSize);
    }

    private void Create(Vector3 sectorSize)
    {
        int k = 0;
        for (int j = 0; j < SectorsInLine; j++)
        {
            for (int i = 0; i < SectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * sectorSize.x + (sectorSize.x / 2) * (j % 2), 0, j * sectorSize.z * 3 / 4);
                GameObject sector = Instantiate(SectorPrefab, position, Quaternion.identity, transform);
                sector.GetComponent<SectorManager>().ID = k;
                k++;
            }
        }
    }

    private void SetBound(BoxCollider collider, Vector3 sectorSize)
    {
        collider.size = new Vector3(sectorSize.x * SectorsInLine, 3, sectorSize.z * 3 / 4 * SectorsInLine);
        collider.center = new Vector3(collider.size.x / 2, 0, collider.size.z / 2);
    }
}
