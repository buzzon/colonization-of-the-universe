using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonManager : MonoBehaviour
{
    public GameObject BuildingButtonPrefab;
    public Transform BuildingsParent;

    void Start()
    {
        GlobalData.BuildingProfiles = Resources.LoadAll<BuildingProfile>("Buildings");
        Array.Sort(GlobalData.BuildingProfiles, new BuildingProfileComparer());
        foreach(BuildingProfile building in GlobalData.BuildingProfiles)
        {
            GameObject button = Instantiate(BuildingButtonPrefab, transform);
            button.transform.Find("Name").GetComponent<Text>().text = building.Name;
            Text text = button.transform.Find("Required").GetComponent<Text>();
            text.text = "";
            foreach (Resource resource in building.InstallationResources)
                text.text += "\r\n" + resource.Type.ToString() + ": " + resource.Count;
            button.transform.GetComponent<Image>().sprite = building.Icon;
            BuildingButton buildingButton = button.GetComponent<BuildingButton>();
            buildingButton.Set(building, BuildingsParent);
        }
    }
}
