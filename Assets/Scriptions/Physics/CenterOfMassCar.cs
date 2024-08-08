
using UnityEngine;

public class CenterOfMassCar : MonoBehaviour
{
    public Transform transformChildMass;
    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.Scale(transformChildMass.localPosition, transform.localScale);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.5f);
    }
}
