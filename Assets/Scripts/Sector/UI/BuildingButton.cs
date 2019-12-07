using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    private GameObject prefab;
    private Transform buildingsParent;
    private Dictionary<ResourceType, int> requiredResources;

    public void Set(BuildingProfile _buildingProfile, Transform _buildingsParent)
    {
        prefab = _buildingProfile.Prefab;
        buildingsParent = _buildingsParent;

        requiredResources = new Dictionary<ResourceType, int>();
        foreach (Resource resource in _buildingProfile.RequiredResources)
            requiredResources.Add(resource.Type, resource.Count);
    }

    public void OnClick()
    {
        if (CurrentSector.Manager.TryGetResources(requiredResources))
        {
            GameObject building = Instantiate(prefab, buildingsParent);
            buildingsParent.GetComponent<PlaceManager>().Set(building);
        }
    }
}