using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitMouse : MonoBehaviour {

    public GameObject[] cell;
    // Use this for initialization
    void Start()
    {
        cell = GameObject.FindGameObjectsWithTag("cell");
        resetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 500))
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    if (hit.collider.gameObject.tag == "cell")
                    {
                        Debug.Log("GameObject : " + hit.collider.gameObject);
                        //Destroy(hit.collider.gameObject);
                        if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.white)
                        {
                            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else
                        {
                            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
                }
            }
        }
    }

    private void resetColor()
    {
        for (int i = 0; i < cell.Length; i++)
        {
            cell[i].GetComponent<Renderer>().material.color = Color.white;
            
        }
    }
}
