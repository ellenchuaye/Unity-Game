using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public Transform generatorPoint;
    public Vector3 generatorPointStart;
    public float distanceBetween;
    public float distanceBetween_1;

    //private float platformHeight;
    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    //public float distanceBetweenMin_1;
    //public float distanceBetweenMax_1;

  //  public GameObject[] thePlatforms;
    private int platformSelector;
    private int previousSelect = 1;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    //private float minHeight;
    //public Transform maxHeightPoint;
   // private float maxHeight;
    //public float maxHeightChange;
    //private float heightChange;

    private float minWidth;
    public Transform maxWidthPoint;
    public Transform minWidthPoint;
    private float maxWidth;
    public float maxWidthChange;
    private float widthChange;
    private Vector3 playerTeleport;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    private HwdGenerator theHwdGenerator;
    public float randomHwdThreshold;

    private DiamondGenerator theDiamondGenerator;
    public float randomDiamondThreshold;


	// Use this for initialization
	void Start () {
        //cam = GetComponent<Camera>();
        // cam = Camera.main;
        //cam.enabled = true;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        theHwdGenerator = FindObjectOfType<HwdGenerator>();
        theDiamondGenerator = FindObjectOfType<DiamondGenerator>();

        minWidth = minWidthPoint.position.x;
        maxWidth = maxWidthPoint.position.x;
       // generatorPointStart = generatorPoint;

        platformWidths = new float[theObjectPools.Length];
        for (int i =0; i< theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
            
        }
        //platformHeight = theObjectPools[0].pooledObject.GetComponent<BoxCollider2D>().size.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < generationPoint.position.y)
        {
            platformSelector = Random.Range(0, theObjectPools.Length);
            //Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            //distanceBetween_1 = Random.Range(-10, (2f * cam.orthographicSize * cam.aspect)-platformWidths[platformSelector]-transform.localPosition.x);
            //distanceBetween_1 = Random.Range(-10, distanceBetweenMax_1);
            /* while (2f * cam.orthographicSize * cam.aspect + (platformWidths[platformSelector])/2> 1)
              {
                  randomGenerator(); 
              }
             while (2f * cam.orthographicSize * cam.aspect - (platformWidths[platformSelector]) / 2 < 0)
             {
                 randomGenerator();
             }*/

            //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

            /*heightChange = transform.position.y + Random.Range(maxHeightChange, minHeight);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
                
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
                */
            widthChange = transform.position.x + Random.Range(minWidth, maxWidthChange) + (platformWidths[previousSelect]/2);
          
            if (widthChange + (platformWidths[platformSelector]/2) > maxWidth)
            {
                    widthChange = maxWidth -5f;
            }
                
            if (widthChange - platformWidths[platformSelector] < minWidth)
            {
                        widthChange = minWidth + (platformWidths[platformSelector]) +5f;
            }
            if (transform.position.x - widthChange < 5f && transform.position.x - widthChange > -5f)
            {
                widthChange = transform.position.x - 6f;

                if (transform.position.x - (platformWidths[platformSelector]) - 5f < minWidth)
                {
                    widthChange = transform.position.x + 6f;
                }

            }

            
            transform.position = new Vector3(widthChange, transform.position.y + distanceBetween, transform.position.z);
            playerTeleport = transform.position;
            //transform.position = new Vector3(transform.position.x + distanceBetween_1 + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);


            // Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            //thePlatform, transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
            }

            else if (Random.Range(0f,100f) < randomHwdThreshold)
            {
                theHwdGenerator.SpawnHwd(new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z));
            }

            else if (Random.Range(0f, 100f) < randomDiamondThreshold)
            {
                theDiamondGenerator.SpawnDiamond(new Vector3(transform.position.x + 1.5f + (platformWidths[platformSelector] / 2), transform.position.y + 1.2f, transform.position.z));
            }


                previousSelect = platformSelector;
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}

  public Vector3 getGeneratorPoint()
    {
        return generatorPointStart;
    }
    public Vector3 getPlayerTeleport()
    {
        return playerTeleport;
    }

}
