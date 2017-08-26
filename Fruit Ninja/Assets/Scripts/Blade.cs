using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject bladeTrailPrefab;

    private bool isCutting=false;
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
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StartCutting()
    {
        isCutting = true;
        currentTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        circleCollider.enabled = false;
        Destroy(currentTrail, 2f);
    }
}
