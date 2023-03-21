using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default, _pressed; 
    [SerializeField] private AudioClip _compressClip;
    [SerializeField] private AudioSource _source;
    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }
}
