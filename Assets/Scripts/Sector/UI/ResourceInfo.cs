using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfo : MonoBehaviour
{
    private ResourceType type;
    public void Set(ResourceType _type)
    {
        type = _type;
        StartCoroutine(UpdateInfo());
    }

    IEnumerator UpdateInfo()
    {
        while (true)
        {
            Resource resource = CurrentSector.Manager.GetResource(type);
            transform.Find("Count").GetComponent<Text>().text = resource.Count.ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
