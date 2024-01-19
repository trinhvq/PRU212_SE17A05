using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    #region
    Vector3 mouseWorldPos;
    float speedX = 0f, speedY = 0f;
    Vector3 position;
    int isRight = 0;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        mouseWorldPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // if the left mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //get the mouse position if we click the mouse
            Vector3 mousePos = Input.mousePosition;
            //change mouse position to camera coordinates
            mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            // print out on the console window
            //print(mousePos.x);
            //Debug.Log(mousePos.x);
            //Debug.Log(mousePos.y);
            //print(mouseWorldPos.x);

            position = transform.localPosition;

            Vector3 scale = transform.localScale;
            //if(mouseWorldPos.x < position.x)
            //{
            //    if(isRight == 1)
            //    {
            //        scale.x *= -1f;
            //        transform.localScale = scale;
            //        isRight = 0;
            //    }
            //}
            //else
            //{
            //    if(isRight == 0)
            //    {
            //        scale.x *= -1f;
            //        transform.localScale = scale;
            //        isRight = 1;
            //    }
            //}
            if(mouseWorldPos.x < position.x)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (mouseWorldPos.x > position.x)
            {
                scale.x = -1.0f * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            

        }

        //move the game object to the mouse position
        position = transform.localPosition; // store the position of the game object

        
        if(Mathf.Abs(mouseWorldPos.x - position.x) > 0.1f || Mathf.Abs(mouseWorldPos.y - position.y) > 0.1f)
        {
            if (Mathf.Abs(mouseWorldPos.x - position.x) < 0.1f)
            {
                speedX = 0.0f;
                speedY = 0.05f;
            }
            else
            {
                float rate = Mathf.Abs((mouseWorldPos.y - position.y) / (mouseWorldPos.x - position.x));
                speedX = 0.1f;
                speedY = speedX * rate;
            }
            
        }
        else
        {
            speedX = 0f;
            speedY = 0f;

        }

        if(mouseWorldPos.x >= position.x)
        {
            position.x += speedX;
        }
        else
        {
            position.x -= speedX;
        }
        if (mouseWorldPos.y >= position.y)
        {
            position.y += speedY;
        }
        else
        {
            position.y -= speedY;
        }

        transform.localPosition = position;


    }
}
