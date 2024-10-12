using System;
using UnityEngine;



public static class Game_Business {

    public static void Enter(GameContext ctx) {
        RoleEntity onwer = RoleDomain.Spawn(ctx);
        ctx.gameEntity.roleOwnerID = onwer.id;

    }


    public static void Tick(GameContext ctx, float dt) {
        RoleEntity role = ctx.Role_GetOwner();

 
        Vector3 follow_target = role.head.transform.position;

        Vector3 face = role.head.transform.forward;


        ctx.cameraCore.GameraFollow(follow_target,new Vector2(0,0),0,face,dt);


    }
}