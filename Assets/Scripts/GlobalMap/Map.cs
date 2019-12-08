using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Transform> Sectors;

    public Map(GameObject World, GameObject SectorPrefab, int SectorsInLine, float SectorsGap)
    {
        BoxCollider collider = World.transform.gameObject.GetComponent<BoxCollider>();
        Vector3 sectorSize = SectorPrefab.GetComponent<Renderer>().bounds.size;
        Vector3 fullSectorSize = sectorSize + new Vector3(SectorsGap, SectorsGap, SectorsGap);
        Sectors = new List<Transform>(SectorsInLine * SectorsInLine);

        int k = 0;
        for (int j = 0; j < SectorsInLine; j++)
        {
            for (int i = 0; i < SectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * fullSectorSize.x + (fullSectorSize.x / 2) * (j % 2), 0, j * fullSectorSize.z * 3 / 4);
                GameObject sector = Instantiate(SectorPrefab, position, Quaternion.identity, World.transform);
                sector.GetComponent<SectorManager>().ID = k++;
                Sectors.Add(sector.transform);
            }
        }

        collider.size = new Vector3(fullSectorSize.x * SectorsInLine, 3, fullSectorSize.z * 3 / 4 * SectorsInLine);
        collider.center = new Vector3(collider.size.x / 2, 0, collider.size.z / 2);
        World.transform.position = -1 * collider.center ;
    }

    public void Move(Vector3 offset)
    {

    }
}
