using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float vectocity;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private BoxCollider2D boxcolider; 



    private void Start()
    {
        boxcolider = GetComponent<BoxCollider2D>(); 
    }

    private void Update()
    {

        Vector3 characterFlip = transform.localScale; 
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += vectocity * Time.deltaTime * Vector3.left;
            characterFlip.x = -2; 
                    
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += vectocity * Time.deltaTime * Vector3.right;
            characterFlip.x = 2; 
            

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += vectocity * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += vectocity * Time.deltaTime * Vector3.down;
        }
        transform.localScale = characterFlip;

        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(x, y, 0);

        // hit loading 
        hit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime) , LayerMask.GetMask("Brocks" , "Actor"));
        if(hit.collider == null)
        {
            transform.Translate(0,moveDelta.y * Time.deltaTime ,0 ); 
        }
        hit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Brocks", "Actor"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime,0, 0);
        }



    }
}
