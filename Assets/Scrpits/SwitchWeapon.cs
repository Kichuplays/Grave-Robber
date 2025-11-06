using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject[] guns; //Array för att hålla Vapen GameObject
    private int currentGunIndex = 0; //Trackar aktiva vapnet
    [SerializeField] GameObject armShovel1;
    [SerializeField] GameObject armShovel2;
    [SerializeField] GameObject armDrill1;
    [SerializeField] GameObject armDrill2;
    void Start()
    {
        //Säkerstället att AK47 är aktiv i början
        SwitchGun(0);
        ArmShovel();
    }

    void Update()
    {
        //KeyInputs att switcha vapen
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(0); // Switch to Gun 1
            ArmShovel();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(1); // Switch to Gun 2
            ArmDrill();
        }
    }

    void SwitchGun(int gunIndex)
    {
        if (gunIndex < 0 || gunIndex >= guns.Length) return;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(i == gunIndex);
        }

        currentGunIndex = gunIndex;
    }

    void ArmShovel()
    {
        armShovel1.SetActive(true);
        armShovel2.SetActive(true);
        armDrill1.SetActive(false);
        armDrill2.SetActive(false);
    }

    void ArmDrill()
    {
        armShovel1.SetActive(false);
        armShovel2.SetActive(false);
        armDrill1.SetActive(true);
        armDrill2.SetActive(true);
    }
}
