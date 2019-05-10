using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public static DrawLine Instance;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    private GameObject lineGO;
    private LineRenderer lineRenderer;
    private int i = 0;
    public Transform panel;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        lineGO = new GameObject("Line");
        //lineGO.transform.SetParent(panel.transform, false);
        lineGO.AddComponent<LineRenderer>();
        lineRenderer = lineGO.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(15F, 15F);
        lineRenderer.SetVertexCount(0);
        lineRenderer.useWorldSpace = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            drawWithTouch();
        }
        else
        {
            drawWithMouse();
        }

        //drawWithMouse();
    }

    private void drawWithTouch()
    {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (i != 0) // && i < BoxSpawner.WordBoxCount
                {
                    lineRenderer.SetVertexCount(i + 1);
                    Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                    lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
                }
            }
    }

    private void drawWithMouse()
    {
        if (Input.GetMouseButton(0))
        {
            if (i != 0) // && i < BoxSpawner.WordBoxCount
            {
                lineRenderer.SetVertexCount(i + 1);
                Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
            }
        }
    }

    public void drawBack()
    {
        lineRenderer.SetVertexCount(i - 1);
        i--;
    }

    public void setPositonLine(Vector2 position)
    {
        lineRenderer.SetVertexCount(i + 1);
        lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(new Vector3(position.x,position.y,10)));
        i++;
    }

    public void resetLine()
    {
        lineRenderer.SetVertexCount(0);
        i = 0;
    }
}
