﻿using System.Collections;
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

    private void UpdateResources(IBuilding building)
    {
        Debug.Log(sectorResources[(int)ResourceType.Energy].Count.ToString()); //Debug
        if (TryGetResources(building.ResourcesUses))
            AddResources(building.ResourcesProduces);
    }

    private bool TryGetResources(Dictionary<ResourceType, int> resources)
    {
        bool isEnough = true;
        foreach (var resource in resources)
        {
            if (sectorResources[(int)resource.Key].Count < resource.Value)
            {
                isEnough = false;
                break;
            }
        }
        if (isEnough)
        {
            foreach (var resource in resources)
                sectorResources[(int)resource.Key].Count -= resource.Value;
        }
        return isEnough;
    }

    private void AddResources(Dictionary<ResourceType, int> resources)
    {
        foreach (var resource in resources)
            sectorResources[(int)resource.Key].Count += resource.Value;
    }

    public Resource[] GetResources() => sectorResources.ToArray();

    private void Start()
    {
        buildings = new List<IBuilding>();
        sectorResources = new List<Resource>();
        for (ResourceType type = 0; type < ResourceType.lenght; type++)
            sectorResources.Add(new Resource(type.ToString()));
        sectorResources[(int)ResourceType.Energy].Count = 10; //Debug
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
}
