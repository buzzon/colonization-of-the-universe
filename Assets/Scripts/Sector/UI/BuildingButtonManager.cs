using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonManager : MonoBehaviour
{
    public GameObject BuildingButtonPrefab;
    public Transform BuildingsParent;

    void Start()
    {
        BuildingProfile[] buildings = Resources.LoadAll<BuildingProfile>("Buildings");
        foreach(BuildingProfile building in buildings)
        {
            GameObject button = Instantiate(BuildingButtonPrefab, transform);
            button.transform.Find("Name").GetComponent<Text>().text = building.Name;
            Text text = button.transform.Find("Required").GetComponent<Text>();
            text.text = "";
            foreach (RequiredResourcesDictionary required in building.RequiredResources)
                text.text += "\r\n" + required.Type.ToString() + ": " + required.Count;
            button.transform.GetComponent<Image>().sprite = building.Icon;
            BuildingButton buildingButton = button.GetComponent<BuildingButton>();
            buildingButton.Set(building, BuildingsParent);
        }
    }
}
