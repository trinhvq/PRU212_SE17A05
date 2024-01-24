using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    #region Fields
    Vector3 mouseWorldPos;
    float speedX = 0f;
    float speedY = 0f;
    Vector3 position;
    int isRight = -1;
    int directionX = 1, directionY = 1;
    float speed = 10.0f;
    Vector3 scale;

    SpriteRenderer spriteRenderer;

    float screenLeft, screenRight, screenTop, screenBottom;
    float colliderHalfWidth, colliderHalfHeight;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        mouseWorldPos = transform.localPosition;
        position = transform.localPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();

        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            Screen.width, Screen.height, screenZ);

        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenBottom = lowerLeftCornerWorld.y;
        screenTop = upperRightCornerWorld.y;

        //print(screenLeft + ", " + screenRight);

        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        Vector3 diff = collider2D.bounds.max - collider2D.bounds.min;
        colliderHalfWidth = diff.x / 2.0f;
        colliderHalfHeight = diff.y / 2.0f;


    }

    // Update is called once per frame
    void Update()
    {
        speedX = 0f;
        speedY = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 mousePos = Input.mousePosition;
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print(mouseWorldPos.x + ", " + mouseWorldPos.y);
            position = transform.localPosition;
            Vector3 scale = transform.localScale;
            if (mouseWorldPos.x > position.x && isRight == -1)
            {
                scale.x *= -1;
                isRight = 1;
            }
            if (mouseWorldPos.x < position.x && isRight == 1)
            {
                scale.x *= -1;
                isRight = -1;
            }
            transform.localScale = scale;

            if (mouseWorldPos.x > position.x)
            {
                directionX = 1;
            }
            else
            {
                directionX = -1;
            }

            if (mouseWorldPos.y > position.y)
            {
                directionY = 1;
            }
            else
            {
                directionY = -1;
            }

            //print(directionX + ", " + directionY);

        }

        position = transform.localPosition;
        if (Mathf.Abs(mouseWorldPos.x - position.x) > 0.1f || Mathf.Abs(mouseWorldPos.y - position.y) > 0.1)
        {
            if (Mathf.Abs(mouseWorldPos.x - position.x) < 0.1f)
            {
                speedX = 0f;
                speedY = 0.03f;
            }
            else
            {
                float rate = Mathf.Abs((mouseWorldPos.y - position.y) / (mouseWorldPos.x - position.x));
                speedX = 0.1f;
                speedY = speedX * rate;
                //print("here");
            }

        }

        position.x += speedX * directionX ;
        position.y += speedY * directionY ;
        transform.localPosition = position;


        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = Vector3.MoveTowards(transform.position, mouseWorldPos, 10f*Time.deltaTime);
        //}




        if (Input.GetButton("Horizontal"))
        {
            scale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0 && isRight == 1)
            {
                //spriteRenderer.flipX = false;
                scale.x *= -1f;
                isRight = -1;
            }
            if (Input.GetAxis("Horizontal") > 0 && isRight == -1)
            {
                //spriteRenderer.flipX = true;
                scale.x *= -1f;
                isRight = 1;
            }
            transform.localScale = scale;

            mouseWorldPos = transform.localPosition;

            position = transform.localPosition;
            //Debug.Log("test for left and right keys");
            //Debug.Log(Input.GetAxis("Horizontal"));
            position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.localPosition = position;
        }

        if (Input.GetButton("Vertical"))
        {
            mouseWorldPos = transform.localPosition;
            position = transform.localPosition;
            //Debug.Log("test for left and right keys");
            //Debug.Log(Input.GetAxis("Vertical"));
            position.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.localPosition = position;
        }

        ClampInScreen();

    }

    void ClampInScreen()
    {
        Vector3 position = transform.position;
        if (position.x - colliderHalfWidth < screenLeft)
        {
            position.x = screenLeft + colliderHalfWidth;
        }
        if (position.x + colliderHalfWidth > screenRight)
        {
            position.x = screenRight - colliderHalfWidth;
        }
        if (position.y + colliderHalfHeight > screenTop)
        {
            position.y = screenTop - colliderHalfHeight;
        }
        if (position.y - colliderHalfHeight < screenBottom)
        {
            position.y = screenBottom + colliderHalfHeight;
        }
        transform.position = position;
    }
}
