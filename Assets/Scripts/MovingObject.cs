using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private float halfScreenSize;


    private void Start()
    {
        halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
    }

    public void MovingObjectsAnotherPartScreen(GameObject movingObject)
    {

        if (movingObject.transform.position.x < -halfScreenSize || movingObject.transform.position.x > halfScreenSize)
        {
            float xPos = Mathf.Clamp(movingObject.transform.position.x, halfScreenSize, -halfScreenSize);
            movingObject.transform.position = new Vector3(xPos, movingObject.transform.position.y, movingObject.transform.position.z);
        }

        if (movingObject.transform.position.y < -halfScreenSize || movingObject.transform.position.y > halfScreenSize)
        {
            float yPos = Mathf.Clamp(movingObject.transform.position.y, halfScreenSize, -halfScreenSize);
            movingObject.transform.position = new Vector3(movingObject.transform.position.x, yPos, movingObject.transform.position.z);
        }
    }
}
