using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSwipeHandler : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    private bool isSwiping = false;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 swipeDirection;

    private static bool isButtonHeld = false;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    
    void Update()
    {
        Debug.Log(Time.timeScale);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isButtonHeld)
            {
                isSwiping = false;
                Time.timeScale = 0.2f;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && !isButtonHeld)
            {
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && !isButtonHeld)
            {
                isSwiping = false;
                Time.timeScale = 1f;
                endPos = touch.position;
                swipeDirection = endPos - startPos;

                // Нормализуйте вектор свайпа (чтобы получить только направление без длины)
                swipeDirection.Normalize();

                // Debug.Log("Swipe direction: " + swipeDirection);
            }
        }

        // Если пользователь свайпает, отключаем взаимодействие с кнопкой
        button.interactable = !isSwiping;
    }
    
    public void PoiterExit()
    {
        isButtonHeld = false;
    }
    
    public void PoiterEnter()
    {
        isButtonHeld = true;
    }
    
    //
    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     isButtonHeld = true;
    // }
    //
    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     isButtonHeld = false;
    // }
}