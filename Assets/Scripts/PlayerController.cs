using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 4f;
    public Rigidbody2D playerRigidbody;

    private float movementOrientation = 0f;


    void Update()
    {
        movementOrientation = Input.GetAxis(NameHelper.AxisHorizontal) * speed;
    }

    private void FixedUpdate()
    {
        if (GameController.Instance.GameIsFinished)
        {
            return;
        }
        playerRigidbody.MovePosition(playerRigidbody.position + Vector2.right * movementOrientation * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == NameHelper.TagBall)
        {
            GameController.Instance.GameOwer();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
