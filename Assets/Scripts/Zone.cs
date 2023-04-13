using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Zone : MonoBehaviour
{
    [SerializeField] private List<Transform> _occupiablePoints = new List<Transform>();
    private List<Vector3> _vacancies = new List<Vector3>();
    private List<Vector3> _reservations = new List<Vector3>();
    private List<Vector3> _occupiedPositions = new List<Vector3>();
    private int _openReservations;

    public int OpenReservations { get { return _openReservations; } }

    private void Awake()
    {
        // Disable the meshrender
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer.enabled)
        {
            meshRenderer.enabled = false;
        }

        // Add a trigger collider
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;

        // Set vacant positions
        for (int i = 0; i < _occupiablePoints.Count; i++)
        {
            Vector3 position = _occupiablePoints[i].position;
            _vacancies.Add(position);
        }
        // Initialize open reservations property
        _openReservations = _vacancies.Count;
    }

    public Vector3 ReservePosition(Vector3 currentPosition)
    {
        Vector3 reservation = currentPosition;
        if (_vacancies.Count > 0)
        {
            reservation = _vacancies[0];
            _vacancies.Remove(reservation);
            _reservations.Add(reservation);

            _openReservations--;
            //Debug.Log($"{this} has {_openReservations} spots left.");
        }
        return reservation;
    }

    public void OccupyPosition(Vector3 position)
    {
        if (_reservations.Contains(position))
        {
            _reservations.Remove(position);
            _occupiedPositions.Add(position);
        }
    }

    public void VacatePosition(Vector3 position)
    {
        if (_occupiedPositions.Contains(position))
        {
            _occupiedPositions.Remove(position);
            _vacancies.Add(position);

            _openReservations++;
            //Debug.Log($"{this} has {_openReservations} spots left.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"{other} has entered {this}.");
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log($"{other} has exited {this}.");
    }
}