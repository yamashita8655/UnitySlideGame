using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectState : StateBase {
	
	private List<Vector2> MovePositionList = null;
	/// <summary>
	/// 初期化後処理.
	/// </summary>
	override public void OnAfterInit()
	{
		MovePositionList = LineRendererManager.Instance.GetMovePositionList();
	}

	/// <summary>
	/// メイン更新処理.
	/// </summary>
	/// <param name="delta">経過時間</param>
	override public void OnUpdateMain(float delta)
	{
		if (MovePositionList.Count > 0) {
			GameObject obj = StateDataContainerManager.Instance.MoveObject;
			Vector2 pos = MovePositionList[0];
			MovePositionList.RemoveAt(0);

			obj.transform.localPosition = new Vector3(pos.x, pos.y, 0);
		}
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
