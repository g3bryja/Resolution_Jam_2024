using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int spawnCount = 15;

    [SerializeField]
    private float spawnOffset = 2.0f;

    private float elapsedTime = 0.0f;

    private ObjectPool pool;
    private Camera camera;
    private Vector2 leftBound;
    private Vector2 rightBound;

    private void Awake() {
        camera = (Camera)FindObjectOfType(typeof(Camera));
        GetBounds();
        InitializeObjectPool();
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnOffset) {
            SpawnHazard();
            SpawnHazard();
            SpawnHazard();
            elapsedTime = 0.0f;
        }
    }

    private void SpawnHazard() {
        Vector3 position = new Vector3(Random.Range(leftBound.x, rightBound.x), leftBound.y, 0);
        GameObject entity = pool.Spawn(position, transform.rotation);
        if (entity != null) {
            entity.GetComponent<Asteroid>().OnSpawn();
        }
    }

    private void GetBounds() {
        leftBound = Camera.main.ScreenToWorldPoint(Vector2.zero);
        rightBound = Camera.main.ScreenToWorldPoint(Vector2.right * Screen.width);

        leftBound -= Vector2.up * spawnOffset;
        rightBound -= Vector2.up * spawnOffset;
    }

    private void InitializeObjectPool() {
        pool = this.gameObject.AddComponent<ObjectPool>();
        pool.Initialize(prefab, spawnCount);
    }
}
