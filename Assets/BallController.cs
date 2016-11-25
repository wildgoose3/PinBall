using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    private float visibleposZ = -6.5f;

    private GameObject gameoverText;

	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.position.z< this.visibleposZ)
        {
            this.gameoverText.GetComponent<Text>().text = "GAME OVER";
        }
	}
    public void RestartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}
