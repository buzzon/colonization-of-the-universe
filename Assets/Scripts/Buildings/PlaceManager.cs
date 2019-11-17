using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public GameObject TerrainForBuildings;
    private BuildingManager buildingView;
    private GameObject building;

    public void Set(GameObject _building)
    {
        building = _building;
        buildingView = building.GetComponent<BuildingManager>();
        StartCoroutine(BuildingPositionUpdate());
    }

    IEnumerator BuildingPositionUpdate()
    {
        while (!buildingView.IsBuilt)
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject == TerrainForBuildings)
                {
                    Vector3 offset = new Vector3(0, building.GetComponent<Renderer>().bounds.size.y / 2, 0);
                    building.transform.position = hit.point + offset;
                    break;
                }
            }
            if (Input.GetMouseButtonDown(0) && !buildingView.IsCollision)
                buildingView.IsBuilt = true;
            yield return null;
        }
    }
}
