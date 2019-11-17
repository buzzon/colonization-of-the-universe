using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    private List<Resource> resources;
    public void AddResourceFactor(ResourceType resourceType, float factor)
    {
        resources[(int)resourceType].Factor += factor;
    }
    public Resource[] GetResources() => resources.ToArray();

    private void Start()
    {
        resources = new List<Resource>();
        for (ResourceType type = 0; type < ResourceType.lenght; type++)
            resources.Add(new Resource(type.ToString()));
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < resources.Count; i++)
            resources[i].Count += resources[i].Factor * Time.fixedDeltaTime;
    }
}
