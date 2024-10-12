using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class AssetContext {

    public Dictionary<string, GameObject> entities;

    public AsyncOperationHandle entityPtr;


    public AssetContext() {
        entities = new Dictionary<string, GameObject>();
    }

    public bool TryGetEntity(string name, GameObject entity) {
        return entities.TryGetValue(name, out entity);
    }
}
