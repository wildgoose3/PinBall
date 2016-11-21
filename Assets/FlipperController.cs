using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {

        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
    if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
    if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
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
}
