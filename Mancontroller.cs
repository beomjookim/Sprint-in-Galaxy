using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mancontroller : MonoBehaviour {
    private Rigidbody2D myrigidbody;
    private Animator myAnimator;
    public float JumpForce = 750f;
    private float manHurtTime = -1;
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;
    private int jumpsleft = 2;
    public AudioSource jumpsfx;
    public AudioSource deathsfx;


	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }


        if (manHurtTime == -1)
        {
            if ((Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1")) && jumpsleft > 0)
            {
                if(myrigidbody.velocity.y < 0)
                {
                    myrigidbody.velocity = Vector2.zero;
                }

                myrigidbody.AddForce(transform.up * JumpForce);
                jumpsleft--;
                jumpsfx.Play();
            }

            myAnimator.SetFloat("velocity", myrigidbody.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");
        }

        else
        {
            if (Time.time > manHurtTime +2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Hitit"))
        {
            foreach (moveleft movelefter in FindObjectsOfType<moveleft>())
            {
                movelefter.enabled = false;
            }

            foreach (prefabspawner spawner in FindObjectsOfType<prefabspawner>())
            {
                spawner.enabled = false;
            }

            manHurtTime = Time.time;
            myAnimator.SetBool("mandead", true);
            myrigidbody.velocity = Vector2.zero;
            myrigidbody.AddForce(transform.up * JumpForce);
            myCollider.enabled = false;

            deathsfx.Play();

            float currentBestScore = PlayerPrefs.GetFloat("BestScore", 0);
            float currentScore = Time.time - startTime;

            if (currentBestScore < currentScore)
            {
                PlayerPrefs.SetFloat("BestScore", currentScore);
            }
        }
        else if(collision.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            jumpsleft = 2;
        }
        else if(collision.collider.gameObject.layer == LayerMask.NameToLayer("upperground"))
        {
            jumpsleft = 2;
        }
    }
}
