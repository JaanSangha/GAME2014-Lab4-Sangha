using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public Queue<GameObject> playerBulletPool;
    public int bulletNumber; 
    public int playerBulletNumber;

    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>(); // create enemy queue
        playerBulletPool = new Queue<GameObject>(); // create player queue

        factory = GetComponent<BulletFactory>(); //reference to bullet factory

       // BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < bulletNumber; i++)
        {
            AddBullet();
        }
    }

    public GameObject GetBullet(Vector2 position, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;

        switch(type)
        {
            case BulletType.ENEMY:
                if (bulletPool.Count < 1)
                {
                    AddBullet();

                }

                temp_bullet = bulletPool.Dequeue();
                temp_bullet.transform.position = position;
                temp_bullet.SetActive(true);

                break;
            case BulletType.PLAYER:
                if (playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);

                }

                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = position;
                temp_bullet.SetActive(true);

                break;
        }

        return temp_bullet;

    }

    public void ReturnBullet(GameObject returned_bullet, BulletType type = BulletType.ENEMY)
    {
        returned_bullet.SetActive(false);

        switch (type)
        {
            case BulletType.ENEMY:
                bulletPool.Enqueue(returned_bullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returned_bullet);
                break;
        }
    }

    public void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = factory.createBullet(type);

        switch (type)
        {
            case BulletType.ENEMY:
                bulletPool.Enqueue(temp_bullet);
                bulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }
      
    }
}
