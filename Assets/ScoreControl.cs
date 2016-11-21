using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

    private GameObject scoreText; //得点表示テキスト
    private int score; //得点
    private int increase; //各オブジェクトの加算点数
    private bool myCollision; //衝突状態を判定するための変数

	// Use this for initialization
	void Start () {

        scoreText = GameObject.Find("ScoreText");
 
    }
	
	// Update is called once per frame
	void Update () {
 
        if (myCollision == true)
        {
            score += increase; //得点を加算
            scoreText.GetComponent<Text>().text = "SCORE     " + score;
            myCollision = false; //衝突判定変数を0に戻す
        }

    }
    // 衝突判定
    void OnCollisionEnter(Collision other)
    {
        myCollision=true; //当たったら衝突判定変数を1に
                      
        //各オブジェクトの点数設定
        if (other.gameObject.tag == "SmallStarTag")
        {
            increase = 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            increase = 100;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            increase = 50;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            increase = 200;
        }
        else
        {
            increase = 0;
        }
    }
}
