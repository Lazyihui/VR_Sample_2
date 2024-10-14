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



        // //相机跟随
        // Vector3 follow_target = role.head.transform.position;
        // Vector3 face = role.head.transform.forward;
        // ctx.cameraEntity.Stand_Follow(follow_target, new Vector2(0, 0), 0, face, dt);
        // 头的旋转
        // RoleDomain.RoleHeadRotate(ctx, role, dt);
        // RoleDomain.Move(ctx, role, ctx.inputContext.leftHand.moveAxis, dt);

        Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;


        PlaneEntity plane = ctx.Plane_GetOwner();
        PlaneDomain.MoveLeftRight(ctx, plane, ctx.inputContext.leftHand.moveAxis, dt);

        PlaneDomain.MoveUpDown(ctx, plane, ctx.inputContext.rightHand.moveAxis, dt);



        Vector3 follow_target = plane.transform.position;
        Vector3 face = plane.transform.forward;
        Vector3 offset = new Vector3(0, 0, -5);

        // ctx.cameraEntity.Stand_Follow(follow_target + offset, offset, 0, face, dt);
        // ctx.cameraEntity.cma_rotate(ctx.inputContext.head.rotate * Vector3.forward);
        float rotateSpeed = 30f;

        float x = ctx.inputContext.rightHand.moveAxis.x * rotateSpeed * dt;

        ctx.cameraEntity.Round(plane.transform.position, 5, new Vector3(0, x, 0));



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
        ctx.cameraEntity.Stand_Follow(follow_target, new Vector2(0, 0), 0, face, dt);
        // 头的旋转
        RoleDomain.RoleHeadRotate(ctx, role, dt);
        RoleDomain.Move(ctx, role, ctx.inputContext.leftHand.moveAxis, dt);


        // ParticleEntity par = ctx.Particle_GetOwner();

        // ParticleDomain.Tick(ctx, par, dt);
    }
}