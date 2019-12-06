using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject _mesh;
    [SerializeField] private int _sectorsInLine;
    [SerializeField] private float _offset;
    private BoxCollider _world;

    void Awake()
    {
        _world = transform.gameObject.GetComponent<BoxCollider>();
    }

    void Start()
    {
        Vector3 sectorSize = _mesh.GetComponent<Renderer>().bounds.size;
        Vector3 fullSectorSize = new Vector3(sectorSize.x + _offset, sectorSize.y + _offset, sectorSize.z + _offset);

        Create(fullSectorSize);
        SetBound(fullSectorSize);
    }

    private void Create(Vector3 sectorOffset)
    {
        int k = 0;
        for (int j = 0; j < _sectorsInLine; j++)
        {
            for (int i = 0; i < _sectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * sectorOffset.x + (sectorOffset.x / 2) * (j % 2), 0, j * sectorOffset.z * 3 / 4);
                GameObject sector = Instantiate(_mesh, position, Quaternion.identity, transform);
                sector.GetComponent<SectorManager>().ID = k;
                k++;
            }
        }
    }

    private void SetBound(Vector3 sectorOffset)
    {
        _world.size = new Vector3(sectorOffset.x * _sectorsInLine, 3, sectorOffset.z * 3 / 4 * _sectorsInLine);
        _world.center = new Vector3(_world.size.x / 2, 0, _world.size.z / 2);
    }
}
