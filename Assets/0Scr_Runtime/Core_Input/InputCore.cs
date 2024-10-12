using System;
using UnityEngine;


public class InputCore {
    public InputEntity head;

    public InputEntity leftHand;

    public InputEntity rightHand;

    public InputCore() {
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


    public void Tick(GameContext ctx, float dt) {

        // 得到head的旋转
        {
            Quaternion quat = ctx.inputAction.XRIHead.Rotation.ReadValue<Quaternion>();
            Vector3 fwd = quat * Vector3.forward;
            head.rotate = quat;
        }
    }

    public Quaternion GetHeadRotate() {
        Debug.Log(head.rotate);
        return head.rotate;
    }
}