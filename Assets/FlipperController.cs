using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour {

    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    private float ScreenWidth = Screen.currentResolution.width;
    private bool rHalfDown = false;//右半分がタッチされたかどうか
    private bool lHalfDown = false;//左半分がタッチされたかどうか

    // Use this for initialization
    void Start () {
        Debug.Log(ScreenWidth);
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lHalfDown);
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || lHalfDown) && tag == "LeftFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || rHalfDown) && tag == "RightFlipperTag")
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
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || lHalfDown==false) && tag == "LeftFlipperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || rHalfDown==false) && tag == "RightFlipperTag")
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
