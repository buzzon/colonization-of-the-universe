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
        if (!GlobalData.IsPlaceManagerActive)
            buildingsParent.GetComponent<PlaceManager>().Set(buildingProfile);
    }
}