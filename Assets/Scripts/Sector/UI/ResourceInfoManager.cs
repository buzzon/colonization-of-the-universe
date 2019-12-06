using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfoManager : MonoBehaviour
{
    public GameObject ResourceInfoPrefab;

    void Start()
    {
        ResourceProfile[] resources = Resources.LoadAll<ResourceProfile>("Resources");
        foreach (ResourceProfile resource in resources)
        {
            GameObject info = Instantiate(ResourceInfoPrefab, transform);
            info.transform.Find("Count").GetComponent<Text>().text = "0";
            info.transform.Find("Icon").GetComponent<Image>().sprite = resource.Icon;
            ResourceInfo resourceInfo = info.GetComponent<ResourceInfo>();
            resourceInfo.Set(resource.Type);
        }
    }
}
