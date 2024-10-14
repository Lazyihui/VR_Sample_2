using System;
using UnityEngine;


public static class InputCore {



    public static void Tick(InputContext ctx, float dt) {

        // 得到head的旋转
        {
            Quaternion quat = ctx.XRInput.XRIHead.Rotation.ReadValue<Quaternion>();
            Vector3 fwd = quat * Vector3.forward;
            ctx.head.rotate = quat;
        }
        // 得到左手的移动[-1,1]
        {
            Vector2 moveAxis = ctx.XRInput.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
            ctx.leftHand.moveAxis = moveAxis;

            Vector2 RightmoveAxis = ctx.XRInput.XRIRightHandLocomotion.Move.ReadValue<Vector2>();
            ctx.rightHand.moveAxis = RightmoveAxis;

            //   角速度  距离  moveAxis.x*0.5f*dt;


        }
        // {
        //     Vector2 moveAxis = ctx.XRInput.XRIRightHandLocomotion.Move.ReadValue<Vector2>();
        //     ctx.rightHand.moveAxis = moveAxis;
        //     Debug.Log(moveAxis);
        // }

        // 按下A键
        {
            float isPress = ctx.XRInput.XRILeftHandInteraction.AButton.ReadValue<float>();
            if (isPress > 0.5f) {
                ctx.leftHand.isPressAButton = true;
            }


        }
    }


}