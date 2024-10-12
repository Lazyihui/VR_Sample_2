using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    public AssetContext assetContext;

    public CameraCore cameraCore;

    public XRIDefaultInputActions inputAction;

    public InputCore inputCore;

    // repo 
    public RoleRepository roleRepository;

    public GameContext() {

        gameEntity = new GameEntity();

        assetContext = new AssetContext();
        cameraCore = new CameraCore();
        
        inputAction = new XRIDefaultInputActions();
        inputCore = new InputCore();
        
        

        // repo
        roleRepository = new RoleRepository();
    }

    public void Inject(Camera camera) {
        cameraCore.Inject(camera);
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