using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatingPlatform : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private Rigidbody2D sliderBody;

    public float speed = 1.0f;
    public float leftEdge = -5.0f;
    public float rightEdge = 5.0f;

    private int direction = 1;

    private void Start()
    {
        // �������� ���������� SliderJoint2D � Rigidbody2D
        sliderJoint = GetComponent<SliderJoint2D>();
        sliderBody = sliderJoint.connectedBody;
    }

    private void FixedUpdate()
    {
        // �������� ������� ��������� Slider Joint
        float position = sliderJoint.jointTranslation;

        // ���������, ������ �� Slider Joint ������ �� �����
        if (position <= leftEdge || position >= rightEdge)
        {
            // ������ ����������� ��������
            direction *= -1;
        }

        // ������� ����� ��������� ��������� JointMotor2D � ������������� ��� ��������
        JointMotor2D motor = sliderJoint.motor;
        motor.motorSpeed = speed * direction;

        // ��������� ��������� � Slider Joint
        sliderJoint.motor = motor;
    }
}
