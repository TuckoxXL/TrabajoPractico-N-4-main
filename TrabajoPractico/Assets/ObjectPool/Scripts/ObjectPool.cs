using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    public enum objcetType
    {
        single,
        dual,
        catapult,
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> bulletList;
    public objcetType objcetype = objcetType.single;


    private static ObjectPool instance;
    public static ObjectPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        AddBulletToPool(poolSize);
        listType();
    }

    private void AddBulletToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    private void listType()
    {
        if(objcetype == objcetType.single)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public GameObject RequestBullet()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeSelf)
            {
                bulletList[i].SetActive(true);
                return bulletList[i];
            }
        }
        return null;
    }
}
