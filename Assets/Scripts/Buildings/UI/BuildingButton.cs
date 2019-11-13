using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    private BuildingProfile buildingProfile;
    private Transform buildingsParent;

    public void Set(BuildingProfile _buildingProfile, Transform _buildingsParent)
    {
        buildingProfile = _buildingProfile;
        buildingsParent = _buildingsParent;
    }

    public void OnClick()
    {
        GameObject building = Instantiate(buildingProfile.Prefab, buildingsParent);
        buildingsParent.GetComponent<PlaceManager>().Set(building);
    }
}