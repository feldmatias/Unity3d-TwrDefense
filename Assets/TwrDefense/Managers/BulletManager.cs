using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BulletData
{
    public BulletType bulletType;
    public GameObject bulletPrefab;
    public int initialCount = 50;

    [HideInInspector]
    public List<Bullet> bulletList;
}

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    public BulletData[] bullets;
    public Transform bulletHolder;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        InitializeBullets();
    }

    private void InitializeBullets()
    {
        foreach (var bullet in bullets)
        {
            bullet.bulletList = new List<Bullet>();
            for (int i = 0; i < bullet.initialCount; i++)
            {
                InstantiateBullet(bullet.bulletPrefab, bullet.bulletList);
            }
        }
    }

    private Bullet InstantiateBullet(GameObject prefab, List<Bullet> list, bool active = false)
    {
        var bulletInstance = Instantiate(prefab, bulletHolder);
        bulletInstance.SetActive(active);
        var bullet = bulletInstance.GetComponent<Bullet>();
        list.Add(bullet);
        return bullet;
    }

    public Bullet GetBullet(BulletType bulletType)
    {
        var data = GetBulletData(bulletType);
        foreach (var bullet in data.bulletList)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        return InstantiateBullet(data.bulletPrefab, data.bulletList, true);
    }

    private BulletData GetBulletData(BulletType bulletType)
    {
        foreach (var data in bullets)
        {
            if (data.bulletType == bulletType)
            {
                return data;
            }
        }

        return null;
    }
}
