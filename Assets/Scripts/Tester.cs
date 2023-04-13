using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    [SerializeField] private Transform _unitSpawner;
    [SerializeField] private UnitData _testData;
    [SerializeField] private UnitMover _unitMover;
    [SerializeField] private Vector3 _destination;
    [SerializeField] private List<Zone> _zones = new List<Zone>();
    private List<UnitZoneAssignment> _unitZoneAssignments = new List<UnitZoneAssignment>();

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Vector3 spawnPoint = new Vector3(_unitSpawner.transform.position.x, _unitSpawner.transform.position.y + 1, _unitSpawner.transform.position.z);
            Unit unit = SpawnUnit(_testData, spawnPoint);

            AssignUnit(unit);
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            foreach (UnitZoneAssignment assignment in _unitZoneAssignments)
            {
                _unitMover.MoveUnit(assignment.Unit, assignment.Position);
            }
        }
    }

    private void AssignUnit(Unit unit)
    {
        Zone zone = _zones.FirstOrDefault(x => x.OpenReservations > 0);
        if (zone != null)
        {
            Vector3 currentPosition = unit.transform.position;
            Vector3 destination = zone.ReservePosition(currentPosition);

            if (destination != currentPosition)
            {
                foreach (var assignment in _unitZoneAssignments) // If there is already an assignment for that unit, remove it and create a new one
                {
                    if (assignment.Unit == unit)
                    {
                        _unitZoneAssignments.Remove(assignment);
                    }
                }
                UnitZoneAssignment newAssignment = new UnitZoneAssignment(unit, zone, destination);
                _unitZoneAssignments.Add(newAssignment);
            }
        }
    }

    private Unit SpawnUnit(UnitData unitData, Vector3 position)
    {
        Unit unit = new GameObject().AddComponent<Unit>();
        unit.OnSpawn(unitData, position);
        return unit;
    }
}