using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _healthText, _ScoreText;
    [SerializeField] GameObject _pauseUI, _restartButton, _mainMenuButton, _startButton;

    Player _player;
    Ads _ads;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _ads = GameObject.Find("Ads Manager").GetComponent<Ads>();
        _startButton.SetActive(true);
        _pauseUI.SetActive(false);
        _restartButton.SetActive(false);
        _mainMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _healthText.text = "Health:" + _player.Health.ToString();
        _ScoreText.text = "Score:" + _player.Score.ToString();

        if(_player.Health <= 0)
        {
            _healthText.text = "Health:" + 0.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _ads.ShowBanner = false;
        }
        else
        {
            _ads.ShowBanner = true;
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
        _restartButton.SetActive(true);
        _mainMenuButton.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
        _restartButton.SetActive(false);
        _mainMenuButton.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        _startButton.SetActive(false);
    }
}
