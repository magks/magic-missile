using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolID {playerProjectile, enemyProjectile};

[System.Serializable]
public class ToBePooled
{
    public PoolID identifier;
    public GameObject poolItem;
    public int numPooled;
    [SerializeField]
    int _maxPooled;
    public int maxPooled { get { return _maxPooled; } }
}



public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool projectilePool;
    public List<ToBePooled> objectsToPool;
    Dictionary<PoolID, Queue<GameObject>> allPools;
    Dictionary<PoolID, (int,int)> objectCount;
    Dictionary<PoolID, GameObject> prototypeStore;

    // Start is called before the first frame update
    void Start()
    {
        projectilePool = this;
        allPools = new Dictionary<PoolID, Queue<GameObject>>();
        objectCount = new Dictionary<PoolID, (int,int)>();
        foreach(ToBePooled toPool in objectsToPool)
        {
            if (toPool.numPooled < toPool.maxPooled)
            {
                throw new System.ArgumentException("numPooled is less than maxPooled");
            }
            prototypeStore[toPool.identifier] = toPool.poolItem;
            allPools[toPool.identifier] = new Queue<GameObject>();
            for(int i = 0; i<toPool.numPooled; i++)
            {
                GameObject newObj = Instantiate(toPool.poolItem);
                newObj.transform.SetParent(projectilePool.transform);
                newObj.SetActive(false);
                allPools[toPool.identifier].Enqueue(newObj);
            }
            objectCount[toPool.identifier] = (allPools[toPool.identifier].Count, toPool.maxPooled) ;
        }
    }

    public bool hasObject(PoolID id)
    {
        return allPools.ContainsKey(id);
    }

    public void expandPool(PoolID poolTBE, int expandNum)
    {
        // How many to add?
        (int, int) countTuple = objectCount[poolTBE];
        int howMany = Mathf.Min(expandNum, countTuple.Item2-countTuple.Item1);
        GameObject toPool = prototypeStore[poolTBE];
        for(int i =0; i<howMany; i++)
        {
            GameObject newObj = Instantiate(toPool);
            newObj.transform.SetParent(projectilePool.transform);
            newObj.SetActive(false);
            allPools[poolTBE].Enqueue(newObj);
        }
        objectCount[poolTBE] = (countTuple.Item1 + howMany, countTuple.Item2);
    }

    public GameObject getPooledObject(PoolID id)
    {
        if(allPools.ContainsKey(id))
        {
            if(allPools[id].Count==0)
            {
                expandPool(id, 5);
            }
            if (allPools[id].Count == 0)
            {
                print("Reached pool limit");
                return null;
            }
            else
            {
                return allPools[id].Dequeue();
            }
        }
        else
        {
            throw new UnityException("That pool id does not exist.");
        }
    }

    public void returnPooledObject(PoolID id, GameObject obj)
    {
        obj.transform.SetParent(gameObject.transform);
        obj.SetActive(false);
        allPools[id].Enqueue(obj);
    }

}
