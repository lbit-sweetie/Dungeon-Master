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

    public int countEnemies;
    public int amoutAddCountEnemy;
    private int alreadySpawned;
    [SerializeField] private int wave = 0;
    public float delayBetweenWaves;
    public StartGame sg;

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
            StartCoroutine(SpawnWaves());
        }
    }

    //IEnumerator Spawn()
    //{
    //    while (true)
    //    {
    //        int rndmEnemy = Random.Range(0, enemys.Length);
    //        int rndmPlace = Random.Range(0, places.Length);

    //        var enemy = Instantiate(enemys[rndmEnemy], places[rndmPlace].position, Quaternion.identity);
    //        enemy.transform.SetParent(transform);

    //        yield return waitBtwEnemys;
    //    }
    //}

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (countEnemies >= alreadySpawned)
            {
                if (transform.childCount <= 0)
                {
                    wave++;
                    countEnemies = 0;
                    alreadySpawned += amoutAddCountEnemy;
                    sg.TextAnim("Wave " + wave.ToString());
                    yield return new WaitForSeconds(delayBetweenWaves);
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                var a = Instantiate(enemys[UnityEngine.Random.Range(0, enemys.Length)],
                    places[UnityEngine.Random.Range(0, places.Length)].transform.position,
                    Quaternion.identity);
                a.transform.SetParent(transform);
                countEnemies++;
                yield return waitBtwEnemys;
            }
        }
    }
}
