using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Terrain;
    private GameObject building;
    private bool isBuilt;
    public void OnClick()
    {
        building = Instantiate(Prefab);
        isBuilt = false;
        StartCoroutine(BuildingPositionUpdate());
    }
    IEnumerator BuildingPositionUpdate()
    {
        while (!isBuilt)
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject == Terrain)
                {
                    Vector3 offset = new Vector3(0, building.GetComponent<Renderer>().bounds.size.y / 2 - 0.04f, 0);
                    building.transform.position = hit.point + offset;
                    break;
                }
            }
            BuildingView buildingView = building.GetComponent<BuildingView>();
            if (Input.GetMouseButtonDown(0) && !buildingView.IsCollision)
            {
                isBuilt = true;
                buildingView.IsBuilt = isBuilt;
                buildingView.OnBuild.Invoke();
            }
            yield return null;
        }
    }
}
