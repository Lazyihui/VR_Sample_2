using System;
using UnityEngine;



public static class Game_Business {

    public static void Enter(GameContext ctx) {

        // ParticleEntity en = ParticleDomain.Spawn(ctx);
        // Debug.Log(en.id);

        RoleEntity onwer = RoleDomain.Spawn(ctx);
        ctx.gameEntity.roleOwnerID = onwer.id;


    }


    public static void EnterControllerPlane(GameContext ctx) {

        ctx.gameEntity.gameState = GameState.Game;

        // 进入控制飞机的也页面
        PlaneEntity plane = PlaneDomain.PlaneSpawn(ctx);
        ctx.gameEntity.planeOwnerID = plane.id;

        RoleEntity role = ctx.Role_GetOwner();

        RoleDomain.SetPosToZero(ctx, role);

        AppUI.Panel_AOpen(ctx.uiContext);



    }




    public static void PlaneTick(GameContext ctx, float dt) {

        InputCore.Tick(ctx.inputContext, dt);



        if (ctx.inputContext.leftHand.isPressAButton) {
            // 游戏状态进入飞机游戏状态

            RoleEntity role = ctx.Role_GetOwner();
            AppUI.Panel_AClose(ctx.uiContext);

            RoleDomain.HandHit(ctx, role);


            // TODO:不是这样写的要放在GameEntity里面
            ctx.inputContext.leftHand.isPressAButton = false;
        }



        Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;
        Vector3 right = ctx.cameraEntity.transform.right;
        Vector3 forward = ctx.cameraEntity.transform.forward;
        right = right * moveAxis.x;
        forward = forward * moveAxis.y;
        Vector3 moveDir = right + forward;
        moveDir.Normalize();

        moveAxis = new Vector2(moveDir.x, moveDir.z);

        PlaneEntity plane = ctx.Plane_GetOwner();
        PlaneDomain.MoveLeftRight(ctx, plane, moveAxis, dt);

        PlaneDomain.MoveUpDown(ctx, plane, ctx.inputContext.rightHand.moveAxis, dt);

        float rotateSpeed = 30f;
        const float DISTANCE = 5;

        float x = ctx.inputContext.rightHand.moveAxis.x * rotateSpeed * dt;


        if (x != 0) {
            ctx.cameraEntity.Round(plane.transform.position, DISTANCE, new Vector3(0, x, 0));
            PlaneDomain.Face(ctx, plane, ctx.cameraEntity.transform.forward);
        } else {
            Vector3 follow_target = plane.transform.position;
            Vector3 face = ctx.cameraEntity.transform.forward;
            ctx.cameraEntity.Stand_Follow(follow_target, DISTANCE, face, dt);
        }



    }







    static void PreTick(GameContext ctx, float dt) {


        InputCore.Tick(ctx.inputContext, dt);


        if (ctx.gameEntity.isLoginOpen == false) {
            ctx.gameEntity.LoginOpenTime += dt;

            if (ctx.gameEntity.LoginOpenTime > 3) {
                ctx.gameEntity.isLoginOpen = true;
                AppUI.Panel_LoginOpen(ctx.uiContext);
            }
        }

    }





    public static void Tick(GameContext ctx, float dt) {

        PreTick(ctx, dt);


        RoleEntity role = ctx.Role_GetOwner();

        //相机跟随
        Vector3 follow_target = role.head.transform.position;
        Vector3 face = role.head.transform.forward;
        ctx.cameraEntity.Stand_Follow(follow_target, 0, face, dt);
        // 头的旋转
        RoleDomain.RoleHeadRotate(ctx, role, dt);
        RoleDomain.Move(ctx, role, ctx.inputContext.leftHand.moveAxis, dt);


        // ParticleEntity par = ctx.Particle_GetOwner();

        // ParticleDomain.Tick(ctx, par, dt);
    }
}