using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public GameObject Gdori;
    GdoriController gdoriController;
    Rigidbody2D body;
    private int currentStep;
    List<string> tutorialSteps = new List<string>()
    {
        "��,A : ���� �̵�",
        "��,D : ������ �̵�",
        "�����̽��� : ����",
        "���߿��� �����̽��� : �̴� ����",
        "����Ʈ : �޸���",
        "������ �����ϼ���. (R : �����)"
    };
    private void Start()
    {
        body = Gdori.GetComponent<Rigidbody2D>();
        gdoriController = Gdori.GetComponent<GdoriController>();
        currentStep = 0;
        tmp.text = tutorialSteps[currentStep];
    }

    private void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (body.velocity.x < -0.9) nextTutorial();
                break;
            case 1:
                if (body.velocity.x > 0.9) nextTutorial();
                break;
            case 2:
                if (body.velocity.y > 1) nextTutorial();
                break;
            case 3:
                if (gdoriController.currentJumpCount == 2) nextTutorial();
                break;
            case 4:
                if (body.velocity.x < -1.1f || body.velocity.x > 1.1f) nextTutorial();
                break;
            case 5:
                Invoke("nextTutorial", 5.0f);
                break;
            default:
                nextTutorial();
                break;
        }
    }

    public void nextTutorial()
    {
        currentStep++;
        if(currentStep < tutorialSteps.Count) tmp.text = tutorialSteps[currentStep];
        else this.gameObject.SetActive(false);
    }


}
