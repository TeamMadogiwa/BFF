using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

	[SerializeField]
	LineRenderer m_LineRenderer;
	[SerializeField]
	Camera m_Camera;
	List<Vector3> m_Points;

	private EdgeCollider2D collider;
	private List<Vector2> list;

	private float aliveTime = 5.0f;


	public LineRenderer lineRenderer
	{
		get
		{
			return m_LineRenderer;
		}
	}

	public new Camera camera
	{
		get
		{
			return m_Camera;
		}
	}

	public List<Vector3> points
	{
		get
		{
			return m_Points;
		}
	}

	private void Awake()
	{
		if (m_LineRenderer == null)
		{
			Debug.LogWarning("DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer.");
			CreateDefaultLineRenderer();
		}
		if (m_Camera == null)
		{
			Debug.LogWarning("DrawLine: Camera not assigned, Using Main Camera or Creating Camera if main not exists.");
			CreateDefaultCamera();
		}

		collider = GetComponent<EdgeCollider2D>();
		m_Points = new List<Vector3>();

		list = new List<Vector2>();
	}

	public void test()
	{
		if(aliveTime < .0f)
		{
			Reset();
		} else aliveTime -= .0f;

		
		
			Vector3 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = m_LineRenderer.transform.position.z;
			if (!m_Points.Contains(mousePosition))
			{
				m_Points.Add(mousePosition);
				list.Add(new Vector2(mousePosition.x,mousePosition.y));
				m_LineRenderer.positionCount = m_Points.Count;
				m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
				collider.Reset();
				collider.points = list.ToArray();
				
			}
		
	}
	private void Reset()
	{
		if (m_LineRenderer != null)
		{
			m_LineRenderer.positionCount = 0;
		}
		if (m_Points != null)
		{
			m_Points.Clear();
			list.Clear();
		}
	}

	private void CreateDefaultLineRenderer()
	{
		m_LineRenderer = gameObject.GetComponent<LineRenderer>();
		m_LineRenderer.positionCount = 0;
		m_LineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		m_LineRenderer.startColor = Color.white;
		m_LineRenderer.endColor = Color.white;
		m_LineRenderer.startWidth = 0.3f;
		m_LineRenderer.endWidth = 0.3f;
		m_LineRenderer.useWorldSpace = true;
	}

	private void CreateDefaultCamera()
	{
		m_Camera = Camera.main;
		if (m_Camera == null)
		{
			m_Camera = gameObject.AddComponent<Camera>();
		}
		m_Camera.orthographic = true;
	}
}
