using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : MonoBehaviour {
	[SerializeField] GameObject MoveObject = null;
	[SerializeField] GameObject StartObject = null;
	[SerializeField] GameObject EndObject = null;

	// Use this for initialization
	void Start () {
		StateDataContainerManager.Instance.MoveObject = MoveObject;
		StateDataContainerManager.Instance.StartObject = StartObject;
		StateDataContainerManager.Instance.EndObject = EndObject;

        StateMachineManager.Instance.Init();
        StateMachineManager.Instance.CreateStateMachineMap(StateMachineName.InGame);
        StateMachineManager.Instance.AddState(StateMachineName.InGame, (int)StateNumber.DrawLine, new DrawLineState());
        StateMachineManager.Instance.AddState(StateMachineName.InGame, (int)StateNumber.MoveObject, new MoveObjectState());
        StateMachineManager.Instance.ChangeState(StateMachineName.InGame, (int)StateNumber.DrawLine);
	}
	
	// Update is called once per frame
	void Update () {
        StateMachineManager.Instance.Update(StateMachineName.InGame, Time.deltaTime);
	}

	public void OnClickMoveButton() {
        if (StateMachineManager.Instance.GetState(StateMachineName.InGame) == (int)StateNumber.DrawLine) {
			StateMachineManager.Instance.ChangeState(StateMachineName.InGame, (int)StateNumber.MoveObject);
		}
	}
}
