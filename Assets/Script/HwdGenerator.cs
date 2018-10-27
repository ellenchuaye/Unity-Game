using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwdGenerator : MonoBehaviour {

    public ObjectPooler hwdPool;

    public void SpawnHwd(Vector3 startPosition)
    {
        GameObject hwd = hwdPool.GetPooledObject();
        hwd.transform.position = startPosition;
        hwd.SetActive(true);


    }
}
