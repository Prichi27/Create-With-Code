using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _dirtParticle;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _dieSound;

    public bool gameOver = false;

    private Rigidbody _rigidBody;
    private Animator _animator;
    private AudioSource _audioSource;

    private bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        // change gravity value 
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
            _animator.SetTrigger("Jump_trig");
            _dirtParticle.Stop();
            _audioSource.PlayOneShot(_jumpSound, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            _isGrounded = true;
            _dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _explosionParticle.Play();
            _dirtParticle.Stop();
            gameOver = true;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            _audioSource.PlayOneShot(_dieSound, 1);
        }
    }
}
