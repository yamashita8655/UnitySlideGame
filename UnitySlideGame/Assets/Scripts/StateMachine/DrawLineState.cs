using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineState : StateBase {
	/// <summary>
	/// 初期化後処理.
	/// </summary>
	override public void OnAfterInit()
	{
		LineRendererManager.Instance.Initialize();
	}

	/// <summary>
	/// メイン更新処理.
	/// </summary>
	/// <param name="delta">経過時間</param>
	override public void OnUpdateMain(float delta)
	{
		//StateMachineManager.Instance.ChangeState(StateMachineName.InGame, 1);
	}

	/// <summary>
	/// メイン後処理.
	/// </summary>
	override public void OnAfterMain()
	{
	}

	/// <summary>
	/// ステート解放時処理.
	/// </summary>
	override public void OnRelease()
	{
	}
}
