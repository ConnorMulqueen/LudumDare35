using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRB;
    private float speed = 4f;
    private float canJump = 0;
    private string playerState = "Normal";
    //float h = Input.GetAxis("Horizontal"); 
    // Use this for initialization
    void Start () {
        playerRB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Water"){
            playerState = "Water";
        }
        if (col.tag == "Jetpack"){
            playerState = "Jetpack";
        }
    }
    void Movement(){
        playerRB.freezeRotation = true;

        if (playerState == "Normal") {
            if (Input.GetKey(KeyCode.W)){
                if (Time.frameCount > canJump){
                    playerRB.AddForce(Vector2.up * speed * 40 * Time.deltaTime);
                    print(speed * 40 * Time.deltaTime);
                    canJump = Time.frameCount + 70;
                }
            }

            if (Input.GetKey(KeyCode.D)){
          //      playerRB.velocity = Vector3.right * h * speed;
                this.transform.Translate(Vector2.right * speed * Time.deltaTime);
                //   playerRB.AddForce(Vector2.right * speed * 200 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                //playerRB.AddForce(Vector2.left * speed * 200 * Time.deltaTime);
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

        if (playerState == "Jetpack"){
            if (Input.GetKey(KeyCode.W)){
                if (canJump > 0){
                    playerRB.AddForce(Vector2.up * speed * 200 * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.D)){
                this.transform.Translate(Vector2.right * speed * Time.deltaTime);
                //   playerRB.AddForce(Vector2.right * speed * 200 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                //playerRB.AddForce(Vector2.left * speed * 200 * Time.deltaTime);
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        if (playerState == "Water"){
            if (Input.GetKey(KeyCode.W)){
                if (canJump > 0){
                    this.transform.Translate(Vector2.up * speed * 3 * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.D)){
                playerRB.AddForce(Vector2.right * speed * 100 * Time.deltaTime);
                //   playerRB.AddForce(Vector2.right * speed * 200 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                //playerRB.AddForce(Vector2.left * speed * 200 * Time.deltaTime);
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }
}
