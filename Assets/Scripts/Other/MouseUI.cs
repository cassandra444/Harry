using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseUI : MonoBehaviour
{
    [SerializeField] private LayerMask clicMask;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _mouseUI;
    [SerializeField] private Animator _cursorAnimator;

    private Vector3 _cursorPosition;

    private void Start()
    {
        _mouseUI.SetActive(false);
    }

    private void UIManager()
    {
        if(Input.GetMouseButton(0))
        {
            _cursorAnimator.SetBool("CursorScaleDown", true);
        }
    }

   

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        _cursorAnimator.SetBool("CursorScaleDown", false);

        if (Physics.Raycast(ray, out _hit, 500f,  clicMask))
        {
            if (_hit.collider.tag != "Object")
            {
                _mouseUI.SetActive(true);
                _mouseUI.transform.position = _hit.point;
                UIManager();
            }
            else
            {
                _mouseUI.SetActive(false);
            }
        }
    }


}
