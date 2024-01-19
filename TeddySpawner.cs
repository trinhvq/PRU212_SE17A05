using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddySpawner : MonoBehaviour
{
    #region Fields
    float spawnerTime = 0;
    [SerializeField]
    GameObject yellowTeddyPrefab;

    int numSpawned = 1; // one yellow teddy bear exists already
    TeddyBear teddyBear;

    #endregion

    #region Properties

    public int NumSpawned
    {
        get { return numSpawned; }
        set { numSpawned = value; }
    }

    #endregion
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

        spawnerTime += Time.deltaTime;
        if(spawnerTime > 5f)
        {
            //print(spawnerTime);
            Vector3 position = new Vector3(3, 0, 0);
            Instantiate(yellowTeddyPrefab, position, Quaternion.identity);
            numSpawned += 1;
            //print("the spawned Yellow Teddy Bears are " + numSpawned);
            spawnerTime = 0;
        }
    }
}
