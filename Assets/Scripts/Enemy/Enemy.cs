using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _laser;
    [SerializeField] Vector3 _offset;
    [SerializeField] int _health;

    public float Speed;
    public float MinTimeToShoot, MaxTimeToShoot;
    public float ScoreOnDeath;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootLaser());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (_health <= 0)
        {
            Destroy(this.gameObject);

            FindObjectOfType<Player>().Score += ScoreOnDeath;
        }
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);

        if (transform.position.y < -5.5)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShootLaser()
    {
        while(true)
        {
            float TimeBetweenShooting = Random.Range(MinTimeToShoot, MaxTimeToShoot);

            yield return new WaitForSeconds(TimeBetweenShooting);
            Instantiate(_laser, transform.position + _offset, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player Laser" || other.tag == "Player")
        {
            _health -= 5;
        }
    }
}
