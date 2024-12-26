using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;

    public void SetPool(ObjectPool objectPool) {
        pool = objectPool;
    }

    public void Despawn() {
        this.gameObject.SetActive(false);
    }
}
