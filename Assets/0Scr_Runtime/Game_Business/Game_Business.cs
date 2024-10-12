using System;
using UnityEngine;



public static class Game_Business {

    public static void Enter(GameContext ctx) {
        RoleEntity onwer = RoleDomain.Spawn(ctx);
        ctx.gameEntity.roleOwnerID = onwer.id;

    }


    public static void TicK() {

    }
}