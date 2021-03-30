using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 camOffset;
    GameObject playerToFollow;
    private Vector3 _playerPos;
    private Vector3 _posFollow;
    private bool _isAirCam;
    public float _lerpSpeed = 0.125f;

    // Start is called before the first frame update

    void Start()
    {
        playerToFollow = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var posFollow = playerToFollow.transform.position;
        
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(posFollow.x + camOffset.x, (_isAirCam) ? posFollow.y + camOffset.y : 0, -4),
            _lerpSpeed);
    }

    public void AirCamOn()
    {
        //StartCoroutine(lerpCameraPos());
        if (!_isAirCam) _isAirCam = true;
    }

    public void AirCamOff()
    {
        if (_isAirCam) _isAirCam = false;
    }

    /*public void FocusCenterOff()
    {
        if (posY != 0)
        {
            StartCoroutine(lerpCameraPos(false));
        }
    }*/

    /*IEnumerator lerpCameraPos(bool airCam = true)
    {
        float timeElapsed = default;
        timeElapsed += Time.deltaTime;
        _playerPos = playerToFollow.transform.position;
        
        if (timeElapsed < 1f)
        {
            posY = Mathf.Lerp(
                (airCam) ? 0 : _playerPos.y + camOffset.y,
                (!airCam) ? 0 : _playerPos.y + camOffset.y,
                2 * Time.deltaTime);
            yield return null;
        }
        
        yield return null;
    }*/
}