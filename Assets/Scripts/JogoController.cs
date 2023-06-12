using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JogoController : MonoBehaviour
{
    public GameObject ball;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    public GameObject victoryMessage;
    public GameObject instructionMessage;
    public GameObject instructionMessage2;
    public GameObject beginMessage;

    public float restartDelay = 5f;
    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    public float timeLimit = 150f;
    public Text timeText;

    public AudioSource[] audioSources;

    public Starter starter;

    private BallController1 ballController;

    private Vector3 startingPosition;

    public ParticleSystem particleEffect;


    // Start is called before the first frame update
    void Start()
    {
        particleEffect.gameObject.SetActive(false);
        beginMessage.SetActive(true);
        instructionMessage.SetActive(true);
        instructionMessage2.SetActive(true);
        victoryMessage.SetActive(false);
        ballController = ball.GetComponent<BallController1>();
        startingPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timeLimit -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeLimit / 60);
            int seconds = Mathf.FloorToInt(timeLimit % 60);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            timeText.text = "Time: " + formattedTime;

            if (timeLimit <= 10f && !particleEffect.gameObject.activeSelf)
            {
                particleEffect.gameObject.SetActive(true);
            }

            if (timeLimit <= 1f)
            {
                StopAudio(2);
                started = false;
                PlayAudio(1);
                CheckEndGame();
            }
        }

        if (timeLimit <= 1f)
        {
            ballController.Stop();
            ball.transform.position = startingPosition;
            return;
        }

        if (started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayAudio(2);
            started = true;
            beginMessage.SetActive(false);
            instructionMessage.SetActive(false);
            instructionMessage2.SetActive(false);
            starter.StartCountdown();
        }
    }

    public void PlayAudio(int index)
    {
        if (index >= 0 && index < audioSources.Length)
        {
            audioSources[index].Play();
        }
    }

    public void StopAudio(int index)
    {
        if (index >= 0 && index < audioSources.Length)
        {
            audioSources[index].Stop();
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene("Menu");
    }

    public void CheckEndGame()
    {
        if (scoreRight > scoreLeft)
        {
            ShowVictoryMessage("PLAYER RIGHT WINS!");
            StartCoroutine(LoadSceneAfterDelay());
        }
        else if (scoreRight < scoreLeft)
        {
            ShowVictoryMessage("PLAYER LEFT WINS!");
            StartCoroutine(LoadSceneAfterDelay());
        }
        else
        {
            ShowVictoryMessage("DRAW!");
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    public void StartGame()
    {
        ballController.Go();
    }

    public void ScoreLeftGoal()
    {
        PlayAudio(0);
        Debug.Log("ScoreLeftGoal");
        scoreRight += 1;
        UpdateUI();
        ResetBall("Left");
        ShowVictoryMessage("Player Right Scores!");
    }

    public void ScoreRightGoal()
    {
        PlayAudio(0);
        Debug.Log("ScoreRightGoal");
        scoreLeft += 1;
        UpdateUI();
        ResetBall("Right");
        ShowVictoryMessage("Player Left Scores!");
    }

    private void UpdateUI()
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
    }

    private void ResetBall(string side)
    {
        ballController.Stop();
        ball.transform.position = startingPosition;
        ballController.Go();
    }

    private void ShowVictoryMessage(string message)
    {
        victoryMessage.SetActive(true);
        Text victoryText = victoryMessage.GetComponent<Text>();
        victoryText.text = message;

        RestartGame();
    }

    private void RestartGame()
    {
        StartCoroutine(DelayedRestart(restartDelay));
    }

    private IEnumerator DelayedRestart(float delay)
    {
        yield return new WaitForSeconds(delay);

        victoryMessage.SetActive(false);
    }
}
