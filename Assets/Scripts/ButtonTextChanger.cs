using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextChanger : MonoBehaviour
{
    [SerializeField] private Button Buttons; // Unity Editor에서 할당할 버튼
    [SerializeField] private string newText; // 변경할 텍스트

    private void Start()
    {
        ChangeButtonText(newText);
    }

    private void ChangeButtonText(string text)
    {
        // 버튼의 Text 컴포넌트에 접근
        Text buttonText = Buttons.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = text; // 텍스트 변경
        }
        else
        {
            Debug.LogError("버튼 컴포넌트를 찾을 수 없습니다.");
        }
    }
}
