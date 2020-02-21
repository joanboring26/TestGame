using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    private float m_spring = 0.0f;
    private float m_damper = 0.0f;
    private float m_shake = 0.0f;

    [SerializeField] float maxVelocity = 10.0f;

    [SerializeField] private Slider m_springSlider;
    [SerializeField] private Slider m_damperSlider;
    [SerializeField] private Slider m_shakeSlider;

    public Vector2 PositionDiff
    {
        get { return m_initialPos - (Vector2)this.transform.position; }
    }
    private Vector2 m_velocity;
    private Vector2 m_initialPos;
    // Start is called before the first frame update
    void Start()
    {
        //m_initialPos = transform.position;
        m_springSlider.onValueChanged.AddListener(delegate { m_spring = Mathf.Clamp(m_springSlider.value, 0.1f, 0.9f); }); // clamp its easier
        m_damperSlider.onValueChanged.AddListener(delegate { m_damper = Mathf.Clamp(m_damperSlider.value, 0.1f, 0.9f); });
        m_shakeSlider.onValueChanged.AddListener(delegate { m_shake = m_shakeSlider.value; });

        m_spring = m_springSlider.value;
        m_damper = m_damperSlider.value;
        m_shake = m_shakeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        m_velocity += (m_initialPos - (Vector2)this.transform.position) * m_spring;
        m_velocity -= m_velocity * m_damper;
        transform.position += (Vector3)m_velocity;
    }

    public void AddShake(Vector2 input)
    {
        m_velocity += input * m_shake;
        //m_velocity += new Vector2(Mathf.Clamp(m_velocity.x, minX, maxX), Mathf.Clamp(m_velocity, minY, maxY);)
    }
}
