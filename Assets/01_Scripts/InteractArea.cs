using UnityEngine;

public class InteractArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.transform.name);
    }

    private void OnCollisionExit(Collision colli)
    {
        
    }
}
