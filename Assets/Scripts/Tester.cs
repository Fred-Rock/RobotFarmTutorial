using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    [SerializeField] private Transform _unitSpawner;
    [SerializeField] private UnitData _testData;
    [SerializeField] private UnitMover _unitMover;
    [SerializeField] private Vector3 _destination;
    [SerializeField] private Zone _zone;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Vector3 spawnPoint = new Vector3(_unitSpawner.transform.position.x, _unitSpawner.transform.position.y + 1, _unitSpawner.transform.position.z);
            Unit unit = SpawnUnit(_testData, spawnPoint);
            Vector3 reservation = _zone.ReservePosition(unit.transform.position);
            //_unitMover.MoveUnit(unit, _destination);
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            
        }
    }

    private Unit SpawnUnit(UnitData unitData, Vector3 position)
    {
        Unit unit = new GameObject().AddComponent<Unit>();
        unit.OnSpawn(unitData, position);
        return unit;
    }
}