using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingView : MonoBehaviour
{
    public bool IsCollision { get; private set; }
    public UnityEvent OnCollision = new UnityEvent();
    public UnityEvent OnRelease = new UnityEvent();
    public UnityEvent OnBuild = new UnityEvent();
    public bool IsBuilt;

    private void OnCollisionStay(Collision collision)
    {
        if (!IsBuilt)
        {
            if (!IsCollision)
                OnCollision.Invoke();
            IsCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!IsBuilt)
        {
            OnRelease.Invoke();
            IsCollision = false;
        }
    }
}
