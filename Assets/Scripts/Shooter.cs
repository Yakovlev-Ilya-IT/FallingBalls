using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        //Возможно плохая проверка с таймскейлом (как бы проверка нет ли паузы)
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.TryGetComponent(out IShootable shootable))
            {
                shootable.CatchShot();
            }
        }
    }
}
