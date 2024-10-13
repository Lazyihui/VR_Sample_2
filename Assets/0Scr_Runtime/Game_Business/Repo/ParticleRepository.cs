using System;

using System.Collections.Generic;



public class ParticleRepository {

    Dictionary<int, ParticleEntity> all;

    ParticleEntity[] temArray;

    public ParticleRepository() {
        all = new Dictionary<int, ParticleEntity>();
        temArray = new ParticleEntity[1000];
    }

    public void Add(ParticleEntity entity) {
        all.Add(entity.id, entity);
    }


    public bool TryGet(int id, out ParticleEntity entity) {
        return all.TryGetValue(id, out entity);
    }
    public void Remove(ParticleEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out ParticleEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new ParticleEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }







    //委托 Predicate<ParticleEntity> Action<>
    public ParticleEntity Find(Predicate<ParticleEntity> predicate) {
        foreach (ParticleEntity Particle in all.Values) {
            bool isMatch = predicate(Particle);

            if (isMatch) {
                return Particle;
            }
        }
        return null;
    }

}
