using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBar : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        var pos = this.transform.position;
        pos.x = GetTouchPosition().x;
        this.transform.position = pos;
    }

    private Vector3 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var pos = Camera.main.ScreenToWorldPoint(touch.position);
            return pos;
        }

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
