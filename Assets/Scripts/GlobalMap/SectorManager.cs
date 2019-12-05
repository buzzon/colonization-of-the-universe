using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    private List<IBuilding> buildings;
    private List<Resource> sectorResources;

    public void AddBuilding(IBuilding building)
    {
        buildings.Add(building);
    }

    public void UpdateResources(IBuilding building, float deltaTime)
    {
        Debug.Log(sectorResources[(int)ResourceType.Energy].Count.ToString()); //Debug
        if (TryGetResources(building.ResourcesUses, deltaTime))
            AddResources(building.ResourcesProduces, deltaTime);
    }

    public bool TryGetResources(Dictionary<ResourceType, float> resources, float deltaTime)
    {
        bool isEnought = true;
        foreach (var resource in resources)
        {
            if (sectorResources[(int)resource.Key].Count < resource.Value * deltaTime)
            {
                isEnought = false;
                break;
            }
        }
        if (isEnought)
        {
            foreach (var resource in resources)
                sectorResources[(int)resource.Key].Count -= resource.Value * deltaTime;
        }
        return isEnought;
    }

    public void AddResources(Dictionary<ResourceType, float> resources, float deltaTime)
    {
        foreach (var resource in resources)
            sectorResources[(int)resource.Key].Count += resource.Value * deltaTime;
    }

    public Resource[] GetResources() => sectorResources.ToArray();

    private void Start()
    {
        buildings = new List<IBuilding>();
        sectorResources = new List<Resource>();
        for (ResourceType type = 0; type < ResourceType.lenght; type++)
            sectorResources.Add(new Resource(type.ToString()));
        sectorResources[(int)ResourceType.Energy].Count = 10; //Debug
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < buildings.Count; i++)
            UpdateResources(buildings[i], Time.fixedDeltaTime);
    }
}
