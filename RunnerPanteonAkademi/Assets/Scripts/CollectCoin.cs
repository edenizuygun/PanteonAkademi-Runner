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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("congrats");
            playerController.runningSpeed = 0f;
        }
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
