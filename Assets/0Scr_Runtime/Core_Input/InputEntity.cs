using System;
using UnityEngine;


public class InputEntity {
    public int id;

    public int typeID;

    public Quaternion rotate;

    public Vector3 pos;

    public Vector2 moveAxis;

    public bool isPressAButton;

    public bool isTrigger;

    public InputEntity() {
        moveAxis = Vector2.zero;
        pos = Vector2.zero;
        isPressAButton = false;
        isTrigger = false;
    }
}