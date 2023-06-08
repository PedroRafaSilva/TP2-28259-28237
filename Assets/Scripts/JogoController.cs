using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogoController : MonoBehaviour
{
    public GameObject ball;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public GameObject victoryMessage; // Referência ao objeto que exibirá a mensagem de vitória
    public GameObject beginMessage; // Referência ao objeto que exibirá a mensagem de vitória
    public float restartDelay = 1f; // Tempo de atraso antes de reiniciar o jogo
    private bool started = false;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    public AudioSource soundEffect;

    public Starter starter;

    private BallController1 ballController;

    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.beginMessage.SetActive(true);
        this.victoryMessage.SetActive(false);
        this.ballController = this.ball.GetComponent<BallController1>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.beginMessage.SetActive(false);
            this.starter.StartCountdown();
        }
    }


    public void StartGame()
    {
        this.ballController.Go();
    }

    public void ScoreLeftGoal()
    {
        soundEffect.Play();
        Debug.Log("ScoreLeftGoal");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
        ShowVictoryMessage("Player Left Wins!"); // Exibe a mensagem de vitória
    }

        public void ScoreRightGoal()
        {
            soundEffect.Play();
            Debug.Log("ScoreRightGoal");
            this.scoreLeft += 1;
            UpdateUI();
            ResetBall();
            ShowVictoryMessage("Player Right Wins!"); // Exibe a mensagem de vitória
        }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballController.Go();
    }

    private void ShowVictoryMessage(string message)
    {
        victoryMessage.SetActive(true); // Ativa o objeto que exibe a mensagem de vitória
        Text victoryText = victoryMessage.GetComponent<Text>();
        victoryText.text = message;

        RestartGame(); // Reinicia o jogo após exibir a mensagem de vitória
    }

    private void RestartGame()
    {
        StartCoroutine(DelayedRestart(restartDelay));
    }

    private IEnumerator DelayedRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
    
        UpdateUI();
        ResetBall();
        victoryMessage.SetActive(false); // Desativa o objeto da mensagem de vitória
    }
}
