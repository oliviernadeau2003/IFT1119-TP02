using UnityEngine;

public class PaddleBScriptJcE : MonoBehaviour
{
    Transform Paddle;

    Vector3 Initial_Position = new(8f, 0f, 0f);

    float Limit = 3.8f;

    float speed = 8f;

    void Start()
    {
        Paddle = this.gameObject.transform;
        Paddle.position = Initial_Position;
    }

    void Update()
    {
        Vector3 Position = Paddle.position;

        Position.y += speed * Time.deltaTime * Input.GetAxis("Vertical B");

        Position.y = Mathf.Min(Position.y, Limit);
        Position.y = Mathf.Max(Position.y, -Limit);

        Paddle.position = Position;
    }
}
