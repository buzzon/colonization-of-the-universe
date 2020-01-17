using UnityEngine;

[CreateAssetMenu(menuName = "Building/Profile")]
public class BuildingProfile : ScriptableObject
{
    public GameObject Prefab;
    public Sprite Icon;
    public BuildingType Type;
    public string Name;
    public Resource[] InstallationResources;
    public Resource[] RequiredResources;
    public Resource[] ProducedResources;
}

public enum BuildingType
{
    Mine, PowerStation, IronFactory, length
}