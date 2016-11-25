using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour {

    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    private bool rHalfDown = false;//右半分がタッチされたかどうか
    private bool lHalfDown = false;//左半分がタッチされたかどうか

    // Use this for initialization
    void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
	}

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || lHalfDown) && tag == "LeftFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || rHalfDown) && tag == "RightFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
        /*カリキュラム
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                SetAngle(this.defaultAngle);
            }
        }*/
        //キーを離した時の処理を左右別々に
        if ((Input.GetKey(KeyCode.LeftArrow)==false && lHalfDown==false) && tag == "LeftFlipperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKey(KeyCode.RightArrow)==false && rHalfDown==false) && tag == "RightFlipperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
    //以下、画面をタッチされた時の処理
    public void GetMyLHalfDown()
    {
        lHalfDown = true;
    }
    public void GetMyLHalfUp()
    {
        lHalfDown = false;
    }
    public void GetMyRHalfDown()
    {
        rHalfDown = true;
    }
    public void GetMyRHalfUp()
    {
        rHalfDown = false;
    }
}
