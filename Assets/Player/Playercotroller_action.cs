using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Playercotroller_action : MonoBehaviour
{
    public GameObject[] attackEffectPrefab; // 공격 이펙트 프리팹
    public float effectDistance = 1f;
    public float attackCooldown;
    public int comboCountLimit = 3;
    public float comboDelay; // 콤보 딜레이 시간 설정

    private float lastAttackTime = 0f; // 마지막 공격 시간
    private int comboCount = 0; // 콤보 카운트

    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 0.3f;
        comboDelay = 0.5f;
        attackEffectPrefab = new GameObject[3];
        attackEffectPrefab[0] = Resources.Load<GameObject>("skill/attack1");
        attackEffectPrefab[1] = Resources.Load<GameObject>("skill/attack2");
        attackEffectPrefab[2] = Resources.Load<GameObject>("skill/attack3");
        effectDistance = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            if (Time.time - lastAttackTime < comboDelay && comboCount < 2) // 일정 시간 내에 공격 버튼이 연속해서 눌린 경우
            {
                comboCount++; // 콤보 카운트 증가
            }
            else
            {
                comboCount = 0; // 첫 번째 공격
            }

            lastAttackTime = Time.time;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            Vector2 attackDirection = (mousePosition - transform.position).normalized;

            Vector3 effectPos = transform.position + (Vector3)attackDirection * effectDistance;

            GameObject attackEffect = Instantiate(attackEffectPrefab[comboCount], effectPos, Quaternion.identity);
            float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg + 90f;
            attackEffect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Destroy(attackEffect, 0.1f);
        }

        // 적 검색 후 공격
        //RaycastHit2D hits = Physics2D.Raycast(transform.position, attackDirection, attackDistance);
        //foreach (RaycastHit2D hit in hits)
        //{
        //    if (hit.collider.CompareTag("Enemy"))
        //    {
        //EnemyController enemyController = hit.collider.GetComponent<EnemyController>();
        //if (enemyController != null)
        //{
        //    enemyController.TakeDamage(10);
        //}
        //    }
        //}
    }
    
}
