using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointingManager : MonoBehaviour
{
    public PointingTarget _target;
    public Text scoreBoard;

    void Start()
    {
        InvokeRepeating("GenerateTarget", 1f, 1f);
    }


    void Update()
    {
        scoreBoard.text = "POINT: " + SettingOfPointing.score.ToString();
    }

    private void GenerateTarget()
    {
        var newTarget = Instantiate(_target);
        float x = Random.Range(-5f / 2, 5f / 2);
        float y = Random.Range(-5f * 9 / 32f, 5f * 9 / 32f);
        newTarget.SetPosition(x, y);
    }
}
