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
    
    [SerializeField]
    private int baseScore = 20;
    private int score;

    private float movementSpeed;
    private float rotationSpeed;
    private float scale;
    private float spawnOffset = 2.0f;
    private float upperBound;
    private PooledObject pooledObject;

    public void OnSpawn() {
        ResetRigidbody();

        movementSpeed = Random.Range(movementSpeedBounds.x, movementSpeedBounds.y);
        rotationSpeed = Random.Range(rotationSpeedBounds.x, rotationSpeedBounds.y);
        scale = Random.Range(scaleBounds.x, scaleBounds.y);
        upperBound = Camera.main.ScreenToWorldPoint(Vector2.up * Screen.height).y + spawnOffset;
        pooledObject = this.GetComponent<PooledObject>();
        // score = Mathf.CeilToInt(baseScore * scale);
        score = baseScore;
    }

    private void Update() {
        if (this.gameObject.activeSelf) {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * scale;

            if (transform.position.y > upperBound) {
                pooledObject.Despawn();
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Asteroid>()) {
            GameObject other = collision.gameObject;
            if (other.transform.localScale.x < this.transform.localScale.x) {
                other.GetComponent<PooledObject>().Despawn();
            } else {
                pooledObject.Despawn();
            }
        } else if (collision.gameObject.GetComponent<DropPodController>()) {
            Vector3 collisionVector = collision.contacts[0].point - transform.position;
            collisionVector.Normalize();
            collision.gameObject.GetComponent<DropPodController>().OnAsteroidCollision(collisionVector);
            ScoreManager.instance.SubtractScore(score);
            pooledObject.Despawn();
        }
    }

    private void ResetRigidbody() {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
