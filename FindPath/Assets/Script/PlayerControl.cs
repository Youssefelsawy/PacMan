using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Vector3 speed;
    private Enemy player;
    private int score = 0;
    public bool onGround;
    public bool powerUp;
    public bool WrongPowerUp;

    public TMP_Text Score;
    public TMP_Text ScoreBar;

    public GameObject levelComplete;
    public GameObject enemy;
    public GameObject powerup;
    public GameObject restartButton;
    public GameObject wrongPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.hit && score < 70)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            if (powerUp) { speed = new Vector3(10, 0, 10); }
            else { speed = new Vector3(5, 0, 5); }
            
                transform.Translate(new Vector3(speed.x * Horizontal, 0, speed.z * Vertical) * Time.deltaTime, 0);        
        }

        if (score == 70)
        {
            Destroy(enemy);
            levelComplete.SetActive(true);
            restartButton.SetActive(true);
            player.scoreBar.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUp = true;
            powerup.SetActive(true);
            StartCoroutine(PowerUpCountDown());
        }

        else if (other.CompareTag("Wrong"))
        {
            WrongPowerUp = true;
            wrongPowerUp.SetActive(true);
            StartCoroutine(PowerUpCountDown());
        }

        else if (other.CompareTag("pts"))
        {
            Destroy(other);
            score++;
            Score.text = "Score: " + score;
            ScoreBar.text = "Your Score is: " + score;
        }

        else if (other.CompareTag("bouns"))
        {
            score += 5;
            Score.text = "Score: " + score;
            ScoreBar.text = "Your Score is: " + score;
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(5);
        powerUp = false;
        WrongPowerUp = false;
        powerup.SetActive(false);
        wrongPowerUp.SetActive(false);

    }

}