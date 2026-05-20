using UnityEngine;
using UnityEngine.EventSystems;

public class Hander : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public bool IsPointerUp { get; private set; } = false;
    public bool IsPointerDown { get; private set; } = false;
    private Camera _camera;
    private Vector2 _offset;
    [SerializeField] private MainCharacter _mainCharacter;

    private void Start()
    {
        _camera = Camera.main;
    }

    //つかみ始めたときの処理
    public void OnPointerDown(PointerEventData eventData)
    {
        IsPointerDown = true;
        IsPointerUp = false;
        Debug.Log("Pointer Down");
        Vector2 worldPosition = GetMouseWorldPosition(eventData);
        _offset = (Vector2)transform.position - worldPosition;
        if (_mainCharacter != null)
            _mainCharacter.IsMove = false;
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 worldPosition = GetMouseWorldPosition(eventData);
        transform.position = worldPosition + _offset;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        IsPointerUp = true;
        IsPointerDown = false;
        Debug.Log("Pointer Up");
        if (_mainCharacter != null)
            _mainCharacter.IsMove = true;
        //後で、シャツと客の合っているかどうかを客側でやる。
    }

    private Vector2 GetMouseWorldPosition(PointerEventData eventData)
    {
        Vector3 screenPosition = eventData.position;
        screenPosition.z = -_camera.transform.position.z;
        return _camera.ScreenToWorldPoint(screenPosition);
    }
}
