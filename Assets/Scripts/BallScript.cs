using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Transform Ball;
    Rigidbody2D Rb_Ball;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    float speed = 10f;
    float goalPosition = 10f;

    public TextMeshPro TMP_Score;
    int Initial_Score = 10;
    int Current_Score;

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
        Current_Score = Initial_Score;
        TMP_Score.text = Current_Score.ToString();

        // Reset speed
        speed = 10f;

        // Pulse on game start
        Rb_Ball.AddForce(Vector2.one * speed, ForceMode2D.Impulse);

    }

    void Update()
    {
        if (Ball.position.x > goalPosition)
        {
            Ball.position = Vector2.zero;

            // Reset ball velocity
            Rb_Ball.velocity = Vector2.zero;
            Rb_Ball.AddForce(Vector2.one * speed, ForceMode2D.Impulse);

            // Score
            Current_Score--;
            TMP_Score.text = Current_Score.ToString();

            // Ball speed + 10%
            speed *= 1.10f;

            // On game over
            if (Current_Score == 0)
            {
                GameMenu.SetActive(true);
                Current_Game.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Paddle")
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            audioSource.Play();
        }
    }


}
