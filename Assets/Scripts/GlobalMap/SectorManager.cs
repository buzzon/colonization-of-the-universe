using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    public int ID;
    private List<Building> buildings;
    private List<Resource> sectorResources;
    private List<GameObject> buildingObjects;
    private bool isLoad;

    private void Init()
    {
        buildings = new List<Building>();
        buildingObjects = new List<GameObject>();
        sectorResources = new List<Resource>();
        for (ResourceType type = 0; type < ResourceType.length; type++)
            sectorResources.Add(new Resource(type, 0));
        sectorResources[(int)ResourceType.Coal].Count = 100; //Debug
        sectorResources[(int)ResourceType.Wood].Count = 400; //Debug
        sectorResources[(int)ResourceType.Iron].Count = 400; //Debug
        StartCoroutine(SectorUpdate());
    }

    private IEnumerator SectorUpdate()
    {
        while (true)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                bool isWork = UpdateResources(GlobalData.BuildingProfiles[(int)buildings[i].Type]);
                if (isWork && !buildings[i].IsWork)
                {
                    if (isLoad)
                        buildingObjects[i].GetComponent<BuildingManager>().IsWork = true;
                    buildings[i].IsWork = true;
                }
                else if (!isWork && buildings[i].IsWork)
                {
                    if (isLoad)
                        buildingObjects[i].GetComponent<BuildingManager>().IsWork = false;
                    buildings[i].IsWork = false;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void Load(Transform buildingsParent)
    {
        isLoad = true;
        if (buildings is null)
            Init();
        else
        {
            buildingObjects = new List<GameObject>();
            for (int i = 0; i < buildings.Count; i++)
            {
                GameObject prefab = GlobalData.BuildingProfiles[(int)buildings[i].Type].Prefab;
                GameObject buildingObject = Instantiate(prefab, buildings[i].Position, buildings[i].Rotation, buildingsParent);
                buildingObject.GetComponent<BuildingManager>().IsBuilt = true;
                buildingObject.GetComponent<BuildingManager>().IsWork = buildings[i].IsWork;
                buildingObjects.Add(buildingObject);
            }
        }
    }

    public void UnLoad()
    {
        isLoad = false;
    }

    public void AddBuilding(BuildingProfile buildingProfile, GameObject buildingObject)
    {
        buildings.Add(new Building(buildingProfile.Type, buildingObject.transform.position, buildingObject.transform.rotation, true));
        buildingObjects.Add(buildingObject);
    }

    public Resource GetResource(ResourceType resourceType) => sectorResources[(int)resourceType];

    private bool UpdateResources(BuildingProfile building)
    {
        bool isWork = TryGetResources(building.RequiredResources);
        if (isWork)
            AddResources(building.ProducedResources);
        return isWork;
    }

    public bool TryGetResources(Resource[] resources)
    {
        bool isEnough = true;
        foreach (var resource in resources)
        {
            if (sectorResources[(int)resource.Type].Count < resource.Count)
            {
                isEnough = false;
                break;
            }
        }
        if (isEnough)
        {
            foreach (var resource in resources)
                sectorResources[(int)resource.Type].Count -= resource.Count;
        }
        return isEnough;
    }

    private void AddResources(Resource[] resources)
    {
        foreach (var resource in resources)
            sectorResources[(int)resource.Type].Count += resource.Count;
    }
}
