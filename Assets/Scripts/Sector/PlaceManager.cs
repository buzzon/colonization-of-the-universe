using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceManager : MonoBehaviour
{
    public GameObject TerrainForBuildings;
    public Text InfoText;
    private BuildingManager buildingManager;
    private GameObject building;
    private Resource[] installationResources;

    public void Set(GameObject _building, Resource[] _installationResources)
    {
        installationResources = _installationResources;
        building = _building;
        buildingManager = building.GetComponent<BuildingManager>();
        StartCoroutine(BuildingPositionUpdate());
    }

    private IEnumerator BuildingPositionUpdate()
    {
        while (!buildingManager.IsBuilt)
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject == TerrainForBuildings)
                {
                    building.transform.position = hit.point;
                    break;
                }
            }
            if (Input.GetMouseButtonDown(0) && !buildingManager.IsCollision)
            {
                if (CurrentSector.Manager.TryGetResources(installationResources))
                    buildingManager.IsBuilt = true;
                else
                {
                    InfoText.text = "Not enough resources";
                    InfoText.enabled = true;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                InfoText.enabled = false;
                Destroy(building);
                break;
            }
            yield return null;
        }
    }
}
