using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform View;
    [SerializeField] private float max_x = 0.15f;
    [SerializeField] private float max_y = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float delX = View.position.x - transform.position.x; 
        if(delX > max_x || delX < -max_x)
        {
            if(transform.position.x < View.position.x)
            {
                delta.x = delX - max_x; 
            }    
            else
            {
                delta.x = delX + max_x;
            }    
        }

        float delY = View.position.y - transform.position.y; 
        if(delY > max_y || delY < -max_y)
        {
            if(transform.position.y < View.position.y)
            {
                delta.y = delY - max_y; 
            }    
            else
            {
                delta.y = delY + max_y; 
            }    
        }

        transform.position += new Vector3(delta.x, delta.y, 0); 
    }

}
