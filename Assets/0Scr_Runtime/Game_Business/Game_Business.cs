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


        RoleEntity role = ctx.Role_GetOwner();

        if (ctx.inputContext.leftHand.isPressAButton) {
            // 游戏状态进入飞机游戏状态


            AppUI.Panel_AClose(ctx.uiContext);

            RoleDomain.HandHit(ctx, role);

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
        ctx.cameraCore.GameraFollow(follow_target, new Vector2(0, 0), 0, face, dt);
        // 头的旋转
        RoleDomain.RoleHeadRotate(ctx, role, dt);
        RoleDomain.Move(ctx, role, ctx.inputContext.leftHand.moveAxis, dt);


        // ParticleEntity par = ctx.Particle_GetOwner();

        // ParticleDomain.Tick(ctx, par, dt);
    }
}