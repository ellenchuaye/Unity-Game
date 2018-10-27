using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondGenerator : MonoBehaviour {

    public ObjectPooler DiamondPool;

    public void SpawnDiamond(Vector3 startPosition)
    {
        GameObject diamond = DiamondPool.GetPooledObject();
        diamond.transform.position = startPosition;
        diamond.SetActive(true);


    }
}
