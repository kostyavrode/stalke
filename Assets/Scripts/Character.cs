using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
public class Character : MonoBehaviour,ICharacter
{
    [SerializeField] private Transform[] wallTransforms;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpTime;
    [SerializeField] private bool isAlive;
    private bool currWall;
    private Sequence sequence;
    private void Start()
    {
        sequence = DOTween.Sequence();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Strafe();
        }

    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            transform.Translate(transform.up * Time.timeScale * 0.001f * moveSpeed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag=="Obstacle")
        {
            Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag=="Obstacle")
        {
            Death();
        }
    }
    private void MoveForward()
    {
        transform.Translate(transform.up*Time.timeScale);
    }
    private void Strafe()
    {
        currWall = !currWall;
        if (sequence.IsPlaying())
        {
            sequence.Kill();
        }
        if (currWall)
        {
            transform.rotation=Quaternion.Euler(0,-90,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        sequence.Append(transform.DOMoveX(wallTransforms[currWall.GetHashCode()].position.x, jumpTime));
    }
    private void Death()
    {
        if (isAlive)
        {
            isAlive = false;
            Debug.Log("Player Dead");
        }
    }
}
