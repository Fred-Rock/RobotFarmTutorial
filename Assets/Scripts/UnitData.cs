using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "GameData/NewUnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;

    public GameObject Prefab { get { return _prefab; } }
}