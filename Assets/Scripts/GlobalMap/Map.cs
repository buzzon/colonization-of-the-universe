using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private List<GameObject> sectors;
    private BoxCollider collider;

    public Map(GameObject world, GameObject sectorPrefab, int sectorsInLine, float sectorsGap)
    {
        collider = world.transform.gameObject.GetComponent<BoxCollider>();
        Vector3 sectorSize = sectorPrefab.GetComponent<Renderer>().bounds.size;
        Vector3 fullSectorSize = sectorSize + new Vector3(sectorsGap, sectorsGap, sectorsGap);
        sectors = new List<GameObject>(sectorsInLine * sectorsInLine);

        int k = 0;
        for (int j = 0; j < sectorsInLine; j++)
        {
            for (int i = 0; i < sectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * fullSectorSize.x + (fullSectorSize.x / 2) * (j % 2), 0, j * fullSectorSize.z * 3 / 4);
                GameObject sector = UnityEngine.Object.Instantiate(sectorPrefab, position, Quaternion.identity, world.transform);
                sector.GetComponent<SectorManager>().ID = k++;
                sectors.Add(sector);
            }
        }

        collider.size = new Vector3(fullSectorSize.x * sectorsInLine, 3, fullSectorSize.z * 3 / 4 * sectorsInLine);
        collider.center = new Vector3(collider.size.x / 2, 0, collider.size.z / 2);
        world.transform.position = -1 * collider.center ;
    }

    public void Move(Vector3 offset, float deltaTime, float height)
    {
        foreach (GameObject sector in sectors)
        {
            sector.transform.position -= offset * deltaTime * height * 0.6f; 
            Vector3 pos = sector.transform.position;

            if (pos.z < collider.bounds.min.z)
                sector.transform.position = pos + new Vector3(0, 0, collider.bounds.max.z - collider.bounds.min.z);
            else if (pos.z > collider.bounds.max.z)
                sector.transform.position = pos + new Vector3(0, 0, collider.bounds.min.z - collider.bounds.max.z);

            if (pos.x < collider.bounds.min.x)
                sector.transform.position = pos + new Vector3(collider.bounds.max.x - collider.bounds.min.x,0,0);
            else if (pos.x > collider.bounds.max.x)
                sector.transform.position = pos + new Vector3(collider.bounds.min.x - collider.bounds.max.x, 0, 0);
        }
    }
}