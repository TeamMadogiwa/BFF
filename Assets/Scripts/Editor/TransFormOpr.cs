using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormOpr : MonoBehaviour {

	public Vector3 SetPositionY(Vector3 pos, Vector3 set)
	{
		return new Vector3(pos.x, set.y, pos.z);
	}
}
