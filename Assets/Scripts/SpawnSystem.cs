using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] places;
    public Transform player;

    public float timeBtwEnemys;
    private WaitForSeconds waitBtwEnemys;
    bool isStart = false;

    void Start()
    {
        waitBtwEnemys = new WaitForSeconds(timeBtwEnemys);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStart)
        {
            if (!col.CompareTag("Player"))
                return;
            isStart = true;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int rndmEnemy = Random.Range(0, enemys.Length);
            int rndmPlace = Random.Range(0, places.Length);

            var enemy = Instantiate(enemys[rndmEnemy], places[rndmPlace].position, Quaternion.identity);
            enemy.transform.SetParent(transform);

            yield return waitBtwEnemys;
        }
    }
}
