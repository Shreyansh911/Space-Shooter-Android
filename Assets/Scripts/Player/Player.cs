using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 10, _offset;
    [SerializeField] GameObject _laser, _shield;
    [SerializeField] GameObject _gameOverUI, _restartButton, _mainMenuButton;
    [SerializeField] TextMeshProUGUI _finalScore;

    public float Health = 100;
    public float Score = 0;

    PolygonCollider2D _collider;
    Touch _touch;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        _gameOverUI.SetActive(false);
        _restartButton.SetActive(false);
        _mainMenuButton.SetActive(false);
        _finalScore.gameObject.SetActive(false);

        StartCoroutine(SpawnBullets());

        _collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PcMovement();
        MobileMovement();

        if(Health <= 0)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;

            _finalScore.text = "Your Score: " + Score.ToString();

            _gameOverUI.SetActive(true);
            _restartButton.SetActive(true);
            _mainMenuButton.SetActive(true);
            _finalScore.gameObject.SetActive(true);
        }
    }

    void MobileMovement()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if(_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector2(transform.position.x + _touch.deltaPosition.x * 0.01f,
                                                 transform.position.y + _touch.deltaPosition.y * 0.01f);
            }
        }
    }

    void PcMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector2 Movement = new Vector2(HorizontalInput, VerticalInput);

        transform.Translate(Movement * Time.deltaTime * _speed);

        if(transform.position.x > 2.2f)
        {
            transform.position = new Vector2(2.2f, transform.position.y);
        }

        if (transform.position.x < -2.2f)
        {
            transform.position = new Vector2(-2.2f, transform.position.y);
        }

        if (transform.position.y > 3f)
        {
            transform.position = new Vector2(transform.position.x, 3f);
        }

        if (transform.position.y < -4.6f)
        {
            transform.position = new Vector2(transform.position.x, -4.6f);
        }
    }

    IEnumerator SpawnBullets()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(_laser, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy Laser")
        {
            Health -= other.GetComponent<EnemyLaser>().DamageToPlayer;
        }

        if(other.tag == "Enemy")
        {
            Health -= 50;
        }
    }

    public void ShieldIsActive()
    {
        _shield.SetActive(true);
        StartCoroutine(Shield());
    }

    IEnumerator Shield()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(5);
        _collider.enabled = true;
        _shield.SetActive(false);
    }
}
