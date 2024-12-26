using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementSpeedBounds = new Vector2(2.0f, 5.0f);

    [SerializeField]
    private Vector2 rotationSpeedBounds = new Vector2(2.0f, 5.0f);

    [SerializeField]
    private Vector2 scaleBounds = new Vector2(1.0f, 3.5f);

    private float movementSpeed;
    private float rotationSpeed;
    private float scale;
    private float spawnOffset = 2.0f;
    private float upperBound;

    public void OnSpawn() {
        movementSpeed = Random.Range(movementSpeedBounds.x, movementSpeedBounds.y);
        rotationSpeed = Random.Range(rotationSpeedBounds.x, rotationSpeedBounds.y);
        scale = Random.Range(scaleBounds.x, scaleBounds.y);
        upperBound = Camera.main.ScreenToWorldPoint(Vector2.up * Screen.height).y + spawnOffset;
    }

    private void Update() {
        if (this.gameObject.activeSelf) {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * scale;

            if (transform.position.y > upperBound) {
                this.GetComponent<PooledObject>().Despawn();
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("HIT");
    }
}
