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

    public GameObject victoryMessage; // Referência ao objeto que exibirá a mensagem de vitória
    public GameObject instructionMessage; 
    public GameObject instructionMessage2; 
    public GameObject beginMessage; // Referência ao objeto que exibirá a mensagem de vitória

    public float restartDelay = 5f; // Tempo de atraso antes de reiniciar o jogo
    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    public float tempoLimite = 1200f; // Tempo limite de 60 segundos
    public Text textoTempoLimite;
    public AudioSource[] audioSources;

    public Starter starter;

    private BallController1 ballController;

    private Vector3 startingPosition;
    private Vector3 startingPosition2;

    public ParticleSystem particleEffect; // Reference to the particle system component



    // Start is called before the first frame update
    void Start()
    {
        particleEffect.gameObject.SetActive(false);
        this.beginMessage.SetActive(true);
        this.instructionMessage.SetActive(true);
        this.instructionMessage2.SetActive(true);
        this.victoryMessage.SetActive(false);
        this.ballController = this.ball.GetComponent<BallController1>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started)
        {
            
            tempoLimite -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempoLimite / 60);
            int segundos = Mathf.FloorToInt(tempoLimite % 60); // Substitua "%" por "/"

            // Formata o tempo como "mm:ss"
            string tempoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);

            // Atualiza o texto com o tempo formatado
            textoTempoLimite.text = "Time: " + tempoFormatado;

            if (tempoLimite <= 10f && !particleEffect.gameObject.activeSelf)
            {
                particleEffect.gameObject.SetActive(true);
            }


            if (tempoLimite <= 1f)
            {
                StopAudio(2);
                this.started = false;
                PlayAudio(1);
                CheckEndGame();
            }
        }

        if (tempoLimite <= 1f)
            {
                this.ballController.Stop();
                this.ball.transform.position = this.startingPosition;  
                return;
            }

        if (this.started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayAudio(2);
            this.started = true;
            this.beginMessage.SetActive(false);
            this.instructionMessage.SetActive(false);
            this.instructionMessage2.SetActive(false);
            this.starter.StartCountdown();
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
        this.ballController.Go();
    }

    public void ScoreLeftGoal()
    {
        PlayAudio(0);
        Debug.Log("ScoreLeftGoal");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall("Left");
        ShowVictoryMessage("Player Left Scores!"); // Exibe a mensagem de vitória
    }

    public void ScoreRightGoal()
    {
        PlayAudio(0);
        Debug.Log("ScoreRightGoal");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall("Right");
        ShowVictoryMessage("Player Right Scores!"); // Exibe a mensagem de vitória
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall(string side)
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

        victoryMessage.SetActive(false); // Desativa o objeto da mensagem de vitória
    }
}
