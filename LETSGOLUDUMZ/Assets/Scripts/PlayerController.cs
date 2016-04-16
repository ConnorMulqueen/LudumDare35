using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRB;
    private float speed = 8f;
    private float canJump = 0;
    private string playerState = "Normal";
    private bool facingRight = false;
    //float h = Input.GetAxis("Horizontal"); 
    // Use this for initialization
    void Start () {
        playerRB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        //transform.localRotation = !facingRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
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
            playerRB.gravityScale = 1;
            if (Input.GetKey(KeyCode.W)){
                if (Time.frameCount > canJump){
                    playerRB.AddForce(Vector2.up * speed * 40 * Time.deltaTime);
                    print(speed * 40 * Time.deltaTime);
                    canJump = Time.frameCount + 70;
                }
            }

            if (Input.GetKey(KeyCode.D)){
                facingRight = true;
          //      playerRB.velocity = Vector3.right * h * speed;
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
                //   playerRB.AddForce(Vector2.right * speed * 200 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                facingRight = false;
                //playerRB.AddForce(Vector2.left * speed * 200 * Time.deltaTime);
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

        if (playerState == "Jetpack"){
            playerRB.gravityScale = 1;
            if (Input.GetKey(KeyCode.W)){
                if (canJump > 0){
                    playerRB.AddForce(Vector2.up * speed * 200 * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.D)){
                facingRight = true;
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
                //   playerRB.AddForce(Vector2.right * speed * 200 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                //playerRB.AddForce(Vector2.left * speed * 200 * Time.deltaTime);
                this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        if (playerState == "Water"){
            playerRB.gravityScale = .2f;
            speed = 10f;
            //this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Swimming.png", typeof(Sprite)) as Sprite;
            //transform.rotation = (Quaternion.Euler(0, 0, 67)) ;
            if (Input.GetKey(KeyCode.W)) {
                if (Time.frameCount > canJump) {
                    this.transform.Translate(Vector2.up * speed * Time.deltaTime);
                    playerRB.AddForce(Vector2.up * speed * 400 * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.D)) {
                //facingRight = true;
                this.transform.Rotate(Vector3.forward * 2);
            }
            if (Input.GetKey(KeyCode.A)) {
                //facingRight = false;
                this.transform.Rotate(Vector3.forward * -2);
            }
        }
    }
    float waterVelocityReset(float velocity) {
        if (velocity > 25f) {
            return 15f;
        }
        else return velocity;
    }
}

