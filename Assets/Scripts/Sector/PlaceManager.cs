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
    private BuildingProfile buildingProfile;

    public void Awake()
    {
        GlobalData.CurrentSectorManager.Load(transform);
    }

    public void Set(BuildingProfile _buildingProfile)
    {
        buildingProfile = _buildingProfile;
        building = Instantiate(buildingProfile.Prefab, transform);
        buildingManager = building.GetComponent<BuildingManager>();
        StartCoroutine(BuildingPositionUpdate());
        GlobalData.IsPlaceManagerActive = true;
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
                if (GlobalData.CurrentSectorManager.TryGetResources(buildingProfile.InstallationResources))
                    buildingManager.SetAsBuilt(buildingProfile);
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
        GlobalData.IsPlaceManagerActive = false;
    }
}
