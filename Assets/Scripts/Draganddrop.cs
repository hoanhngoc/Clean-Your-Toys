using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draganddrop : MonoBehaviour
{ 
    private bool isDragActive=false;
    private Vector2 screenposition;
    private Vector3 worldposition;
    private Draggable lassDragged;
    private void Awake()
    {
        Draganddrop[] controller = FindObjectsOfType<Draganddrop>();
        if(controller.Length>1)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(isDragActive && (Input.GetMouseButtonUp(0)|| (Input.GetTouch(0).phase==TouchPhase.Ended)))
        {
            
            Drop();
            return;
        }
       if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenposition=new Vector2(mousePos.x, mousePos.y);
        }
       else if(Input.touchCount>0)
        {
            screenposition = Input.GetTouch(0).position;
        }
       else
        {
            return;
        }
        worldposition = Camera.main.ScreenToWorldPoint(screenposition);
        
        if(isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldposition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    lassDragged = draggable;
                    InitDrag(); 
                }
            }
        }
    }

        
    public void InitDrag()
    {
        isDragActive = true;
    }
    public void Drag()
    {
        lassDragged.transform.position = new Vector2(worldposition.x, worldposition.y);
    }
    public void Drop()
    {
        isDragActive=false;
    }
}
