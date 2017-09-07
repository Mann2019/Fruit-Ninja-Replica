using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject bladeTrailPrefab;
    public float minCutVelocity = 0.01f;

    private bool isCutting=false;
    Vector2 previousPos;
    Rigidbody2D rb;
    GameObject currentTrail;
    Camera cam;
    CircleCollider2D circleCollider;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }

        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
	}

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - previousPos).magnitude/Time.deltaTime;
        if(velocity>minCutVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPos = newPos;
    }

    void StartCutting()
    {
        isCutting = true;
        currentTrail = Instantiate(bladeTrailPrefab, transform);
        previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        circleCollider.enabled = false;
        Destroy(currentTrail, 2f);
    }
}
