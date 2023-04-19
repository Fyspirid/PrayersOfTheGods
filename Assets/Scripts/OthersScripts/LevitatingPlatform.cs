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
        // Получаем компоненты SliderJoint2D и Rigidbody2D
        sliderJoint = GetComponent<SliderJoint2D>();
        sliderBody = sliderJoint.connectedBody;
    }

    private void FixedUpdate()
    {
        // Получаем текущее положение Slider Joint
        float position = sliderJoint.jointTranslation;

        // Проверяем, достиг ли Slider Joint одного из краев
        if (position <= leftEdge || position >= rightEdge)
        {
            // Меняем направление движения
            direction *= -1;
        }

        // Создаем новый экземпляр структуры JointMotor2D и устанавливаем его скорость
        JointMotor2D motor = sliderJoint.motor;
        motor.motorSpeed = speed * direction;

        // Применяем изменения к Slider Joint
        sliderJoint.motor = motor;
    }
}
