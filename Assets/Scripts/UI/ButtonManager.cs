using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
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
            button.transform.Find("Price").GetComponent<Text>().text = building.Price.ToString();
            BuildingButton buildingButton = button.GetComponent<BuildingButton>();
            buildingButton.BuildingsParent = BuildingsParent;
            buildingButton.BuildingProfile = building;
        }
    }
}
