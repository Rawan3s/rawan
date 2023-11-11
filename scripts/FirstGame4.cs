using UnityEngine;

public class playerCont : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
      public void Movement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        
        if (moveDirection != Vector3.zero)
        {
            //change rotation
            transform.forward = moveDirection;

            //move charactr
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        

       

    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
