using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float slowPeriod = 5f;
    [SerializeField] float defaultSpeed = 20;
    [SerializeField] float boostPeriod = 5f;
    [SerializeField] float boostSpeed = 30f;

    bool boosting = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update(){
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, (-steerAmount) * Time.deltaTime);
        transform.Translate(0, moveAmount * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        StopAllCoroutines();
        StartCoroutine(Decrease());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost") {
            StopAllCoroutines();
            StartCoroutine(Boost());
        }
    }

    private IEnumerator Decrease() {
        moveSpeed = slowSpeed;
        boosting = false;
        yield return new WaitForSeconds(boostPeriod);

        moveSpeed = defaultSpeed;
    }

    private IEnumerator Boost() {
        moveSpeed = boostSpeed;
        boosting = true;
        yield return new WaitForSeconds(boostPeriod);

        moveSpeed = defaultSpeed;
        boosting = false;
    }
}
