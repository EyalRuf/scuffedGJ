using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour
{
    const string P1_H_AXIS_NAME = "P1Horizontal";
    const string P1_V_AXIS_NAME = "P1Vertical";
    const string P1_FIRE1_AXIS_NAME = "P1Fire1";
    const string P1_FIRE2_AXIS_NAME = "P1Fire2";
    const string P1_FIRE3_AXIS_NAME = "P1Fire3";

    const string P2_H_AXIS_NAME = "P2Horizontal";
    const string P2_V_AXIS_NAME = "P2Vertical";
    const string P2_FIRE1_AXIS_NAME = "P2Fire1";
    const string P2_FIRE2_AXIS_NAME = "P2Fire2";
    const string P2_FIRE3_AXIS_NAME = "P2Fire3";

    public bool isP1 = true;
    public Vector2 movementInput = Vector2.zero;
    public bool craft = false;
    public bool attack = false;
    public bool slap = false;

    string hAxisName;
    string vAxisName;
    string fire1AxisName;
    string fire2AxisName;
    string fire3AxisName;

    void Start()
    {
        hAxisName = isP1 ? P1_H_AXIS_NAME : P2_H_AXIS_NAME;
        vAxisName = isP1 ? P1_V_AXIS_NAME : P2_V_AXIS_NAME;
        fire1AxisName = isP1 ? P1_FIRE1_AXIS_NAME : P2_FIRE1_AXIS_NAME;
        fire2AxisName = isP1 ? P1_FIRE2_AXIS_NAME : P2_FIRE2_AXIS_NAME;
        fire3AxisName = isP1 ? P1_FIRE3_AXIS_NAME : P2_FIRE3_AXIS_NAME;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector2(Math.Abs(Input.GetAxis(hAxisName)) > 0.5f ? Input.GetAxis(hAxisName) : 0,
            Math.Abs(Input.GetAxis(vAxisName)) > 0.5f ? Input.GetAxis(vAxisName) : 0);

        craft = Input.GetAxis(fire1AxisName) == 1f;
        attack = Input.GetAxis(fire2AxisName) == 1f;
        slap = Input.GetAxis(fire3AxisName) == 1f;
    }
}
