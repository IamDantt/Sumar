using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    START_GAME,
    INICIO,
    AR,
    PERFIL,
    OPCIONES,
    INFO,
    APRENDE,
    CONFIG,
    END_GAME
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.START_GAME:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                canvasManager.SwitchCanvas(CanvasType.StartMenu);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.OPCIONES:
                canvasManager.SwitchCanvas(CanvasType.Opciones);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.AR:
                canvasManager.SwitchCanvas(CanvasType.Ar);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.INICIO:
                canvasManager.SwitchCanvas(CanvasType.Inicio);
                //Musica
                break;
            case ButtonType.PERFIL:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Perfil);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.APRENDE:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Aprende);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.INFO:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.info);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            case ButtonType.CONFIG:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Config);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;            
            case ButtonType.END_GAME:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.EndScreen);
                //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
                break;
            default:
                break;
        }
    }
}
