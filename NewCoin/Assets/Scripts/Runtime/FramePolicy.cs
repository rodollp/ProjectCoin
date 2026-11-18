using UnityEngine;

public sealed class FramePolicy : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // 고정 FPS를 요청하지 않고 브라우저의 기본 프레임 스케줄링을 따릅니다.
        Application.targetFrameRate = -1;
#elif UNITY_ANDROID && !UNITY_EDITOR
        // 모바일의 목표 FPS는 targetFrameRate로 정합니다. 수업에서는 30으로 시작해 발열·전력을 비교합니다.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
#else
        // PC와 Editor는 화면 주사율을 따르도록 수직 동기화를 한 주기마다 수행합니다.
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;
#endif
    }
}