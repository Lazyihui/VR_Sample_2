using System;
using UnityEngine;



public static class Game_Business {

    public static void Enter(GameContext ctx) {

        ParticleEntity en = ParticleDomain.Spawn(ctx);
        // Debug.Log(en.id);

        RoleEntity onwer = RoleDomain.Spawn(ctx);
        ctx.gameEntity.roleOwnerID = onwer.id;

        AppUI.Panel_LoginOpen(ctx.uiContext);

    }

    static void PreTick(GameContext ctx, float dt) {
        InputCore.Tick(ctx.inputContext, dt);
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


        ParticleEntity par = ctx.Particle_GetOwner();

        ParticleDomain.Tick(ctx, par, dt);
    }
}