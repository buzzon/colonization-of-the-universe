using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public BuildingProfile BuildingProfile { get; set; }
    public Transform BuildingsParent { get; set; }
    public void OnClick()
    {
        GameObject building = Instantiate(BuildingProfile.Prefab, BuildingsParent);
        BuildingsParent.GetComponent<PlaceManager>().Set(building);
    }
}