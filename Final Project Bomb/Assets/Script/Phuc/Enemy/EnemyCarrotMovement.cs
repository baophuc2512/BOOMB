using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarrotMovement : MonoBehaviour
{
    private EnemySkill enemySkill;
    [SerializeField] private int moveRange;
    private Health health;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public Transform movePoint;
    [SerializeField] private GameObject attackAnimation;
    [SerializeField] private GameObject idleAnimation;
    [SerializeField] private GameObject appearAnimation;

    private void Awake() 
    {
        health = GetComponent<Health>();
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            int randomX = Random.Range(-moveRange - 1, moveRange);
            int randomY = Random.Range(-moveRange - 1, moveRange);

            if (Physics2D.OverlapBox(movePoint.position + new Vector3(randomX, randomY, 0f), Vector2.one / 5f, 0f, groundLayer)
            && !Physics2D.OverlapBox(movePoint.position + new Vector3(randomX, randomY, 0f), Vector2.one / 5f, 0f, wallLayer))
            {
                movePoint.position += new Vector3(randomX, randomY, 0f);
            }

            transform.position = movePoint.position;

            yield return new WaitForSeconds(1f);

            idleAnimation.GetComponent<AnimationScript>().enabled = false;
            attackAnimation.GetComponent<AnimationScript>().enabled = true;
            appearAnimation.GetComponent<AnimationScript>().enabled = false;
            
            yield return new WaitForSeconds(1f);

            enemySkill.playSkill(1, transform.position);

            yield return new WaitForSeconds(1f);

            idleAnimation.GetComponent<AnimationScript>().enabled = true;
            attackAnimation.GetComponent<AnimationScript>().enabled = false;
            appearAnimation.GetComponent<AnimationScript>().enabled = false;

            yield return new WaitForSeconds(2f);

            idleAnimation.GetComponent<AnimationScript>().enabled = false;
            attackAnimation.GetComponent<AnimationScript>().enabled = false;
            appearAnimation.GetComponent<AnimationScript>().enabled = true;

            yield return new WaitForSeconds(1f);
        }
        
    }
}
