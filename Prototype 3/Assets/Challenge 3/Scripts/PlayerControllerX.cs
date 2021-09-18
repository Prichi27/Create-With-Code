using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private bool canPlayerFly;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    
    [SerializeField]
    private float upperLimit;

    [SerializeField]
    private float _bounceForce;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        canPlayerFly = transform.position.y < upperLimit;
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && canPlayerFly && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (!canPlayerFly && playerRb.velocity.y > 0) 
        { 
            transform.position = new Vector3(transform.position.x, upperLimit, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameOver) return;
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * _bounceForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1f);
        }

    }

}
