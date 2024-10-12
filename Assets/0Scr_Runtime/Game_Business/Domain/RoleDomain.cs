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
        Vector3 rotateDir = ctx.inputCore.GetHeadRotate() * Vector3.forward;
        role.head.transform.rotation = Quaternion.LookRotation(rotateDir);
        
    }
}