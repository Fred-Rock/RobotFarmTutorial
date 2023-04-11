using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    private List<Zone> _zones = new List<Zone>();

    private void Start()
    {
        _zones = FindObjectsOfType<Zone>().ToList();
    }
}