using UnityEngine;

[CreateAssetMenu(menuName = "Resource/Profile")]
public class ResourceProfile : ScriptableObject
{
    public Sprite Icon;
    public ResourceType Type;
}

public enum ResourceType
{
    Energy, Coal, Wood, Iron, length
}