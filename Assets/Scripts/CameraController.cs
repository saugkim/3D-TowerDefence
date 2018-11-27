using UnityEngine;

public class CameraController : MonoBehaviour {

    public float keyboardSpeed = 25f;
    public float mouseMovement = 20f;
    //--Scrolling--\\
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
	
	// Update is called once per frame
	void Update () {
        //Keyboard movement 

        //--Camera Location --\\
        Vector3 pos = transform.position;
        //--Keyboard -- \\
        if(Input.GetKey("w") || (Input.GetKey("up")) || Input.mousePosition.y >= Screen.height - mouseMovement){
            pos.z += keyboardSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") ||(Input.GetKey("down")) || Input.mousePosition.y <= mouseMovement)
        {
            pos.z -= keyboardSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || (Input.GetKey("left"))|| Input.mousePosition.x <= mouseMovement)
        {
            pos.x -= keyboardSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || (Input.GetKey("right"))|| Input.mousePosition.x >= Screen.width - mouseMovement)
        {
            pos.x += keyboardSpeed * Time.deltaTime;
        }
       float scroll =  Input.GetAxis("Mouse ScrollWheel");
        pos.y += scroll * scrollSpeed * 100 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
	}
}
