using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private List<GameObject> pool;
    public int Size { get { return pool.Count; } }

    private void Awake() {
        pool = new List<GameObject>();
    }

    public void Initialize(GameObject entity, int n = 0) {
        prefab = entity;
        for (int i = 0; i < n; i++) {
            GameObject instance = Instantiate(prefab, transform.position, transform.rotation);
            PooledObject pooledInstance = instance.AddComponent<PooledObject>();
            pooledInstance.SetPool(this);
            instance.name += "(" + i + ")";
            instance.SetActive(false);
            pool.Add(instance);
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation) {
        foreach (var entity in pool) {
            if (!entity.activeSelf) {
                entity.transform.position = position;
                entity.transform.rotation = rotation;
                entity.SetActive(true);
                return entity;
            }
        }
        Debug.LogWarning("Object pool has no available resources");
        return null;
    }

    public void DespawnAll() {
        foreach (GameObject entity in pool) {
            entity.SetActive(false);
        }
    }
}
