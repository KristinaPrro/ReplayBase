using System.Collections;
using UnityEngine;

namespace ReplayGame
{
/// <summary>
/// Вся информация о записываемом объекте
/// </summary>
    public class ObjectInTimeSettings 
    {
        private GameObject _gameObject;        
        private Vector3 _position;
        private Quaternion _rotation;
        private Vector3 _scale;

        public GameObject Object { get => _gameObject; }
        public Vector3 Position { get => _position; }
        public Quaternion Rotation { get => _rotation; }
        public Vector3 Scale { get => _scale; }

        public ObjectInTimeSettings(GameObject gameObject)
        {
            _gameObject = gameObject;
            _position = gameObject.transform.position;
            _rotation = gameObject.transform.rotation;
            _scale = gameObject.transform.lossyScale;
        }
    }
}
