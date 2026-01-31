using System;
using UnityEngine;

[ExecuteAlways]
public class LerpMovement : MonoBehaviour
{
    public float AnimTime = 1f;
    //public Vector3 DeltaPosition = new(1f, 0f, 0f);
    public AnimationCurve AnimCurve;

    private enum Direction
    {
        None,
        Forward,
        Backward
    }
    private Direction moveState = Direction.None;

    private float currentValue = 0f;
    private Vector3 defaultPosition;
    private Vector3 targetPosition;

    private float distanceToTarget;

    private void OnEnable()
    {
        SetDefault();
    }

    private void Update()
    {
        MoveForward();
    }

    private void SetDefault()
    {
        currentValue = 0f;
        defaultPosition = transform.position;
    }

    public float MoveTo(Vector3 _target, float _distance)
    {
        SetDefault();

        targetPosition = _target;

        moveState = Direction.Forward;

        distanceToTarget = _distance;

        return AnimTime;
    }

    public float MoveWithDelta(Vector3 _deltaPosition)
    {
        SetDefault();

        targetPosition = defaultPosition + _deltaPosition;

        moveState = Direction.Forward;

        return AnimTime;
    }

    /// <summary>
    /// Scales up.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void MoveForward()
    {
        if (moveState == Direction.Forward)
        {
            if (currentValue == 1f)
            {
                 moveState = Direction.None;
                return;
            }

            Interpolate(1f);
        }
    }

    /// <summary>
    /// Interpolates the value and sets the scale.
    /// </summary>
    /// <param name="_target"></param>
    private void Interpolate(float _target)
    {
        currentValue = Mathf.MoveTowards(
            currentValue, _target, Time.deltaTime / (AnimTime * distanceToTarget));

        Vector3 position = Vector3.Lerp(defaultPosition, targetPosition, AnimCurve.Evaluate(currentValue));
        SetPosition(position);
    }
     
    /// <summary>
    /// Sets the scale.
    /// </summary>
    /// <param name="rValue"></param>
    private void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
        //Debug.Log($"{gameObject.name} transform.position {transform.position}");
    }
}