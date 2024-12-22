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

    private Rigidbody rigidbody;

    private int prevDirection = 0;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        int direction = (int)PlayerInput.instance.DirectionalInput.x;

        transform.position += Vector3.right * moveSpeed * direction * Time.deltaTime;

        prevDirection = direction;
    }
}
