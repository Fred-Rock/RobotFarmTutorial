using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    private float _minDuration = 1f;
    private float _maxDuration = 3f;

    private void Start()
    {
        DOTween.Init();
    }

    public void MoveUnit(Unit unit, Vector3 destination, float duration)
    {
        StartCoroutine(MoveUnitCoroutine(unit, destination, duration));
    }

    public void MoveUnit(Unit unit, Vector3 destination)
    {
        float duration = Random.Range(_minDuration, _maxDuration);
        StartCoroutine(MoveUnitCoroutine(unit, destination, duration));
    }

    private IEnumerator MoveUnitCoroutine(Unit unit, Vector3 destination, float duration)
    {
        Tween moveTween = unit.transform.DOMove(destination, duration);
        yield return moveTween.WaitForCompletion();
        unit.SetCurrentPosition(destination);
    }
}
