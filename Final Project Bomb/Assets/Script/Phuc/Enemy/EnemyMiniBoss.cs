using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMiniBoss : MonoBehaviour
{
    private EnemySkill enemySkill;
    private Health health;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public List<Transform> movePoints;
    private int placeStanding = 0;
    public GameObject rectangleArea;
    private Transform currentMovePoint;

    private void Awake() 
    {
        health = GetComponent<Health>();
        currentMovePoint = movePoints[0];
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
        StartCoroutine(slashEveryThing());
    }

    private void FixedUpdate()
    {
        if (currentMovePoint != null)
        transform.position = Vector3.MoveTowards(transform.position, currentMovePoint.position, health.currentSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            int randomNumberIncrease = Random.Range(1, 2);
            placeStanding = placeStanding + randomNumberIncrease;
            if (placeStanding >= 4) placeStanding -= 4;

            if (randomNumberIncrease == 1)
            {
                currentMovePoint = movePoints[placeStanding];
            }

            if (randomNumberIncrease == 2)
            {
                currentMovePoint = movePoints[placeStanding];
            }

            yield return new WaitForSeconds(3f);
        }
    }

    public IEnumerator slashEveryThing()
    {
        while(true)
        {
            enemySkill.slash(1, transform.position + new Vector3 (1f, 0f, 0f));
            yield return new WaitForSeconds(0.2f);
            enemySkill.slash(2, transform.position + new Vector3 (0f, 1f, 0f));
            yield return new WaitForSeconds(0.2f);
            enemySkill.slash(3, transform.position + new Vector3 (0f, -1f, 0f));
            yield return new WaitForSeconds(0.2f);
            enemySkill.slash(4, transform.position + new Vector3 (-1f, 0f, 0f));
            yield return new WaitForSeconds(0.2f);
        }
    }

    public int findPlace (int numberIncrease, int currentPlace) {
        currentPlace += numberIncrease;
        if (currentPlace >= 4) currentPlace -= 4;
        return currentPlace;
    }
}
