using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2d;
    [SerializeField]
    float maxF = 10f;
    [SerializeField]
    float minF = 5f;
    int collisionCount = 0;

    SpriteRenderer spriteRenderer;
    Color color;

    TeddySpawner teddySpawner;
    static int availableTeddy, destroyedTeddy = 0;
    #endregion

    #region Properties
    public int DestroyTeddy
    {
        get { return destroyedTeddy; }
        set { destroyedTeddy = value; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 force = new Vector2(5f, 5f);

        //float maxF = 10f, minF = 5f;
        float maxA = 360, minA = 0;
        // create magnitude and angle of the force randomly
        float magnitude = Random.Range(minF, maxF);
        float angle = Random.Range(minA, maxA) * Mathf.PI / 180f;
        Vector2 force = new Vector2(0f, 0f);
        force.x = magnitude * Mathf.Cos(angle);
        force.y = magnitude * Mathf.Sin(angle);

        // access the Rigidbody2D component assigned to the game object
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(force, ForceMode2D.Impulse);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        color = spriteRenderer.color; // store the color of sprite

        teddySpawner = GameObject.Find("Main Camera").GetComponent<TeddySpawner>();

    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.name == "YellowTeddyBear")
        {
            collisionCount += 1;
            //Debug.Log("collision count = " + collisionCount);

            color.a -= 0.1f;
            spriteRenderer.color = color;

            if (collisionCount == 7)
            {
                Destroy(gameObject, 1);
                destroyedTeddy += 1;
                //print("destroyed teddy bears are " + destroyedTeddy);
                availableTeddy = teddySpawner.NumSpawned - destroyedTeddy;
                //print("available teddy bears are " + availableTeddy);
            }
        }

        // if the gameobject collides with green teddy bear,
        // destroy the game object
        if(collision.gameObject.name == "GreenTeddyBear")
        {
            Destroy(gameObject);
            destroyedTeddy += 1;
            //print("destroyed teddy bears are " + destroyedTeddy);
            availableTeddy = teddySpawner.NumSpawned - destroyedTeddy;
            //print("available teddy bears are " + availableTeddy);
        }
    }
        
}
