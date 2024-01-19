using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    Vector3 position;
    Vector3 scale;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        position = transform.position;
        print(position.x);
        print(position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // stop at (2, 3)
        if(position.x <= 2f)
        {
            position.x += 0.02f;
            position.y += 0.03f;
            transform.position = position;
        }

        if(position.x > 2)
        {
            if (scale.x > 2)
            {
                direction = -1;
            }
            if (scale.x < 1)
            {
                direction = 1;
            }
            scale.x += 0.005f * direction;
            scale.y += 0.005f * direction;
            transform.localScale = scale;
        }
        
        
    }
}
