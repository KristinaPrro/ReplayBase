using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReplayGame
{

    public class ReplayViewingController : MonoBehaviour
	{
		[SerializeField] private float _speedReplay = 1;

		private List<PointInTimeSettings> _frameReplayList = new List<PointInTimeSettings>();
		private List<Rigidbody> _rigidbodyToReplayList;
		private IEnumerator _replay;
		private bool _pause = false;
		
		//можно заменить на конструктор:
		public void UpdateDataToView(List<Rigidbody> rigidbodyToReplayList, List<PointInTimeSettings> frameReplay)
		{
			_frameReplayList=frameReplay;
			_rigidbodyToReplayList= rigidbodyToReplayList;
			_replay = Replay();
		}
       
        IEnumerator Replay()
		{
			for (int i = 0; i < _frameReplayList.Count; i++)
			{
				foreach (ObjectInTimeSettings obj in _frameReplayList[i].ObjectInPointList)
				{
					Transform _object = obj.Object.transform;
					_object.position = obj.Position;
					_object.rotation = obj.Rotation;
				}
				yield return new WaitForSeconds(Time.fixedDeltaTime / _speedReplay);
			}
			UpdateTheInfluenceOfPhysics(true);
		}

		public void StartReplay()
		{
			UpdateTheInfluenceOfPhysics(false);
			_replay = Replay();
			StartCoroutine(_replay);
		}

		public void PauseReplay()
		{
			if (_pause)
				StartCoroutine(_replay);
			else
				StopCoroutine(_replay);
			_pause = !_pause ;
		}

		public void UpdateSpeedReplay(float speed)
		{
			_speedReplay = speed;
		}

		private void UpdateTheInfluenceOfPhysics(bool sw)
		{
			foreach (Rigidbody rb in _rigidbodyToReplayList)
			{
				rb.isKinematic = !sw;
			}
		}
	}
}
