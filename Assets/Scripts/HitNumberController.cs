using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitNumberController : MonoBehaviour
{
    float moveUpSpeed = 60f;
    float disappearingSpeed = 3f;
    float disappearingTimer = 1f;
    Color textColor;

    TextMeshProUGUI text;

    private static Color defaultColor = new Color(255, 108, 4);

    public static HitNumberController SpawnHitNumber(Vector3 position)
    {
        Transform hitNum = Instantiate(Assets.i.HitNumberPrefab, position, Quaternion.identity, Assets.i.Canvas).transform;
        //hitNum.GetComponent<HitNumberController>().Setup(vertexColor, fontSize, text);
        return hitNum.GetComponent<HitNumberController>();
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        Debug.Log(GetComponents<Component>());
        Debug.Log(text);
    }

    public void Setup(int text, Color? vertexColor = null, int fontSize = 16)
    {
        if (vertexColor == null) vertexColor = new Color(255f / 255f, 108f / 255f, 4f / 255f);
        Setup(text.ToString(), vertexColor, fontSize);
    }

    public void Setup(string text, Color? vertexColor = null, int fontSize = 36)
    {
        if (vertexColor == null) vertexColor = new Color(255f / 255f, 108f / 255f, 4f / 255f);
        Debug.Log(this.text);
        Debug.Log(text);
        this.text.SetText(text);
        this.text.color = vertexColor.Value;
        this.text.fontSize = fontSize;
        textColor = vertexColor.Value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, moveUpSpeed) * Time.deltaTime;
        disappearingTimer -= Time.deltaTime;
        if (disappearingTimer < 0)
        {
            textColor.a -= disappearingSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0) Destroy(gameObject);
        }
    }
}
