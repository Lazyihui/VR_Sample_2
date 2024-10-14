using System;

using System.Collections.Generic;



public class PlaneRepository {

    Dictionary<int, PlaneEntity> all;

    PlaneEntity[] temArray;

    public PlaneRepository() {
        all = new Dictionary<int, PlaneEntity>();
        temArray = new PlaneEntity[1000];
    }

    public void Add(PlaneEntity entity) {
        all.Add(entity.id, entity);
    }


    public bool TryGet(int id, out PlaneEntity entity) {
        return all.TryGetValue(id, out entity);
    }
    public void Remove(PlaneEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out PlaneEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new PlaneEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }







    //委托 Predicate<PlaneEntity> Action<>
    public PlaneEntity Find(Predicate<PlaneEntity> predicate) {
        foreach (PlaneEntity Plane in all.Values) {
            bool isMatch = predicate(Plane);

            if (isMatch) {
                return Plane;
            }
        }
        return null;
    }

}
