using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Zone : MonoBehaviour
{
    [SerializeField] private List<Transform> _occupiablePoints = new List<Transform>();
    private List<Vector3> _positions = new List<Vector3>();
    private int _vacancies;

    private void Start()
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
            _positions.Add(position);
            
            // Debug.Log($"{position} is vacant.");
        }
        _vacancies = _positions.Count;
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