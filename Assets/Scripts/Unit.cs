using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Vector2 turn;
    Camera m_Camera;
    bool IsPlaced;
    bool IsRotated;
    [SerializeField] GameObject Popup;
    void Start()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        SetPosition();
        SetRotation();
    }
   
    void SetPosition()
    {
        if (IsPlaced) { return; }

        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit Hitinfo, Mathf.Infinity,1 << 3))
        {
            transform.position = Hitinfo.point;
            if (Input.GetMouseButtonDown(0))
            {  
                IsPlaced = true;
                Popup.SetActive(true);
            }
        }
       
    
    }
    void SetRotation()
    {
        if (!IsPlaced || IsRotated) { return; }

            turn.y += Input.GetAxis("Mouse Y");
            turn.x += Input.GetAxis("Mouse X");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsRotated=true;
        }
    }
    public void SetIsPlace()
    {
        IsPlaced = false;
        IsRotated=false;
        Popup.SetActive(false);
    }

    public void Delete()
    {
        Manager.Instance.DeleteUnit(gameObject);
    }
}
