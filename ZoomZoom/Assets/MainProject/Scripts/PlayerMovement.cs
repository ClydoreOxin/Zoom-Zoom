using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject cameraRef;
    //private float xBounds = 30;
    public float xInput;
    public float speed;
    public float uSpeed;
    public Rigidbody playerbody;
    public float gravityMod;
    public bool isGameActive;
    public float rotSpeed;
    //private float rotLimit = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
        cameraRef = GameObject.Find("Main Camera");
        Physics.gravity *= gravityMod;
        isGameActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameActive)
        {
            xInput = Input.GetAxis("Horizontal");
            //playerbody.AddForce(Vector3.right * speed * xInput, ForceMode.Impulse);
            transform.Translate(Vector3.right * speed * xInput * Time.deltaTime);
            
            cameraRef.transform.position = GetPlayerPos() + new Vector3(0, 11, -13);
        }
    }
    public Vector3 GetPlayerPos() {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) GameOver();
    }
    public void GameOver() {
        isGameActive = false;
    }
}
