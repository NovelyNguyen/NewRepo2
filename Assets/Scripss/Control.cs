using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float verocity;
     RaycastHit2D hit;
    BoxCollider2D boxcolider; 

    // Start is called before the first frame update
    

    private void Start()
    {
        boxcolider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       // transform.Translate(new Vector3(x,y,0) * Time.deltaTime * verocity);

        Vector3 delta = new Vector3(x, y, 0); 
        
        Vector3 charFlip = transform.localScale; 
        if(Input.GetAxisRaw("Horizontal") < 0 )
        {
            charFlip.x = -2; 
        }    
        if(Input.GetAxisRaw("Horizontal") > 0 )
        {
            charFlip.x = 2; 
        }
        transform.localScale = charFlip;

        hit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(0, delta.y), Mathf.Abs(delta.y) * Time.deltaTime, LayerMask.GetMask("Actor", "Brocks") ) ; 
        if(hit.collider == null)
        {
            transform.Translate( 0 , delta.y * Time.deltaTime*verocity  , 0   );
        }
           

        hit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(delta.x, 0), Mathf.Abs(delta.x) * Time.deltaTime, LayerMask.GetMask("Actor", "Brocks"));
        if (hit.collider == null)
        {
            transform.Translate( delta.x * Time.deltaTime *verocity, 0 ,  0);
        }

       
        


    }
      
}
