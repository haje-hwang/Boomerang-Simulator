using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    Rigidbody m_rb;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        physics_v3();
    }

    public void Onthrow(){
        // m_rb.AddRelativeTorque(Vector3.up * 60f, ForceMode.Impulse);
    }

    public void physics_v1()
    {
        if(m_rb.angularVelocity.magnitude > 2){
            //양력? lift
            m_rb.AddRelativeForce(Vector3.up * m_rb.angularVelocity.magnitude * Time.fixedDeltaTime, ForceMode.Force);
            
            // rb.AddForce(-Physics.gravity);

            //Direction of precession, 부메랑의 세차운동
            //https://sillurian.tistory.com/120
            m_rb.AddForce(Vector3.Cross(Physics.gravity, m_rb.angularVelocity) * Time.fixedDeltaTime, ForceMode.Force);
            m_rb.AddTorque(Vector3.up);
        }
        if(Vector3.Distance(Camera.main.transform.position, m_rb.position) > 49){
               m_rb.AddForce((Camera.main.transform.position- m_rb.position) / Time.fixedDeltaTime);
        }
        if(Vector3.Distance(Camera.main.transform.position, m_rb.position) < 3){
            m_rb.velocity *= 0.8f;
        }
    }

    public void physics_v2()
    {
        if(m_rb.angularVelocity.magnitude > 2){
            float V = m_rb.angularVelocity.magnitude / 2;
            Vector3 t = m_rb.rotation.eulerAngles * Mathf.PI/180;
            float h =(90 - Vector3.Angle(transform.up, Vector3.up))* Mathf.PI/180;; //자세각
            float dX = V* ( Mathf.Cos(h)*( Mathf.Cos(t.z)*Mathf.Cos(t.y) - Mathf.Sin(t.z)*Mathf.Sin(t.y)*Mathf.Cos(t.x) ) + Mathf.Sin(h)*Mathf.Sin(t.y)*Mathf.Sin(t.x) );
            float dY = -V* ( Mathf.Cos(h)*( Mathf.Cos(t.z)*Mathf.Sin(t.y) - Mathf.Sin(t.z)*Mathf.Cos(t.y)*Mathf.Cos(t.x) ) + Mathf.Sin(h)*Mathf.Cos(t.y)*Mathf.Sin(t.x) );
            float dZ = V* ( Mathf.Cos(h)*Mathf.Sin(t.z)*Mathf.Sin(t.y) + Mathf.Sin(h)*Mathf.Cos(t.x) );
            m_rb.AddForce(new Vector3(dX, dY, dZ));   
        }
    }
    public void physics_v3()
    {
        m_rb.velocity = Vector3.Cross(Physics.gravity, -transform.up);
        m_rb.MoveRotation(Quaternion.Euler(Vector3.down + m_rb.rotation.eulerAngles));
    }
}
