using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
    }

    void Update()
    {
        //PC
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //スマートフォン
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                var id = t.fingerId;
                if (t.phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    if (t.position.x < Screen.width / 2)
                    {
                        SetAngle(this.flickAngle);
                    }
                }
                if (t.phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    if (t.position.x >= Screen.width / 2)
                    {
                        SetAngle(this.flickAngle);
                    }
                }
                if (t.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    if (t.position.x < Screen.width / 2)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                if (t.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    if (t.position.x >= Screen.width / 2)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
    }
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}