using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Sprite[] active_spells;
    public Sprite[] inactive_spells;
    public Sprite[] active_cd;
    public Sprite[] inactive_cd;

    public int[] spell_cd_base;
    public int[] spell_cd_current;
    public int[] spell_cd_left;

    public Sprite active_boots;
    public Sprite active_rune;

    public Sprite inactive_boots;
    public Sprite inactive_rune;

    public Button spell_top_1;
    public Button spell_top_2;
    public Button spell_jg_1;
    public Button spell_jg_2;
    public Button spell_mid_1;
    public Button spell_mid_2;
    public Button spell_adc_1;
    public Button spell_adc_2;
    public Button spell_supp_1;
    public Button spell_supp_2;

    public Button boots_top;
    public Button rune_top;
    public Button boots_jg;
    public Button rune_jg;
    public Button boots_mid;
    public Button rune_mid;
    public Button boots_adc;
    public Button rune_adc;
    public Button boots_supp;
    public Button rune_supp;

    public Button change_top_1;
    public Button change_top_2;
    public Button change_jg_1;
    public Button change_jg_2;
    public Button change_mid_1;
    public Button change_mid_2;
    public Button change_adc_1;
    public Button change_adc_2;
    public Button change_supp_1;
    public Button change_supp_2;

    public Text cd_top_1;
    public Text cd_top_2;
    public Text cd_jg_1;
    public Text cd_jg_2;
    public Text cd_mid_1;
    public Text cd_mid_2;
    public Text cd_adc_1;
    public Text cd_adc_2;
    public Text cd_supp_1;
    public Text cd_supp_2;

    public Button spell_barrier;
    public Button spell_cleanse;
    public Button spell_exhaust;
    public Button spell_flash;
    public Button spell_ghost;
    public Button spell_heal;
    public Button spell_ignite;
    public Button spell_smite;
    public Button spell_teleport;
    
    public GameObject panel_change;
    public GameObject panel_reset;

    public Button button_ok;
    public Button button_cancel;
    public Button spell_change_cancel;
    public Button button_exit;
    public Button button_credit;

    public bool[] reset_checker;
    public bool[] spell_change;

    public AudioSource cd_finish_barrier_top;
    public AudioSource cd_finish_barrier_jg;
    public AudioSource cd_finish_barrier_mid;
    public AudioSource cd_finish_barrier_adc;
    public AudioSource cd_finish_barrier_supp;
    public AudioSource cd_finish_cleanse_top;
    public AudioSource cd_finish_cleanse_jg;
    public AudioSource cd_finish_cleanse_mid;
    public AudioSource cd_finish_cleanse_adc;
    public AudioSource cd_finish_cleanse_supp;
    public AudioSource cd_finish_exhaust_top;
    public AudioSource cd_finish_exhaust_jg;
    public AudioSource cd_finish_exhaust_mid;
    public AudioSource cd_finish_exhaust_adc;
    public AudioSource cd_finish_exhaust_supp;
    public AudioSource cd_finish_flash_top;
    public AudioSource cd_finish_flash_jg;
    public AudioSource cd_finish_flash_mid;
    public AudioSource cd_finish_flash_adc;
    public AudioSource cd_finish_flash_supp;
    public AudioSource cd_finish_ghost_top;
    public AudioSource cd_finish_ghost_jg;
    public AudioSource cd_finish_ghost_mid;
    public AudioSource cd_finish_ghost_adc;
    public AudioSource cd_finish_ghost_supp;
    public AudioSource cd_finish_heal_top;
    public AudioSource cd_finish_heal_jg;
    public AudioSource cd_finish_heal_mid;
    public AudioSource cd_finish_heal_adc;
    public AudioSource cd_finish_heal_supp;
    public AudioSource cd_finish_ignite_top;
    public AudioSource cd_finish_ignite_jg;
    public AudioSource cd_finish_ignite_mid;
    public AudioSource cd_finish_ignite_adc;
    public AudioSource cd_finish_ignite_supp;
    public AudioSource cd_finish_smite_top;
    public AudioSource cd_finish_smite_jg;
    public AudioSource cd_finish_smite_mid;
    public AudioSource cd_finish_smite_adc;
    public AudioSource cd_finish_smite_supp;
    public AudioSource cd_finish_teleport_top;
    public AudioSource cd_finish_teleport_jg;
    public AudioSource cd_finish_teleport_mid;
    public AudioSource cd_finish_teleport_adc;
    public AudioSource cd_finish_teleport_supp;

    public AudioClip sound_barrier_top;
    public AudioClip sound_barrier_jg;
    public AudioClip sound_barrier_mid;
    public AudioClip sound_barrier_adc;
    public AudioClip sound_barrier_supp;
    public AudioClip sound_cleanse_top;
    public AudioClip sound_cleanse_jg;
    public AudioClip sound_cleanse_mid;
    public AudioClip sound_cleanse_adc;
    public AudioClip sound_cleanse_supp;
    public AudioClip sound_exhaust_top;
    public AudioClip sound_exhaust_jg;
    public AudioClip sound_exhaust_mid;
    public AudioClip sound_exhaust_adc;
    public AudioClip sound_exhaust_supp;
    public AudioClip sound_flash_top;
    public AudioClip sound_flash_jg;
    public AudioClip sound_flash_mid;
    public AudioClip sound_flash_adc;
    public AudioClip sound_flash_supp;
    public AudioClip sound_ghost_top;
    public AudioClip sound_ghost_jg;
    public AudioClip sound_ghost_mid;
    public AudioClip sound_ghost_adc;
    public AudioClip sound_ghost_supp;
    public AudioClip sound_heal_top;
    public AudioClip sound_heal_jg;
    public AudioClip sound_heal_mid;
    public AudioClip sound_heal_adc;
    public AudioClip sound_heal_supp;
    public AudioClip sound_ignite_top;
    public AudioClip sound_ignite_jg;
    public AudioClip sound_ignite_mid;
    public AudioClip sound_ignite_adc;
    public AudioClip sound_ignite_supp;
    public AudioClip sound_smite_top;
    public AudioClip sound_smite_jg;
    public AudioClip sound_smite_mid;
    public AudioClip sound_smite_adc;
    public AudioClip sound_smite_supp;
    public AudioClip sound_teleport_top;
    public AudioClip sound_teleport_jg;
    public AudioClip sound_teleport_mid;
    public AudioClip sound_teleport_adc;
    public AudioClip sound_teleport_supp;

    // Start is called before the first frame update
    void Start()
    {
        panel_change.SetActive(false);
        panel_reset.SetActive(false);

        reset_checker = new bool[10];
        spell_change = new bool[10];
        spell_cd_left = new int[10];
        for (int i = 0; i < 10; i++)
        {
            reset_checker[i] = false;
            spell_change[i] = false;
            spell_cd_left[i] = 0;
        }

        button_ok.image.sprite = Resources.Load<Sprite>("button_ok");
        button_cancel.image.sprite = Resources.Load<Sprite>("button_cancel");
        spell_change_cancel.image.sprite = Resources.Load<Sprite>("button_cancel");
        button_credit.image.sprite = Resources.Load<Sprite>("button_credit");
        button_exit.image.sprite = Resources.Load<Sprite>("button_exit");

        active_spells = new Sprite[9];
        active_spells[0] = Resources.Load<Sprite>("spell_framed_active_barrier_70x70");
        active_spells[1] = Resources.Load<Sprite>("spell_framed_active_cleanse_70x70");
        active_spells[2] = Resources.Load<Sprite>("spell_framed_active_exhaust_70x70");
        active_spells[3] = Resources.Load<Sprite>("spell_framed_active_flash_70x70");
        active_spells[4] = Resources.Load<Sprite>("spell_framed_active_ghost_70x70");
        active_spells[5] = Resources.Load<Sprite>("spell_framed_active_heal_70x70");
        active_spells[6] = Resources.Load<Sprite>("spell_framed_active_ignite_70x70");
        active_spells[7] = Resources.Load<Sprite>("spell_framed_active_smite_70x70");
        active_spells[8] = Resources.Load<Sprite>("spell_framed_active_teleport_70x70");

        inactive_spells = new Sprite[9];
        inactive_spells[0] = Resources.Load<Sprite>("spell_framed_inactive_barrier_70x70_satin");
        inactive_spells[1] = Resources.Load<Sprite>("spell_framed_inactive_cleanse_70x70_satin");
        inactive_spells[2] = Resources.Load<Sprite>("spell_framed_inactive_exhaust_70x70_satin");
        inactive_spells[3] = Resources.Load<Sprite>("spell_framed_inactive_flash_70x70_satin");
        inactive_spells[4] = Resources.Load<Sprite>("spell_framed_inactive_ghost_70x70_satin");
        inactive_spells[5] = Resources.Load<Sprite>("spell_framed_inactive_heal_70x70_satin");
        inactive_spells[6] = Resources.Load<Sprite>("spell_framed_inactive_ignite_70x70_satin");
        inactive_spells[7] = Resources.Load<Sprite>("spell_framed_inactive_smite_70x70_satin");
        inactive_spells[8] = Resources.Load<Sprite>("spell_framed_inactive_teleport_70x70_satin");

        spell_barrier.image.sprite = active_spells[0];
        spell_cleanse.image.sprite = active_spells[1];
        spell_exhaust.image.sprite = active_spells[2];
        spell_flash.image.sprite = active_spells[3];
        spell_ghost.image.sprite = active_spells[4];
        spell_heal.image.sprite = active_spells[5];
        spell_ignite.image.sprite = active_spells[6];
        spell_smite.image.sprite = active_spells[7];
        spell_teleport.image.sprite = active_spells[8];

        active_cd = new Sprite[2];
        active_cd[0] = Resources.Load<Sprite>("cd_framed_active_rune_36x36");
        active_cd[1] = Resources.Load<Sprite>("cd_framed_active_item_36x36");

        inactive_cd = new Sprite[2];
        inactive_cd[0] = Resources.Load<Sprite>("cd_framed_inactive_rune_36x36");
        inactive_cd[1] = Resources.Load<Sprite>("cd_framed_inactive_item_36x36");

        spell_cd_base = new int[9];
        spell_cd_base[0] = 180;
        spell_cd_base[1] = 240;
        spell_cd_base[2] = 210;
        spell_cd_base[3] = 300;
        spell_cd_base[4] = 180;
        spell_cd_base[5] = 240;
        spell_cd_base[6] = 210;
        spell_cd_base[7] = 90;
        spell_cd_base[8] = 360;

        spell_top_1.image.sprite = active_spells[3];
        spell_top_2.image.sprite = active_spells[8];
        spell_jg_1.image.sprite = active_spells[3];
        spell_jg_2.image.sprite = active_spells[7];
        spell_mid_1.image.sprite = active_spells[3];
        spell_mid_2.image.sprite = active_spells[6];
        spell_adc_1.image.sprite = active_spells[3];
        spell_adc_2.image.sprite = active_spells[5];
        spell_supp_1.image.sprite = active_spells[3];
        spell_supp_2.image.sprite = active_spells[2];

        boots_top.image.sprite = inactive_cd[1];
        rune_top.image.sprite = inactive_cd[0];
        boots_jg.image.sprite = inactive_cd[1];
        rune_jg.image.sprite = inactive_cd[0];
        boots_mid.image.sprite = inactive_cd[1];
        rune_mid.image.sprite = inactive_cd[0];
        boots_adc.image.sprite = inactive_cd[1];
        rune_adc.image.sprite = inactive_cd[0];
        boots_supp.image.sprite = inactive_cd[1];
        rune_supp.image.sprite = inactive_cd[0];

        change_top_1.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_top_2.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_jg_1.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_jg_2.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_mid_1.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_mid_2.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_adc_1.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_adc_2.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_supp_1.image.sprite = Resources.Load<Sprite>("button_spell_change");
        change_supp_2.image.sprite = Resources.Load<Sprite>("button_spell_change");

        cd_top_1.enabled = false;
        cd_top_2.enabled = false;
        cd_jg_1.enabled = false;
        cd_jg_2.enabled = false;
        cd_mid_1.enabled = false;
        cd_mid_2.enabled = false;
        cd_adc_1.enabled = false;
        cd_adc_2.enabled = false;
        cd_supp_1.enabled = false;
        cd_supp_2.enabled = false;

        spell_cd_current = new int[10];
        spell_cd_current[0] = 300;
        spell_cd_current[1] = 360;
        spell_cd_current[2] = 300;
        spell_cd_current[3] = 90;
        spell_cd_current[4] = 300;
        spell_cd_current[5] = 210;
        spell_cd_current[6] = 300;
        spell_cd_current[7] = 240;
        spell_cd_current[8] = 300;
        spell_cd_current[9] = 210;
    }
    
    public void ButtonExit()
    {
        Application.Quit();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(cd_top_1.enabled == true)
        {
            cd_top_1.text = spell_cd_left[0].ToString() + "s";
            if(spell_cd_left[0] == 0)
            {
                cd_top_1.enabled = false;
                for(int i = 0; i < 9; i++)
                {
                    if(spell_top_1.image.sprite == inactive_spells[i])
                    {
                        spell_top_1.image.sprite = active_spells[i];
                        switch(i)
                        {
                            case 0:
                                cd_finish_barrier_top.PlayOneShot(sound_barrier_top);
                                break;
                            case 1:
                                cd_finish_cleanse_top.PlayOneShot(sound_cleanse_top);
                                break;
                            case 2:
                                cd_finish_exhaust_top.PlayOneShot(sound_exhaust_top);
                                break;
                            case 3:
                                cd_finish_flash_top.PlayOneShot(sound_flash_top);
                                break;
                            case 4:
                                cd_finish_ghost_top.PlayOneShot(sound_ghost_top);
                                break;
                            case 5:
                                cd_finish_heal_top.PlayOneShot(sound_heal_top);
                                break;
                            case 6:
                                cd_finish_ignite_top.PlayOneShot(sound_ignite_top);
                                break;
                            case 7:
                                cd_finish_smite_top.PlayOneShot(sound_smite_top);
                                break;
                            case 8:
                                cd_finish_teleport_top.PlayOneShot(sound_teleport_top);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_top_2.enabled == true)
        {
            cd_top_2.text = spell_cd_left[1].ToString() + "s";
            if (spell_cd_left[1] == 0)
            {
                cd_top_2.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_top_2.image.sprite == inactive_spells[i])
                    {
                        spell_top_2.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_top.PlayOneShot(sound_barrier_top);
                                break;
                            case 1:
                                cd_finish_cleanse_top.PlayOneShot(sound_cleanse_top);
                                break;
                            case 2:
                                cd_finish_exhaust_top.PlayOneShot(sound_exhaust_top);
                                break;
                            case 3:
                                cd_finish_flash_top.PlayOneShot(sound_flash_top);
                                break;
                            case 4:
                                cd_finish_ghost_top.PlayOneShot(sound_ghost_top);
                                break;
                            case 5:
                                cd_finish_heal_top.PlayOneShot(sound_heal_top);
                                break;
                            case 6:
                                cd_finish_ignite_top.PlayOneShot(sound_ignite_top);
                                break;
                            case 7:
                                cd_finish_smite_top.PlayOneShot(sound_smite_top);
                                break;
                            case 8:
                                cd_finish_teleport_top.PlayOneShot(sound_teleport_top);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_jg_1.enabled == true)
        {
            cd_jg_1.text = spell_cd_left[2].ToString() + "s";
            if (spell_cd_left[2] == 0)
            {
                cd_jg_1.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_jg_1.image.sprite == inactive_spells[i])
                    {
                        spell_jg_1.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_jg.PlayOneShot(sound_barrier_jg);
                                break;
                            case 1:
                                cd_finish_cleanse_jg.PlayOneShot(sound_cleanse_jg);
                                break;
                            case 2:
                                cd_finish_exhaust_jg.PlayOneShot(sound_exhaust_jg);
                                break;
                            case 3:
                                cd_finish_flash_jg.PlayOneShot(sound_flash_jg);
                                break;
                            case 4:
                                cd_finish_ghost_jg.PlayOneShot(sound_ghost_jg);
                                break;
                            case 5:
                                cd_finish_heal_jg.PlayOneShot(sound_heal_jg);
                                break;
                            case 6:
                                cd_finish_ignite_jg.PlayOneShot(sound_ignite_jg);
                                break;
                            case 7:
                                cd_finish_smite_jg.PlayOneShot(sound_smite_jg);
                                break;
                            case 8:
                                cd_finish_teleport_jg.PlayOneShot(sound_teleport_jg);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_jg_2.enabled == true)
        {
            cd_jg_2.text = spell_cd_left[3].ToString() + "s";
            if (spell_cd_left[3] == 0)
            {
                cd_jg_2.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_jg_2.image.sprite == inactive_spells[i])
                    {
                        spell_jg_2.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_jg.PlayOneShot(sound_barrier_jg);
                                break;
                            case 1:
                                cd_finish_cleanse_jg.PlayOneShot(sound_cleanse_jg);
                                break;
                            case 2:
                                cd_finish_exhaust_jg.PlayOneShot(sound_exhaust_jg);
                                break;
                            case 3:
                                cd_finish_flash_jg.PlayOneShot(sound_flash_jg);
                                break;
                            case 4:
                                cd_finish_ghost_jg.PlayOneShot(sound_ghost_jg);
                                break;
                            case 5:
                                cd_finish_heal_jg.PlayOneShot(sound_heal_jg);
                                break;
                            case 6:
                                cd_finish_ignite_jg.PlayOneShot(sound_ignite_jg);
                                break;
                            case 7:
                                cd_finish_smite_jg.PlayOneShot(sound_smite_jg);
                                break;
                            case 8:
                                cd_finish_teleport_jg.PlayOneShot(sound_teleport_jg);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_mid_1.enabled == true)
        {
            cd_mid_1.text = spell_cd_left[4].ToString() + "s";
            if (spell_cd_left[4] == 0)
            {
                cd_mid_1.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_mid_1.image.sprite == inactive_spells[i])
                    {
                        spell_mid_1.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_mid.PlayOneShot(sound_barrier_mid);
                                break;
                            case 1:
                                cd_finish_cleanse_mid.PlayOneShot(sound_cleanse_mid);
                                break;
                            case 2:
                                cd_finish_exhaust_mid.PlayOneShot(sound_exhaust_mid);
                                break;
                            case 3:
                                cd_finish_flash_mid.PlayOneShot(sound_flash_mid);
                                break;
                            case 4:
                                cd_finish_ghost_mid.PlayOneShot(sound_ghost_mid);
                                break;
                            case 5:
                                cd_finish_heal_mid.PlayOneShot(sound_heal_mid);
                                break;
                            case 6:
                                cd_finish_ignite_mid.PlayOneShot(sound_ignite_mid);
                                break;
                            case 7:
                                cd_finish_smite_mid.PlayOneShot(sound_smite_mid);
                                break;
                            case 8:
                                cd_finish_teleport_mid.PlayOneShot(sound_teleport_mid);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_mid_2.enabled == true)
        {
            cd_mid_2.text = spell_cd_left[5].ToString() + "s";
            if (spell_cd_left[5] == 0)
            {
                cd_mid_2.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_mid_2.image.sprite == inactive_spells[i])
                    {
                        spell_mid_2.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_mid.PlayOneShot(sound_barrier_mid);
                                break;
                            case 1:
                                cd_finish_cleanse_mid.PlayOneShot(sound_cleanse_mid);
                                break;
                            case 2:
                                cd_finish_exhaust_mid.PlayOneShot(sound_exhaust_mid);
                                break;
                            case 3:
                                cd_finish_flash_mid.PlayOneShot(sound_flash_mid);
                                break;
                            case 4:
                                cd_finish_ghost_mid.PlayOneShot(sound_ghost_mid);
                                break;
                            case 5:
                                cd_finish_heal_mid.PlayOneShot(sound_heal_mid);
                                break;
                            case 6:
                                cd_finish_ignite_mid.PlayOneShot(sound_ignite_mid);
                                break;
                            case 7:
                                cd_finish_smite_mid.PlayOneShot(sound_smite_mid);
                                break;
                            case 8:
                                cd_finish_teleport_mid.PlayOneShot(sound_teleport_mid);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_adc_1.enabled == true)
        {
            cd_adc_1.text = spell_cd_left[6].ToString() + "s";
            if (spell_cd_left[6] == 0)
            {
                cd_adc_1.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_adc_1.image.sprite == inactive_spells[i])
                    {
                        spell_adc_1.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_adc.PlayOneShot(sound_barrier_adc);
                                break;
                            case 1:
                                cd_finish_cleanse_adc.PlayOneShot(sound_cleanse_adc);
                                break;
                            case 2:
                                cd_finish_exhaust_adc.PlayOneShot(sound_exhaust_adc);
                                break;
                            case 3:
                                cd_finish_flash_adc.PlayOneShot(sound_flash_adc);
                                break;
                            case 4:
                                cd_finish_ghost_adc.PlayOneShot(sound_ghost_adc);
                                break;
                            case 5:
                                cd_finish_heal_adc.PlayOneShot(sound_heal_adc);
                                break;
                            case 6:
                                cd_finish_ignite_adc.PlayOneShot(sound_ignite_adc);
                                break;
                            case 7:
                                cd_finish_smite_adc.PlayOneShot(sound_smite_adc);
                                break;
                            case 8:
                                cd_finish_teleport_adc.PlayOneShot(sound_teleport_adc);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_adc_2.enabled == true)
        {
            cd_adc_2.text = spell_cd_left[7].ToString() + "s";
            if (spell_cd_left[7] == 0)
            {
                cd_adc_2.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_adc_2.image.sprite == inactive_spells[i])
                    {
                        spell_adc_2.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_adc.PlayOneShot(sound_barrier_adc);
                                break;
                            case 1:
                                cd_finish_cleanse_adc.PlayOneShot(sound_cleanse_adc);
                                break;
                            case 2:
                                cd_finish_exhaust_adc.PlayOneShot(sound_exhaust_adc);
                                break;
                            case 3:
                                cd_finish_flash_adc.PlayOneShot(sound_flash_adc);
                                break;
                            case 4:
                                cd_finish_ghost_adc.PlayOneShot(sound_ghost_adc);
                                break;
                            case 5:
                                cd_finish_heal_adc.PlayOneShot(sound_heal_adc);
                                break;
                            case 6:
                                cd_finish_ignite_adc.PlayOneShot(sound_ignite_adc);
                                break;
                            case 7:
                                cd_finish_smite_adc.PlayOneShot(sound_smite_adc);
                                break;
                            case 8:
                                cd_finish_teleport_adc.PlayOneShot(sound_teleport_adc);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_supp_1.enabled == true)
        {
            cd_supp_1.text = spell_cd_left[8].ToString() + "s";
            if (spell_cd_left[8] == 0)
            {
                cd_supp_1.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_supp_1.image.sprite == inactive_spells[i])
                    {
                        spell_supp_1.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_supp.PlayOneShot(sound_barrier_supp);
                                break;
                            case 1:
                                cd_finish_cleanse_supp.PlayOneShot(sound_cleanse_supp);
                                break;
                            case 2:
                                cd_finish_exhaust_supp.PlayOneShot(sound_exhaust_supp);
                                break;
                            case 3:
                                cd_finish_flash_supp.PlayOneShot(sound_flash_supp);
                                break;
                            case 4:
                                cd_finish_ghost_supp.PlayOneShot(sound_ghost_supp);
                                break;
                            case 5:
                                cd_finish_heal_supp.PlayOneShot(sound_heal_supp);
                                break;
                            case 6:
                                cd_finish_ignite_supp.PlayOneShot(sound_ignite_supp);
                                break;
                            case 7:
                                cd_finish_smite_supp.PlayOneShot(sound_smite_supp);
                                break;
                            case 8:
                                cd_finish_teleport_supp.PlayOneShot(sound_teleport_supp);
                                break;
                        }
                    }
                }
            }
        }

        if (cd_supp_2.enabled == true)
        {
            cd_supp_2.text = spell_cd_left[9].ToString() + "s";
            if (spell_cd_left[9] == 0)
            {
                cd_supp_2.enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    if (spell_supp_2.image.sprite == inactive_spells[i])
                    {
                        spell_supp_2.image.sprite = active_spells[i];
                        switch (i)
                        {
                            case 0:
                                cd_finish_barrier_supp.PlayOneShot(sound_barrier_supp);
                                break;
                            case 1:
                                cd_finish_cleanse_supp.PlayOneShot(sound_cleanse_supp);
                                break;
                            case 2:
                                cd_finish_exhaust_supp.PlayOneShot(sound_exhaust_supp);
                                break;
                            case 3:
                                cd_finish_flash_supp.PlayOneShot(sound_flash_supp);
                                break;
                            case 4:
                                cd_finish_ghost_supp.PlayOneShot(sound_ghost_supp);
                                break;
                            case 5:
                                cd_finish_heal_supp.PlayOneShot(sound_heal_supp);
                                break;
                            case 6:
                                cd_finish_ignite_supp.PlayOneShot(sound_ignite_supp);
                                break;
                            case 7:
                                cd_finish_smite_supp.PlayOneShot(sound_smite_supp);
                                break;
                            case 8:
                                cd_finish_teleport_supp.PlayOneShot(sound_teleport_supp);
                                break;
                        }
                    }
                }
            }
        }
    }

    IEnumerator CooldownTop1()
    {
        while(spell_cd_left[0] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[0]--;
        }
    }

    IEnumerator CooldownTop2()
    {
        while(spell_cd_left[1] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[1]--;
        }
    }

    IEnumerator CooldownJg1()
    {
        while (spell_cd_left[2] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[2]--;
        }
    }

    IEnumerator CooldownJg2()
    {
        while (spell_cd_left[3] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[3]--;
        }
    }

    IEnumerator CooldownMid1()
    {
        while (spell_cd_left[4] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[4]--;
        }
    }

    IEnumerator CooldownMid2()
    {
        while (spell_cd_left[5] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[5]--;
        }
    }

    IEnumerator CooldownAdc1()
    {
        while (spell_cd_left[6] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[6]--;
        }
    }

    IEnumerator CooldownAdc2()
    {
        while (spell_cd_left[7] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[7]--;
        }
    }

    IEnumerator CooldownSupp1()
    {
        while (spell_cd_left[8] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[8]--;
        }
    }

    IEnumerator CooldownSupp2()
    {
        while (spell_cd_left[9] > 0)
        {
            yield return new WaitForSeconds(1);
            spell_cd_left[9]--;
        }
    }

    void Awake()
    {
        Instance = this;
    }

    public void SpellTop1Button()
    {
        for(int i = 0; i < 9; i++)
        {
            if(spell_top_1.image.sprite == active_spells[i])
            {
                spell_top_1.image.sprite = inactive_spells[i];
                spell_cd_current[0] = spell_cd_base[i];

                if(boots_top.image.sprite == active_cd[1] && rune_top.image.sprite == active_cd[0])
                {
                    spell_cd_current[0] = spell_cd_current[0] * 85 / 100;
                }
                else if(boots_top.image.sprite != active_cd[1] && rune_top.image.sprite == active_cd[0])
                {
                    spell_cd_current[0] = spell_cd_current[0] * 95 / 100;
                }
                else if(boots_top.image.sprite == active_cd[1] && rune_top.image.sprite != active_cd[0])
                {
                    spell_cd_current[0] = spell_cd_current[0] * 90 / 100;
                }

                spell_cd_left[0] = spell_cd_current[0];
                cd_top_1.enabled = true;
                StartCoroutine("CooldownTop1");
            }
            else if(spell_top_1.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[0] = 0;
                reset_checker[0] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellTop2Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_top_2.image.sprite == active_spells[i])
            {
                spell_top_2.image.sprite = inactive_spells[i];
                spell_cd_current[1] = spell_cd_base[i];

                if (boots_top.image.sprite == active_cd[1] && rune_top.image.sprite == active_cd[0])
                {
                    spell_cd_current[1] = spell_cd_current[1] * 85 / 100;
                }
                else if (boots_top.image.sprite != active_cd[1] && rune_top.image.sprite == active_cd[0])
                {
                    spell_cd_current[1] = spell_cd_current[1] * 95 / 100;
                }
                else if (boots_top.image.sprite == active_cd[1] && rune_top.image.sprite != active_cd[0])
                {
                    spell_cd_current[1] = spell_cd_current[1] * 90 / 100;
                }

                spell_cd_left[1] = spell_cd_current[1];
                cd_top_2.enabled = true;
                StartCoroutine("CooldownTop2");
            }
            else if (spell_top_2.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[1] = 0;
                reset_checker[1] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellJg1Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_jg_1.image.sprite == active_spells[i])
            {
                spell_jg_1.image.sprite = inactive_spells[i];
                spell_cd_current[2] = spell_cd_base[i];

                if (boots_jg.image.sprite == active_cd[1] && rune_jg.image.sprite == active_cd[0])
                {
                    spell_cd_current[2] = spell_cd_current[2] * 85 / 100;
                }
                else if (boots_jg.image.sprite != active_cd[1] && rune_jg.image.sprite == active_cd[0])
                {
                    spell_cd_current[2] = spell_cd_current[2] * 95 / 100;
                }
                else if (boots_jg.image.sprite == active_cd[1] && rune_jg.image.sprite != active_cd[0])
                {
                    spell_cd_current[2] = spell_cd_current[2] * 90 / 100;
                }

                spell_cd_left[2] = spell_cd_current[2];
                cd_jg_1.enabled = true;
                StartCoroutine("CooldownJg1");
            }
            else if (spell_jg_1.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[2] = 0;
                reset_checker[2] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellJg2Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_jg_2.image.sprite == active_spells[i])
            {
                spell_jg_2.image.sprite = inactive_spells[i];
                spell_cd_current[3] = spell_cd_base[i];

                if (boots_jg.image.sprite == active_cd[1] && rune_jg.image.sprite == active_cd[0])
                {
                    spell_cd_current[3] = spell_cd_current[3] * 85 / 100;
                }
                else if (boots_jg.image.sprite != active_cd[1] && rune_jg.image.sprite == active_cd[0])
                {
                    spell_cd_current[3] = spell_cd_current[3] * 95 / 100;
                }
                else if (boots_jg.image.sprite == active_cd[1] && rune_jg.image.sprite != active_cd[0])
                {
                    spell_cd_current[3] = spell_cd_current[3] * 90 / 100;
                }

                spell_cd_left[3] = spell_cd_current[3];
                cd_jg_2.enabled = true;
                StartCoroutine("CooldownJg2");
            }
            else if (spell_jg_2.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[3] = 0;
                reset_checker[3] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellMid1Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_mid_1.image.sprite == active_spells[i])
            {
                spell_mid_1.image.sprite = inactive_spells[i];
                spell_cd_current[4] = spell_cd_base[i];

                if (boots_mid.image.sprite == active_cd[1] && rune_mid.image.sprite == active_cd[0])
                {
                    spell_cd_current[4] = spell_cd_current[4] * 85 / 100;
                }
                else if (boots_mid.image.sprite != active_cd[1] && rune_mid.image.sprite == active_cd[0])
                {
                    spell_cd_current[4] = spell_cd_current[4] * 95 / 100;
                }
                else if (boots_mid.image.sprite == active_cd[1] && rune_mid.image.sprite != active_cd[0])
                {
                    spell_cd_current[4] = spell_cd_current[4] * 90 / 100;
                }

                spell_cd_left[4] = spell_cd_current[4];
                cd_mid_1.enabled = true;
                StartCoroutine("CooldownMid1");
            }
            else if (spell_mid_1.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[4] = 0;
                reset_checker[4] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellMid2Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_mid_2.image.sprite == active_spells[i])
            {
                spell_mid_2.image.sprite = inactive_spells[i];
                spell_cd_current[5] = spell_cd_base[i];

                if (boots_mid.image.sprite == active_cd[1] && rune_mid.image.sprite == active_cd[0])
                {
                    spell_cd_current[5] = spell_cd_current[5] * 85 / 100;
                }
                else if (boots_mid.image.sprite != active_cd[1] && rune_mid.image.sprite == active_cd[0])
                {
                    spell_cd_current[5] = spell_cd_current[5] * 95 / 100;
                }
                else if (boots_mid.image.sprite == active_cd[1] && rune_mid.image.sprite != active_cd[0])
                {
                    spell_cd_current[5] = spell_cd_current[5] * 90 / 100;
                }

                spell_cd_left[5] = spell_cd_current[5];
                cd_mid_2.enabled = true;
                StartCoroutine("CooldownMid2");
            }
            else if (spell_mid_2.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[5] = 0;
                reset_checker[5] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellAdc1Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_adc_1.image.sprite == active_spells[i])
            {
                spell_adc_1.image.sprite = inactive_spells[i];
                spell_cd_current[6] = spell_cd_base[i];

                if (boots_adc.image.sprite == active_cd[1] && rune_adc.image.sprite == active_cd[0])
                {
                    spell_cd_current[6] = spell_cd_current[6] * 85 / 100;
                }
                else if (boots_adc.image.sprite != active_cd[1] && rune_adc.image.sprite == active_cd[0])
                {
                    spell_cd_current[6] = spell_cd_current[6] * 95 / 100;
                }
                else if (boots_adc.image.sprite == active_cd[1] && rune_adc.image.sprite != active_cd[0])
                {
                    spell_cd_current[6] = spell_cd_current[6] * 90 / 100;
                }

                spell_cd_left[6] = spell_cd_current[6];
                cd_adc_1.enabled = true;
                StartCoroutine("CooldownAdc1");
            }
            else if (spell_adc_1.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[6] = 0;
                reset_checker[6] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellAdc2Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_adc_2.image.sprite == active_spells[i])
            {
                spell_adc_2.image.sprite = inactive_spells[i];
                spell_cd_current[7] = spell_cd_base[i];

                if (boots_adc.image.sprite == active_cd[1] && rune_adc.image.sprite == active_cd[0])
                {
                    spell_cd_current[7] = spell_cd_current[7] * 85 / 100;
                }
                else if (boots_adc.image.sprite != active_cd[1] && rune_adc.image.sprite == active_cd[0])
                {
                    spell_cd_current[7] = spell_cd_current[7] * 95 / 100;
                }
                else if (boots_adc.image.sprite == active_cd[1] && rune_adc.image.sprite != active_cd[0])
                {
                    spell_cd_current[7] = spell_cd_current[7] * 90 / 100;
                }

                spell_cd_left[7] = spell_cd_current[7];
                cd_adc_2.enabled = true;
                StartCoroutine("CooldownAdc2");
            }
            else if (spell_adc_2.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[7] = 0;
                reset_checker[7] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellSupp1Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_supp_1.image.sprite == active_spells[i])
            {
                spell_supp_1.image.sprite = inactive_spells[i];
                spell_cd_current[8] = spell_cd_base[i];

                if (boots_supp.image.sprite == active_cd[1] && rune_supp.image.sprite == active_cd[0])
                {
                    spell_cd_current[8] = spell_cd_current[8] * 85 / 100;
                }
                else if (boots_supp.image.sprite != active_cd[1] && rune_supp.image.sprite == active_cd[0])
                {
                    spell_cd_current[8] = spell_cd_current[8] * 95 / 100;
                }
                else if (boots_supp.image.sprite == active_cd[1] && rune_supp.image.sprite != active_cd[0])
                {
                    spell_cd_current[8] = spell_cd_current[8] * 90 / 100;
                }

                spell_cd_left[8] = spell_cd_current[8];
                cd_supp_1.enabled = true;
                StartCoroutine("CooldownSupp1");
            }
            else if (spell_supp_1.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[8] = 0;
                reset_checker[8] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void SpellSupp2Button()
    {
        for (int i = 0; i < 9; i++)
        {
            if (spell_supp_2.image.sprite == active_spells[i])
            {
                spell_supp_2.image.sprite = inactive_spells[i];
                spell_cd_current[9] = spell_cd_base[i];

                if (boots_supp.image.sprite == active_cd[1] && rune_supp.image.sprite == active_cd[0])
                {
                    spell_cd_current[9] = spell_cd_current[9] * 85 / 100;
                }
                else if (boots_supp.image.sprite != active_cd[1] && rune_supp.image.sprite == active_cd[0])
                {
                    spell_cd_current[9] = spell_cd_current[9] * 95 / 100;
                }
                else if (boots_supp.image.sprite == active_cd[1] && rune_supp.image.sprite != active_cd[0])
                {
                    spell_cd_current[9] = spell_cd_current[9] * 90 / 100;
                }

                spell_cd_left[9] = spell_cd_current[9];
                cd_supp_2.enabled = true;
                StartCoroutine("CooldownSupp2");
            }
            else if (spell_supp_2.image.sprite == inactive_spells[i])
            {
                //spell_cd_left[9] = 0;
                reset_checker[9] = true;
                panel_reset.SetActive(true);
            }
        }
    }

    public void ChangeTop1()
    {
        spell_change[0] = true;
        panel_change.SetActive(true);
    }

    public void ChangeTop2()
    {
        spell_change[1] = true;
        panel_change.SetActive(true);
    }

    public void ChangeJg1()
    {
        spell_change[2] = true;
        panel_change.SetActive(true);
    }

    public void ChangeJg2()
    {
        spell_change[3] = true;
        panel_change.SetActive(true);
    }

    public void ChangeMid1()
    {
        spell_change[4] = true;
        panel_change.SetActive(true);
    }

    public void ChangeMid2()
    {
        spell_change[5] = true;
        panel_change.SetActive(true);
    }

    public void ChangeAdc1()
    {
        spell_change[6] = true;
        panel_change.SetActive(true);
    }

    public void ChangeAdc2()
    {
        spell_change[7] = true;
        panel_change.SetActive(true);
    }

    public void ChangeSupp1()
    {
        spell_change[8] = true;
        panel_change.SetActive(true);
    }

    public void ChangeSupp2()
    {
        spell_change[9] = true;
        panel_change.SetActive(true);
    }

    public void RuneTopButton()
    {
        if(rune_top.image.sprite == active_cd[0])
        {
            rune_top.image.sprite = inactive_cd[0];
            
        }
        else if(rune_top.image.sprite == inactive_cd[0])
        {
            rune_top.image.sprite = active_cd[0];
        }
    }

    public void RuneJgButton()
    {
        if (rune_jg.image.sprite == active_cd[0])
        {
            rune_jg.image.sprite = inactive_cd[0];

        }
        else if (rune_jg.image.sprite == inactive_cd[0])
        {
            rune_jg.image.sprite = active_cd[0];
        }
    }

    public void RuneMidButton()
    {
        if (rune_mid.image.sprite == active_cd[0])
        {
            rune_mid.image.sprite = inactive_cd[0];

        }
        else if (rune_mid.image.sprite == inactive_cd[0])
        {
            rune_mid.image.sprite = active_cd[0];
        }
    }

    public void RuneAdcButton()
    {
        if (rune_adc.image.sprite == active_cd[0])
        {
            rune_adc.image.sprite = inactive_cd[0];

        }
        else if (rune_adc.image.sprite == inactive_cd[0])
        {
            rune_adc.image.sprite = active_cd[0];
        }
    }

    public void RuneSuppButton()
    {
        if (rune_supp.image.sprite == active_cd[0])
        {
            rune_supp.image.sprite = inactive_cd[0];

        }
        else if (rune_supp.image.sprite == inactive_cd[0])
        {
            rune_supp.image.sprite = active_cd[0];
        }
    }

    public void BootsTopButton()
    {
        if (boots_top.image.sprite == active_cd[1])
        {
            boots_top.image.sprite = inactive_cd[1];

        }
        else if (boots_top.image.sprite == inactive_cd[1])
        {
            boots_top.image.sprite = active_cd[1];
        }
    }

    public void BootsJgButton()
    {
        if (boots_jg.image.sprite == active_cd[1])
        {
            boots_jg.image.sprite = inactive_cd[1];

        }
        else if (boots_jg.image.sprite == inactive_cd[1])
        {
            boots_jg.image.sprite = active_cd[1];
        }
    }

    public void BootsMidButton()
    {
        if (boots_mid.image.sprite == active_cd[1])
        {
            boots_mid.image.sprite = inactive_cd[1];

        }
        else if (boots_mid.image.sprite == inactive_cd[1])
        {
            boots_mid.image.sprite = active_cd[1];
        }
    }

    public void BootsAdcButton()
    {
        if (boots_adc.image.sprite == active_cd[1])
        {
            boots_adc.image.sprite = inactive_cd[1];

        }
        else if (boots_adc.image.sprite == inactive_cd[1])
        {
            boots_adc.image.sprite = active_cd[1];
        }
    }

    public void BootsSuppButton()
    {
        if (boots_supp.image.sprite == active_cd[1])
        {
            boots_supp.image.sprite = inactive_cd[1];

        }
        else if (boots_supp.image.sprite == inactive_cd[1])
        {
            boots_supp.image.sprite = active_cd[1];
        }
    }

    public void SpellChangeBarrier()
    {
        for(int i = 0; i < 10; i++)
        {
            if(spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[0];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[0];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[0];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[0];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[0];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[0];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[0];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[0];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[0];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[0];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeCleanse()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[1];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[1];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[1];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[1];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[1];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[1];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[1];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[1];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[1];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[1];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeExhaust()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[2];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[2];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[2];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[2];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[2];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[2];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[2];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[2];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[2];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[2];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeFlash()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[3];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[3];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[3];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[3];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[3];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[3];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[3];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[3];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[3];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[3];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeGhost()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[4];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[4];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[4];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[4];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[4];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[4];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[4];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[4];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[4];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[4];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeHeal()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[5];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[5];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[5];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[5];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[5];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[5];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[5];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[5];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[5];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[5];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeIgnite()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[6];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[6];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[6];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[6];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[6];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[6];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[6];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[6];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[6];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[6];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeSmite()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[7];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[7];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[7];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[7];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[7];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[7];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[7];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[7];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[7];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[7];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeTeleport()
    {
        for (int i = 0; i < 10; i++)
        {
            if (spell_change[i] == true)
            {
                switch (i)
                {
                    case 0:
                        spell_top_1.image.sprite = active_spells[8];
                        spell_cd_left[0] = 0;
                        break;
                    case 1:
                        spell_top_2.image.sprite = active_spells[8];
                        spell_cd_left[1] = 0;
                        break;
                    case 2:
                        spell_jg_1.image.sprite = active_spells[8];
                        spell_cd_left[2] = 0;
                        break;
                    case 3:
                        spell_jg_2.image.sprite = active_spells[8];
                        spell_cd_left[3] = 0;
                        break;
                    case 4:
                        spell_mid_1.image.sprite = active_spells[8];
                        spell_cd_left[4] = 0;
                        break;
                    case 5:
                        spell_mid_2.image.sprite = active_spells[8];
                        spell_cd_left[5] = 0;
                        break;
                    case 6:
                        spell_adc_1.image.sprite = active_spells[8];
                        spell_cd_left[6] = 0;
                        break;
                    case 7:
                        spell_adc_2.image.sprite = active_spells[8];
                        spell_cd_left[7] = 0;
                        break;
                    case 8:
                        spell_supp_1.image.sprite = active_spells[8];
                        spell_cd_left[8] = 0;
                        break;
                    case 9:
                        spell_supp_2.image.sprite = active_spells[8];
                        spell_cd_left[9] = 0;
                        break;
                }
                panel_change.SetActive(false);
            }
        }
    }

    public void SpellChangeCancel()
    {
        for(int i = 0; i < 10; i++)
        {
            spell_change[i] = false;
            panel_change.SetActive(false);
        }
    }

    public void ButtonResetOK()
    {
        for(int i = 0; i < 10; i++)
        {
            if(reset_checker[i] == true)
            {
                spell_cd_left[i] = 0;
                reset_checker[i] = false;
                panel_reset.SetActive(false);
            }
        }
    }

    public void ButtonResetCancel()
    {
        for (int i = 0; i < 10; i++)
        {
            if (reset_checker[i] == true)
            {
                reset_checker[i] = false;
                panel_reset.SetActive(false);
            }
        }
    }
}
