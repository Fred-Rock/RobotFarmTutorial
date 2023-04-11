using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitData _unitData;
    private Vector3 _currentPosition;

    public UnitData UnitData { get { return _unitData; } }

    public void OnSpawn(UnitData unitData, Vector3 spawnPoint)
    {
        _unitData = unitData;
        name = $"Unit: {_unitData}";

        transform.position = spawnPoint;
        Instantiate(_unitData.Prefab, transform.position, Quaternion.identity, transform);
        SetCurrentPosition(spawnPoint);
    }

    public void SetCurrentPosition(Vector3 position)
    {
        _currentPosition = position;
    }
}