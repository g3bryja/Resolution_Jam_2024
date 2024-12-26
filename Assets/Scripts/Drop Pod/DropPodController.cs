using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropPodController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4.0f;

    [SerializeField]
    private float moveAccelerationTime = 0.3f;

    [SerializeField]
    private float maxRotation = 15.0f;

    [SerializeField]
    private float rotationSmoothing = 7.0f;

    [SerializeField]
    private Transform model;

    private int direction = 0;
    private int prevDirection = 0;

    private void Update() {
        direction = (int)PlayerInput.instance.DirectionalInput.x;
        Move();
        Rotate();
        prevDirection = direction;
    }

    private void Move() {
        transform.position += Vector3.right * moveSpeed * direction * Time.deltaTime;
    }

    private void Rotate() {
        float targetRotation = 0;

        if (direction != 0) {
            targetRotation = maxRotation * Mathf.Sign(direction);
        }

        Quaternion target = Quaternion.Euler(Vector3.forward * targetRotation);
        model.rotation = Quaternion.Slerp(model.rotation, target,  Time.deltaTime * rotationSmoothing);
    }
}
