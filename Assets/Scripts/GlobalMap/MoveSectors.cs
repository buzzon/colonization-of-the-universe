using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSectors : MonoBehaviour
{
    [SerializeField] private BoxCollider _world;
    [SerializeField] private GameObject _sector;
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
        CreateMap();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Math.Abs(horizontal) < 0.01f && Math.Abs(vertical) < 0.01f) return;

        transform.position += new Vector3(horizontal, 0, vertical) * Time.deltaTime * _moveSpeed;

        foreach (GameObject sector in _sectors)
        {
            Vector3 position = sector.transform.position;

            NewMethod(position, sector);

            if (position.z < _world.bounds.min.z)
                sector.transform.position = new Vector3(position.x, position.y, _world.bounds.max.z + position.z - _world.bounds.min.z);
            else if (position.z > _world.bounds.max.z)
                sector.transform.position = new Vector3(position.x, position.y, _world.bounds.min.z + position.z - _world.bounds.max.z);
        }
    }

    private void NewMethod(Vector3 position, GameObject sector)
    {
        if (position.x < _world.bounds.min.x)
            sector.transform.position =
                new Vector3(_world.bounds.max.x + position.x - _world.bounds.min.x, position.y, position.z);
        else if (position.x > _world.bounds.max.x)
            sector.transform.position =
                new Vector3(_world.bounds.min.x + position.x - _world.bounds.max.x, position.y, position.z);
    }

    private void CreateMap()
    {
        Vector3 sectorSize = _sector.GetComponent<Renderer>().bounds.size;
        Vector3 sectorOffset = new Vector3(sectorSize.x + _offset, sectorSize.y + _offset, sectorSize.z + _offset);

        for (int j = 0; j < _sectorsInLine; j++)
        {
            for (int i = 0; i < _sectorsInLine; i++)
            {
                Vector3 position = new Vector3(i * sectorOffset.x + (sectorOffset.x / 2) * (j % 2), 0, j * sectorOffset.z * 3 / 4);
                GameObject sector = Instantiate(_sector, position, Quaternion.identity, transform);
                _sectors.Add(sector);
            }
        }

        SetBoundMap(sectorOffset);
    }

    private void SetBoundMap(Vector3 sectorOffset)
    {
        _world.size = new Vector3(sectorOffset.x * _sectorsInLine, 3, sectorOffset.z * 3 / 4 * _sectorsInLine);
        _world.center = new Vector3(_world.size.x / 2, 0, _world.size.z / 2);
    }
}
