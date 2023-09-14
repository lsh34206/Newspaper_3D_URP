using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    enum PlayerState
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Bookshelf") | LayerMask.GetMask("Table");

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
        }
    }
}
