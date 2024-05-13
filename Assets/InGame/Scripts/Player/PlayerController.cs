using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private PolygonCollider2D mapCollider; // Добавляем переменную mapCollider

    private bool isDragging = false;
    private bool isMoving = false;
    private Vector3 targetPosition;
    public float constantSpeed = 1f;
    public float zoomSpeed = 0.01f;
    public GameObject inGameSettings;
    public GameObject playerProfile;

    void Start()
    {
        mainCamera = Camera.main;
        mapCollider = GameObject.FindGameObjectWithTag("Map").GetComponent<PolygonCollider2D>();

        targetPosition = transform.position;
    }

    void Update()
    {
        if(!inGameSettings.activeInHierarchy & !playerProfile.activeInHierarchy)
        {
            // Проверяем нажатие левой кнопки мыши
            if (Input.GetMouseButtonDown(0))
            {
                // Преобразуем позицию клика мыши в мировые координаты
                targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane));
                targetPosition.z = 0f;
                isMoving = true;
                isDragging = true;
            }

            // Проверяем перемещение пальцем на сенсорном устройстве
            bool touchInProgress = false;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));
                    targetPosition.z = 0f;
                    isMoving = true;
                    isDragging = true;
                    touchInProgress = true;
                }

                if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));
                    isMoving = true;
                    isDragging = true;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    isDragging = false;
                }
            }

            if (!touchInProgress)
            {
                isMoving = true;
            }

            if (isMoving && (Input.touchCount == 0 || Input.GetMouseButton(0))) // Добавляем условие для нажатия кнопки мыши
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, constantSpeed * Time.deltaTime);

                Vector2 clampedPosition = mapCollider.ClosestPoint(transform.position);
                if (!mapCollider.OverlapPoint(transform.position))
                {
                    transform.position = clampedPosition;
                }
            }

            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
                float currentMagnitude = (touch0.position - touch1.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                mainCamera.orthographicSize -= difference * zoomSpeed;

                mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 1f, 5f);
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision other)
    {
        /* проверка какой предмет был найден
        проверить тип найденного предмета
        _item = other.GetComponent<pickableItem>;
        if(_item != null)
        {
            _item.pick();
        }
        */
        /*

        */   
    }
    
}
