using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    public AssetContext assetContext;

    // repo 
    public RoleRepository roleRepository;

    public GameContext() {

        gameEntity = new GameEntity();

        assetContext = new AssetContext();

        // repo
        roleRepository = new RoleRepository();
    }

    public RoleEntity Role_GetOwner() {
        bool has = roleRepository.TryGet(gameEntity.roleOwnerID, out RoleEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Role_GetOwner: roleOwnerID not found");
            return null;
        }
        return entity;
    }
}