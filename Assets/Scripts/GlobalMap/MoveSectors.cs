using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSectors : MonoBehaviour
{
    [SerializeField] private BoxCollider _world;
    [SerializeField] private GameObject _sector;
    [SerializeField] private int _sectorsInLine;
    [SerializeField] private float _distanceBetweenSectors;
    [SerializeField] private float _moveSpeed;
    private Vector3 _offset;

    private List<GameObject> _children;

    void Start()
    {
        _children = new List<GameObject>(_sectorsInLine * _sectorsInLine);

        _offset = new Vector3(_sector.GetComponent<Renderer>().bounds.size.x + _distanceBetweenSectors,
                              _sector.GetComponent<Renderer>().bounds.size.y + _distanceBetweenSectors,
                              _sector.GetComponent<Renderer>().bounds.size.z + _distanceBetweenSectors);

        CreateMap();
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (!(Math.Abs(horizontal) > 0.1f) && !(Math.Abs(vertical) > 0.1f)) return;
        transform.position += new Vector3(horizontal, 0, vertical) * Time.deltaTime * _moveSpeed;

        foreach (var sector in _children)
        {
            var position = sector.transform.position;

            if (position.x < _world.bounds.min.x)
                sector.transform.position = new Vector3(_world.bounds.max.x + position.x - _world.bounds.min.x, position.y, position.z);
            else if (position.x > _world.bounds.max.x)
                sector.transform.position = new Vector3(_world.bounds.min.x + position.x - _world.bounds.max.x, position.y, position.z);

            if (position.z < _world.bounds.min.z)
                sector.transform.position = new Vector3(position.x, position.y, _world.bounds.max.z + position.z - _world.bounds.min.z);
            else if (position.z > _world.bounds.max.z)
                sector.transform.position = new Vector3(position.x, position.y, _world.bounds.min.z + position.z - _world.bounds.max.z);
        }
    }

    private void CreateMap()
    {
        for (int j = 0; j < _sectorsInLine; j++)
            for (int i = 0; i < _sectorsInLine; i++)
            {
                var sector = Instantiate(_sector, new Vector3(i * _offset.x + (_offset.x / 2) * (j % 2), 0, j * _offset.z * 3 / 4), Quaternion.identity, transform);
                _children.Add(sector);
            }

        _world.size = new Vector3(_offset.x * _sectorsInLine, 3, _offset.z * 3 / 4 * _sectorsInLine);
        _world.center = new Vector3(_world.size.x / 2, 0, _world.size.z / 2);
    }
}
