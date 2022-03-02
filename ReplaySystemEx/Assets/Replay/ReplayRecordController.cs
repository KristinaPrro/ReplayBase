using System.Collections.Generic;
using UnityEngine;

namespace ReplayGame
{
    public class ReplayRecordController : MonoBehaviour
	{
		[SerializeField] private ReplayViewingController _replayViewingController;
		[SerializeField] private List<GameObject> _objectToReplayGOList;

		private List<PointInTimeSettings> _frameReplayList = new List<PointInTimeSettings>();
		private bool _record = true;

		void FixedUpdate()
		{
			if (_record)
				Record();
		}

		void Record()
		{
			_frameReplayList.Add(new PointInTimeSettings(_objectToReplayGOList));
		}
		
		public void StartRecord()
		{
			_record = true;
			_frameReplayList = new List<PointInTimeSettings>();
		}

		public void StopRecord()
		{
			_record = false;
			SendDataForViewing();// for test
		}

        public void SendDataForViewing()
        {
            List<Rigidbody> _rigidbodyToReplayList = new List<Rigidbody>();
            foreach (GameObject obj in _objectToReplayGOList)
            {
				_rigidbodyToReplayList.Add(obj.GetComponent<Rigidbody>());
            }
            _replayViewingController.UpdateDataToView(_rigidbodyToReplayList, _frameReplayList);
        }
    }

}
