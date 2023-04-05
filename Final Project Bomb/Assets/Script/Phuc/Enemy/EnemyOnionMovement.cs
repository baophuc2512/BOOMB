using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnionMovement : MonoBehaviour
{
    private EnemySkill enemySkill;
    private Health health;
    public LayerMask wallLayer;
    public Transform movePoint;
    [SerializeField] private GameObject animationStar;
    [SerializeField] private GameObject animationRolling;

    private void Awake()
    {
        health = GetComponent<Health>();
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, health.currentSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            animationRolling.GetComponent<AnimationScript>().enabled = false;
            animationStar.GetComponent<AnimationScript>().enabled = true;

            yield return new WaitForSeconds(1f);

            animationRolling.GetComponent<AnimationScript>().enabled = true;
            animationStar.GetComponent<AnimationScript>().enabled = false;

            // ------------------------------------------------

            int kind = Random.Range(1, 5);
            
            for (int t1 = 1; t1 <= 3; t1++)
            { 
                Vector3 oldPos = movePoint.position;
                if (kind == 1) // Sang phai
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                }
                if (kind == 2) // Sang trai
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                }
                if (kind == 3) // Len tren
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
                if (kind == 4) // Xuong duoi
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                }
                if (Physics2D.OverlapBox(movePoint.position, Vector2.one / 5f, 0f, wallLayer))
                {
                    movePoint.position = oldPos;
                    break;
                }
            }
            yield return new WaitForSeconds(2f);
            
            enemySkill.playSkill(2, transform.position);
        }
    }

}