using System.Collections.Generic;
using UnityEngine;

namespace ReplayGame
{
    /// <summary>
    /// Информация о всех записываемых объектах в определенный момент времени
    /// </summary>
    public class PointInTimeSettings
    {
        private List<ObjectInTimeSettings> _objectInPointList;
        public List<ObjectInTimeSettings> ObjectInPointList { get => _objectInPointList;}

        public PointInTimeSettings(List<GameObject> objectInTime)
        {
            _objectInPointList = new List<ObjectInTimeSettings>();
            foreach (GameObject obj in objectInTime)
            {
                ObjectInTimeSettings objInTime = new ObjectInTimeSettings(obj);
                _objectInPointList.Add(objInTime);
            }    
        }
    } 
}
