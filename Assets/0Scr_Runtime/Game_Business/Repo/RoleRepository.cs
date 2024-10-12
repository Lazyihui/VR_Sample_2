using System;

using System.Collections.Generic;



public class RoleRepository {

    Dictionary<int, RoleEntity> all;

    RoleEntity[] temArray;

    public RoleRepository() {
        all = new Dictionary<int, RoleEntity>();
        temArray = new RoleEntity[1000];
    }

    public void Add(RoleEntity entity) {
        all.Add(entity.id, entity);
    }


    public bool TryGet(int id, out RoleEntity entity) {
        return all.TryGetValue(id, out entity);
    }
    public void Remove(RoleEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out RoleEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new RoleEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }







    //委托 Predicate<RoleEntity> Action<>
    public RoleEntity Find(Predicate<RoleEntity> predicate) {
        foreach (RoleEntity Role in all.Values) {
            bool isMatch = predicate(Role);

            if (isMatch) {
                return Role;
            }
        }
        return null;
    }

}
