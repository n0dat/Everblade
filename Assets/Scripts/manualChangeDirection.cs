using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manualChangeDirection : MonoBehaviour
{

	public EnemyAI enemyAI;

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.direction.x < 0)
        	transform.localScale = new Vector3(-1, 1, 1);

        if (enemyAI.direction.x > 0)
        	transform.localScale = new Vector3(1, 1, 1);
    }
}
