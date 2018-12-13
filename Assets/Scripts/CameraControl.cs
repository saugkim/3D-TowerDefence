using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float panSpeed = 30f;
	public float offset = 10f;
	public float scrollSpeed = 5f;

	public float minY = 20f;
	public float maxY = 80f;

    public float maxX = 60f;
    public float minX = -30f;

    public float maxZ = 40f;
    public float minZ = -40f;

	void Update () {

		if (GameManagement.isGameOver)
		{
			this.enabled = false;
			return;
		}

		if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - offset)
		{
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("down") || Input.mousePosition.y <= offset)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - offset)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("left") || Input.mousePosition.x <= offset)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}


		//float scroll = ;

		Vector3 pos = transform.position;

		pos.y -= Input.GetAxis("Mouse ScrollWheel") * 100 * scrollSpeed * Time.deltaTime;
       
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
       
		transform.position = pos;

	}
}
