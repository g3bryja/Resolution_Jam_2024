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
    private float leftBound;
    private float rightBound;

    private void Awake() {
        leftBound = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
        rightBound = Camera.main.ScreenToWorldPoint(Vector2.right * Screen.width).x;

        float offset = transform.localScale.x / 2;
        leftBound += offset;
        rightBound -= offset;
    }

    private void Update() {
        direction = (int)PlayerInput.instance.DirectionalInput.x;
        Move();
        Rotate();
        prevDirection = direction;
    }

    private void Move() {
        if (transform.position.x > leftBound && transform.position.x < rightBound) {
            transform.position += Vector3.right * moveSpeed * direction * Time.deltaTime;
        }
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
