using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingTarget : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

        if (IsTouched())
        {
            Destroy(this.gameObject);
        }

    }

    public void SetPosition(float x, float y)
    {
        var pos = this.transform.position;
        pos.x = x;
        pos.y = x;

        this.transform.position = pos;

    }

    private void OnDestroy()
    {
        SettingOfPointing.score++;
    }

    private bool IsTouched()
    {
        GameObject touchedGameObject = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
        }
        else if (!Input.GetMouseButton(0))
        {
            return false;
        }
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d) touchedGameObject = hit2d.transform.gameObject;

        if (touchedGameObject == null) return false;



        return touchedGameObject == this.gameObject;

    }
}
