using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    public int maxScore;

    public Animator playerAnim;
    public GameObject player;

    public GameObject endPanel;

    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
           // Debug.Log("congrats");
            playerController.runningSpeed = 0f;
            transform.Rotate(transform.rotation.x,180f, transform.rotation.z,Space.Self);
            endPanel.SetActive(true);
            if (score >= maxScore)
            {
               // Debug.Log("win");
                playerAnim.SetBool("Win",true);
                
            }
            else
            {
               // Debug.Log("lose");
                playerAnim.SetBool("Lose", true);
                
            }
        }
    }

    public void RestartBtn() {



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("takýldý");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddCoin() {


        score++;
        coinText.text =  "Score: " + score.ToString();
    
    }
}
