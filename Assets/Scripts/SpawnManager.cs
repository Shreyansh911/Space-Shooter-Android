using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float TimeBetweenSpwn = 2;
    [SerializeField] GameObject[] _enemy, _powerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int RandomEnemy = Random.Range(0, _enemy.Length);

            Vector2 RandomRange = new Vector2(Random.Range(2.5f, -2.5f), transform.position.y);

            yield return new WaitForSeconds(TimeBetweenSpwn);

            Instantiate(_enemy[RandomEnemy], RandomRange, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        while(true)
        {
            int RandomPowerUps = Random.Range(0, _powerUps.Length);

            Vector2 RandomRange = new Vector2(Random.Range(2.5f, -2.5f), transform.position.y);

            yield return new WaitForSeconds(Random.Range(8,10));

            Instantiate(_powerUps[RandomPowerUps], RandomRange, Quaternion.identity);
        }
    }
}
