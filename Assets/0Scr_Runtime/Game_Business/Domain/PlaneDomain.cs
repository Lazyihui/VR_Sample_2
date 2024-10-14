using System;
using UnityEngine;


public static class PlaneDomain {


    public static PlaneEntity PlaneSpawn(GameContext ctx) {
        bool has = ctx.assetContext.entities.TryGetValue("Entity_Plane", out GameObject prefab);
        if (!has) {
            Debug.LogError("no");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlaneEntity entity = go.GetComponent<PlaneEntity>();

        entity.Ctor();

        entity.id = ctx.gameEntity.planeOwnerID;

        ctx.planeRepository.Add(entity);

        return entity;
    }

    public static void Face(GameContext ctx, PlaneEntity plane, Vector3 faceDir) {
        plane.transform.rotation = Quaternion.LookRotation(faceDir);
    }


    public static void MoveLeftRight(GameContext ctx, PlaneEntity plane, Vector2 moveAxis, float dt) {
        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();

        moveDir = plane.transform.rotation * moveDir;
        moveDir = moveDir * plane.moveSpeed * dt;
        plane.transform.position += moveDir;

    }

    public static void MoveUpDown(GameContext ctx, PlaneEntity plane, Vector2 moveAxis, float dt) {
        Vector3 moveDir = new Vector3(0, moveAxis.y, 0);
        moveDir.Normalize();

        moveDir = plane.transform.rotation * moveDir;
        moveDir = moveDir * plane.moveSpeed * dt;
        plane.transform.position += moveDir;

    }

    // public static void Move(GameContext ctx, RoleEntity role, PlaneEntity plane) {
    //     // 两个坐标一直等于一个差值
    //     Vector3 pos = new Vector3(0, 0, 3.5f);

    //     plane.transform.position = role.transform.position + pos;

    // }

}