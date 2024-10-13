using System;

using System.Collections.Generic;



public class PointRepository {

    Dictionary<int, PointEntity> all;

    PointEntity[] temArray;

    public PointRepository() {
        all = new Dictionary<int, PointEntity>();
        temArray = new PointEntity[1000];
    }

    public void Add(PointEntity entity) {
        all.Add(entity.id, entity);
    }


    public bool TryGet(int id, out PointEntity entity) {
        return all.TryGetValue(id, out entity);
    }
    public void Remove(PointEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out PointEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new PointEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }







    //委托 Predicate<PointEntity> Action<>
    public PointEntity Find(Predicate<PointEntity> predicate) {
        foreach (PointEntity Point in all.Values) {
            bool isMatch = predicate(Point);

            if (isMatch) {
                return Point;
            }
        }
        return null;
    }

}
