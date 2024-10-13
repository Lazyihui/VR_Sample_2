using System;
using UnityEngine;


public class InputContext {
    public InputEntity head;

    public InputEntity leftHand;

    public InputEntity rightHand;


    public XRIDefaultInputActions XRInput;
    public InputContext() {
        XRInput = new XRIDefaultInputActions();
        XRInput.Enable();

        head = new InputEntity();
        head.typeID = 0;
        head.id = 0;

        leftHand = new InputEntity();
        leftHand.typeID = 1;
        leftHand.id = 1;

        rightHand = new InputEntity();
        rightHand.typeID = 2;
        rightHand.id = 2;


    }
}