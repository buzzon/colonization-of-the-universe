using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public Resource[] RequiredResources;
    public Resource[] ProducedResources;
    public abstract void Set();
}
