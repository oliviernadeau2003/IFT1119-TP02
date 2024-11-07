using TMPro;
using UnityEngine;

public class BallScriptJcJ : MonoBehaviour
{
    Transform Ball;
    Rigidbody2D Rb_Ball;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    float speed = 10f;
    float goalPositionA = -10f;
    float goalPositionB = 10f;

    public TextMeshPro TMP_Score;
    int Initial_Score = 0;
    int MaxScore = 5;
    int PlayerA_Score;
    int PlayerB_Score;

    public GameObject GameMenu;
    public GameObject Current_Game;

    void Awake()
    {
        Ball = this.gameObject.transform;
        Rb_Ball = Ball.GetComponent<Rigidbody2D>();

        audioSource = Ball.GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        PlayerA_Score = Initial_Score;
        PlayerB_Score = Initial_Score;
        TMP_Score.text = PlayerA_Score.ToString() + ":" + PlayerB_Score.ToString();

        // Reset speed
        speed = 10f;

        // Pulse on game start
        Rb_Ball.AddForce(Vector2.one * speed, ForceMode2D.Impulse);

    }

    void Update()
    {
        // Player A Score
        if (Ball.position.x < goalPositionA)
        {
            Ball.position = Vector2.zero;

            // Reset ball velocity
            Rb_Ball.velocity = Vector2.zero;
            Rb_Ball.AddForce(new Vector2(-1,1) * speed, ForceMode2D.Impulse);

            // Score
            PlayerB_Score++;
            TMP_Score.text = PlayerA_Score.ToString() + ":" + PlayerB_Score.ToString();

            // Ball speed + 10%
            speed *= 1.10f;

            // On game over
            if (PlayerB_Score == MaxScore)
            {
                GameMenu.SetActive(true);
                Current_Game.SetActive(false);
            }
        }
        // Player B Score
        if (Ball.position.x > goalPositionB)
        {
            Ball.position = Vector2.zero;

            // Reset ball velocity
            Rb_Ball.velocity = Vector2.zero;
            Rb_Ball.AddForce(Vector2.one * speed, ForceMode2D.Impulse);

            // Score
            PlayerA_Score++;
            TMP_Score.text = PlayerA_Score.ToString() + ":" + PlayerB_Score.ToString();

            // Ball speed + 10%
            speed *= 1.10f;

            // On game over
            if (PlayerA_Score == MaxScore)
            {
                GameMenu.SetActive(true);
                Current_Game.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Paddle A" || collision.transform.name == "Paddle B")
            audioSource.PlayOneShot(audioClip);
        else
            audioSource.Play();
    }

}
