using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    protected Stack<GameObject> uiStack = new Stack<GameObject>();
    protected enum uiStatus
    {
        None,
        Popup
    }

    protected uiStatus _status = uiStatus.None;

    void Update()
    {
        
    }

    protected void ClearUI()
    {
        foreach (GameObject go in uiStack)
        {
            go.SetActive(false);
        }
        uiStack.Clear();
    }

    protected void UIStackUpdate()
    {
        uiStack.Push(gameObject);
    }
}
