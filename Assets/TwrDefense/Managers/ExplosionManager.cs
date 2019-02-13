using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public static ExplosionManager Instance;

    public GameObject explosionPrefab;
    public Transform explosionHolder;
    public int numberOfExplosions = 10;

    private List<GameObject> explosions;
    
    void Awake()
    {
        Instance = this;
        explosions = new List<GameObject>();

        for (int i = 0; i < numberOfExplosions; i++)
        {
            InstantiateExplosion();
        }
    }

    
    public void MakeExplosion(Vector3 position)
    {
        var explosion = GetExplosion();
        explosion.transform.position = position;
        explosion.SetActive(true);

        StartCoroutine(DisableExplosion(explosion));
    }

    private IEnumerator DisableExplosion(GameObject explosion)
    {
        yield return new WaitForSeconds(3);
        explosion.SetActive(false);
    }

    private GameObject GetExplosion()
    {
        foreach (var explosion in explosions)
        {
            if (!explosion.activeSelf)
            {
                return explosion;
            }
        }

        return InstantiateExplosion();
    }

    private GameObject InstantiateExplosion()
    {
        var explosion = Instantiate(explosionPrefab, explosionHolder);
        explosion.SetActive(false);
        explosions.Add(explosion);
        return explosion;
    }
}
