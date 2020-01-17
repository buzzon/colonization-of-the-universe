using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSector : MonoBehaviour
{
    public Camera MainCamera;
    public float ClickDelta;
    private GameObject selectedSector;
    private float clickTime;
    private bool isSectorOpen;

    private void Start()
    {
        isSectorOpen = false;
        StartCoroutine(SelectSectorUpdate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseSector();
    }

    IEnumerator SelectSectorUpdate()
    {
        while (!isSectorOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                var hits = Physics.RaycastAll(ray);

                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.tag == "Sector")
                    {
                        if (IsDoubleClick(hit.transform.gameObject))
                            OpenSector(selectedSector);
                        else
                        {
                            if (selectedSector != null)
                                SetColor(selectedSector, Color.white);

                            selectedSector = hit.transform.gameObject;
                            SetColor(selectedSector, Color.yellow);
                        }
                    }
                }
                clickTime = Time.time;
            }
            yield return null;
        }
    }

    private bool IsDoubleClick(GameObject sector)
    {
        return Time.time <= clickTime + ClickDelta && selectedSector == sector;
    }

    private void SetColor(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void OpenSector(GameObject sector)
    {
        isSectorOpen = true;
        SetColor(sector, Color.white);
        MainCamera.gameObject.SetActive(false);
        GlobalData.CurrentSectorManager = sector.GetComponent<SectorManager>();
        GlobalData.CurrentSectorManager.Load();
        Loader.Load(Loader.SceneType.Sector);
    }

    private void CloseSector()
    {
        Loader.UnLoad(Loader.SceneType.Sector);
        GlobalData.CurrentSectorManager = null;
        MainCamera.gameObject.SetActive(true);
        isSectorOpen = false;
        StartCoroutine(SelectSectorUpdate());
    }
}
