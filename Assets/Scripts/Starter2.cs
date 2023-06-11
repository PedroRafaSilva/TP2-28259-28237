using UnityEngine;

public class Starter2 : MonoBehaviour
{
    private DoubleBallController gameController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<DoubleBallController>();
        animator = GetComponent<Animator>();
    }

    public void StartCountdown() {
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() {
        gameController.StartGame();
    }
}
