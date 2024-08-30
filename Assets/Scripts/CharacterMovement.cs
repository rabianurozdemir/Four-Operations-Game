using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryPadding = 0.5f;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SetTargetPosition(touch.position);
            }
        }

        if (isMoving)
        {
            MoveToTargetPosition();
        }
    }

    void SetTargetPosition(Vector2 touchPosition)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;

        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + boundaryPadding;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - boundaryPadding;

        targetPosition.x = Mathf.Clamp(targetPosition.x, screenLeft, screenRight);

        isMoving = true;
    }

    void MoveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}



