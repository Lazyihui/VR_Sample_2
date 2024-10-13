using System;
using UnityEngine;


public static class RoleDomain {
    public static RoleEntity Spawn(GameContext ctx) {
        bool has = ctx.assetContext.entities.TryGetValue("Entity_Role", out GameObject prefab);

        if (!has) {
            Debug.LogError("no");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity entity = go.GetComponent<RoleEntity>();


        entity.Ctor();

        ctx.roleRepository.Add(entity);

        return entity;
    }
    // 头旋转
    public static void RoleHeadRotate(GameContext ctx, RoleEntity role, float dt) {
        Vector3 rotateDir = ctx.inputContext.head.rotate * Vector3.forward;
        role.head.transform.rotation = Quaternion.LookRotation(rotateDir);
    }
    // 整个移动
    public static void Move(GameContext ctx, RoleEntity role, Vector2 moveAxis, float dt) {
        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();

        moveDir = role.transform.rotation * moveDir;
        moveDir = moveDir * role.speed * dt;
        role.transform.position += moveDir;


    }
}