using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    
    void Update()
    {
        
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

       
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
               
                SoundManager.instance.BalloonPop();
            UIManager.Instance.BalloonDestroyed();


                Destroy(gameObject);
               // CameraContoller.CameraContollerInstance.OnParticle();
                print("work Done");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            print(collision.gameObject);
            UIManager.Instance.BalloonDestroyed();
            Destroy(gameObject);
           // CameraContoller.CameraContollerInstance.OnParticle();
        }
    }
}
