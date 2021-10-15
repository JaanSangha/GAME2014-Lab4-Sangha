using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{

    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>(); // create queue

        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < bulletNumber; i++)
        {
            AddBullet();
        }
    }

    public GameObject GetBullet(Vector2 position)
    {
        if (bulletPool.Count < 1)
        {
            AddBullet();
            bulletNumber++;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject returned_bullet)
    {
        returned_bullet.SetActive(false);
        bulletPool.Enqueue(returned_bullet);
    }

    public void AddBullet()
    {
        var temp_bullet = Instantiate(bulletPrefab);
        temp_bullet.SetActive(false);
        temp_bullet.transform.parent = transform;
        bulletPool.Enqueue(temp_bullet);
    }
}
