using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : BaseGimmick
{

    private float speed = 3.0f;
    private Vector3 moveVector = new Vector3(1.0f, 0.0f, 0.0f);
    //readonlyにしてコンストラクタで呼びたいがわざわざそのため別クラスつくるのもなぁー
    private float DistanceLimit = 3.0f;

    private float distance = .0f;
    private float direction = 1.0f;

    new void Awake()
    {
        base.Awake();
        speed = Random.Range(2.0f, 5.0f);
        moveVector = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), .0f);
        DistanceLimit = Random.Range(1.0f, 4.5f);
    }

    public void Update()
	{
        Move();
    }

    private void Move()
    {

        if (moveVector.sqrMagnitude <= 0)
            return;

        Vector3 value = moveVector * speed * Time.deltaTime;
        //magnitudeは小数点第4位未満は0になるからよろしく
        distance += value.magnitude;

        if (distance > DistanceLimit)
        {
            distance = .0f;
            direction = -direction;
        }

        cashedTransform.position += value * direction;
    }
}
