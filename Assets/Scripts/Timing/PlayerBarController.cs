using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarController : MonoBehaviour
{
    public GameObject Gage, highGage, middleGage;
    private float gageLeft, gageRight;
    private float highGageLeft, highGageRight;
    private float middleGageLeft, middleGageRight;
    private float dx;
    private bool isMoving;
    void Start()
    {
        Application.targetFrameRate = 60;

        var gageWidth = Gage.transform.lossyScale.x;
        gageLeft = -gageWidth / 2;
        gageRight = gageWidth / 2;

        var highGageWidth = highGage.transform.lossyScale.x;
        highGageLeft = -highGageWidth / 2;
        highGageRight = highGageWidth / 2;

        var middleGageWidth = middleGage.transform.lossyScale.x;
        middleGageLeft = -middleGage.transform.lossyScale.x / 2;
        middleGageRight = middleGage.transform.lossyScale.x / 2;

        dx = 0.2f;
        isMoving = true;

    }


    void Update()
    {

        var pos = this.transform.position;
        var width = this.transform.lossyScale.x;
        var playerBarLeft = pos.x - width / 2;
        var playerBarRight = pos.x + width / 2;


        if (isMoving)
        {
            transform.Translate(dx, 0, 0);

            pos = this.transform.position;
            playerBarLeft = pos.x - width / 2;
            playerBarRight = pos.x + width / 2;

            if (playerBarRight > gageRight || playerBarLeft < gageLeft)
            {
                pos.x = playerBarRight - width / 2;
                this.transform.position = pos;
                dx = -dx;
            }

        }
        else
        {


            if (playerBarRight > highGageLeft && playerBarLeft < highGageRight)
            {
                Debug.Log("high");
            }
            else if (playerBarRight > middleGageLeft && playerBarLeft < middleGageRight)
            {
                Debug.Log("middle");
            }
            else
            {
                Debug.Log("low");
            }

        }

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            isMoving = false;
        }

    }

}
