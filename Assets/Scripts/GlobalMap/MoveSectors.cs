using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveSectors : MonoBehaviour
{
    [SerializeField] private BoxCollider _world;
    [SerializeField] private GameObject _mesh;
    [SerializeField] private int _sectorsInLine;
    [SerializeField] private float _offset;
    [SerializeField] private float _moveSpeed;
    private List<GameObject> _sectors;

    void Awake()
    {
        _sectors = new List<GameObject>(_sectorsInLine * _sectorsInLine);
    }

    void Start()
    {
        Vector3 sectorSize = _mesh.GetComponent<Renderer>().bounds.size;
        Vector3 fullSectorSize = new Vector3(sectorSize.x + _offset, sectorSize.y + _offset, sectorSize.z + _offset);

        CreateMap(fullSectorSize);
        SetBoundMap(fullSectorSize);
    }

    void FixedUpdate()
    {
        if (!IsInputReceived(out float horizontal, out float vertical)) return;

        transform.position -= new Vector3(horizontal, 0, vertical).normalized * Time.deltaTime * _moveSpeed;

        foreach (GameObject sector in _sectors)
        {
            Vector3 pos = sector.transform.position;

            if (pos.x < _world.bounds.min.x)
                sector.transform.position = new Vector3(_world.bounds.max.x + pos.x - _world.bounds.min.x, pos.y, pos.z);
            else if (pos.x > _world.bounds.max.x)
                sector.transform.position =  new Vector3(_world.bounds.min.x + pos.x - _world.bounds.max.x, pos.y, pos.z);

            if (pos.z < _world.bounds.min.z)
                sector.transform.position = new Vector3(pos.x, pos.y, _world.bounds.max.z + pos.z - _world.bounds.min.z);
            else if (pos.z > _world.bounds.max.z)
                sector.transform.position = new Vector3(pos.x, pos.y, _world.bounds.min.z + pos.z - _world.bounds.max.z);
        }
    }

    private static bool IsInputReceived(out float horizontal, out float vertical)
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        return Math.Abs(horizontal) > 0.01f || Math.Abs(vertical) > 0.01f;
    }

    private void CreateMap(Vector3 sectorOffset)
    {
        for (int j = 0; j < _sectorsInLine; j++)
        {
            for (int i = 0; i < _sectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * sectorOffset.x + (sectorOffset.x / 2) * (j % 2), 0, j * sectorOffset.z * 3 / 4);
                GameObject sector = Instantiate(_mesh, position, Quaternion.identity, transform);
                _sectors.Add(sector);
            }
        }
    }

    private void SetBoundMap(Vector3 sectorOffset)
    {
        _world.size = new Vector3(sectorOffset.x * _sectorsInLine, 3, sectorOffset.z * 3 / 4 * _sectorsInLine);
        _world.center = new Vector3(_world.size.x / 2, 0, _world.size.z / 2);
    }
}