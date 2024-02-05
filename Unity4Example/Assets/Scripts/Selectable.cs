using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Selectable : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] ParticleSystem particle;
    bool select = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        particle.Play();

    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3
            (
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(gameObject.transform.position).z
            );
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        select = true;
    }
    private void OnMouseExit()
    {
        select = false;
    }




    private void OnTriggerEnter(Collider other)
    {
        string selectObject =transform.name;
        string colObject = other.transform.name;

        if(selectObject == colObject)
        {
            int add = int.Parse(selectObject.Substring(selectObject.Length - 1)) + int.Parse(colObject.Substring(selectObject.Length - 1));
            Debug.Log(add);
            if(add == 2 && select)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;
                Instantiate(Resources.Load<GameObject>("Container 2"), mousePos, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
