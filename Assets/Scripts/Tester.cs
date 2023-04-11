using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    [SerializeField] private UnitData _testData;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            SpawnUnit(_testData, spawnPoint);
        }
    }

    private void SpawnUnit(UnitData unitData, Vector3 position)
    {
        Unit unit = new GameObject().AddComponent<Unit>();
        unit.OnSpawn(unitData, position);
    }
}