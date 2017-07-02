using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Vector2 startForce;
    public Rigidbody2D ballRigidbody;

    public GameObject nextBall;

	// Use this for initialization
	void Start () {
        ballRigidbody.AddForce(startForce, ForceMode2D.Impulse);
        GameController.Instance.AddBallToTracking(this.gameObject);
	}

    public void Split()
    {
        if(nextBall != null)
        {
            GameObject rightBall = Instantiate(nextBall, ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
            GameObject leftBall = Instantiate(nextBall, ballRigidbody.position + Vector2.left/ 4f, Quaternion.identity);

            GameController.Instance.AddBallToTracking(rightBall);
            GameController.Instance.AddBallToTracking(leftBall);


            rightBall.GetComponent<BallController>().startForce = new Vector2(2f, 5f);
            leftBall.GetComponent<BallController>().startForce = new Vector2(-2f, 5f);
        }

        GameController.Instance.RemoveBallFromTracking(this.gameObject);
        Destroy(this.gameObject);
    }
}
