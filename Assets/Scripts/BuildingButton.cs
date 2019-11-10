using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public BuildingProfile BuildingProfile;
    public Transform BuildingsParent;
    public void OnClick()
    {
        GameObject building = Instantiate(BuildingProfile.Prefab, BuildingsParent);
        BuildingsParent.GetComponent<PlaceManager>().Set(building);
    }
}