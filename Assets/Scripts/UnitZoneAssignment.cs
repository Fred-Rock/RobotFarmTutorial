using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitZoneAssignment
{
    private Unit _unit;
    private Zone _zone;
    private Vector3 _position;

    public Unit Unit { get { return _unit; } }
    public Zone Zone { get { return _zone; } }
    public Vector3 Position { get { return _position; } }

    public UnitZoneAssignment(Unit unit, Zone zone, Vector3 position)
    {
        _unit = unit;
        _zone = zone;
        _position = position;
    }
}
