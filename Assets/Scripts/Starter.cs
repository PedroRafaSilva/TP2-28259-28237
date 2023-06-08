using UnityEngine;

public class Starter : MonoBehaviour
{
    private JogoController gameController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<JogoController>();
        animator = GetComponent<Animator>();
    }

    public void StartCountdown() {
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() {
        gameController.StartGame();
    }
}
