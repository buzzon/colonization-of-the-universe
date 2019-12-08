using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    public int ID;
    private List<IBuilding> buildings;
    private List<Resource> sectorResources;

    private void Start()
    {
        buildings = new List<IBuilding>();
        sectorResources = new List<Resource>();
        for (ResourceType type = 0; type < ResourceType.length; type++)
            sectorResources.Add(new Resource(type, 0));
        sectorResources[(int)ResourceType.Coal].Count = 10; //Debug
        sectorResources[(int)ResourceType.Wood].Count = 40; //Debug
        sectorResources[(int)ResourceType.Iron].Count = 40; //Debug
        StartCoroutine(SectorUpdate());
    }

    private IEnumerator SectorUpdate()
    {
        while (true)
        {
            for (int i = 0; i < buildings.Count; i++)
                UpdateResources(buildings[i]);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void AddBuilding(IBuilding building)
    {
        buildings.Add(building);
    }

    public Resource GetResource(ResourceType resourceType) => sectorResources[(int)resourceType];

    private void UpdateResources(IBuilding building)
    {
        bool isWork = TryGetResources(building.RequiredResources);
        if (isWork)
            AddResources(building.ProducedResources);

        if (CurrentSector.Manager == this)
        {
            MonoBehaviour buildingEntity = building as MonoBehaviour;
            if (buildingEntity != null)
            {
                if (buildingEntity.TryGetComponent(out BuildingManager buildingManager))
                {
                    if (isWork && !buildingManager.IsWork)
                        buildingManager.IsWork = true;
                    else if (!isWork && buildingManager.IsWork)
                        buildingManager.IsWork = false;
                }
            }
        }
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
