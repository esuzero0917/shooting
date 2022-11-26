using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEnhance : MonoBehaviour
{
    [System.Serializable]
    public struct Enhancement
    {
        public int level;
        public int maxLevel;
        public int needPoint;
        public TextMeshProUGUI  levelText;
        public Button enhanceButton;
    }

    public Enhancement hp;
    public Enhancement speed;
    public Enhancement energy;

    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        ButtonActiveCheck(speed);
        ButtonActiveCheck(energy);
    }


    private void ButtonActiveCheck(Enhancement e)
    {
        Text text = e.enhanceButton.GetComponentInChildren<Text>();
        
        if(e.level != e.maxLevel){
            text.text = "x" + e.needPoint.ToString();
        }
        else{
            e.enhanceButton.interactable = false;
            text.text = "Max";
        }
    }

    public void OnHpEnhanceButton()
    {
        if(player.nowPoint >= hp.needPoint){
            if(hp.level < hp.maxLevel){
                ++player.maxHp;
                player.hp = player.maxHp;
                player.hpContainer.GetComponent<HpContainer>().Relocation();

                player.nowPoint -= hp.needPoint; 

                ++hp.level;
                if(hp.level < hp.maxLevel){
                    
                    hp.levelText.text = "Hp Lv." + hp.level.ToString();
                    hp.needPoint += 5; 
                    hp.enhanceButton.GetComponentInChildren<Text>().text = "x" + hp.needPoint.ToString();
                }
                else{
                    hp.levelText.text = "Heal";
                    hp.needPoint = 10;
                    hp.enhanceButton.GetComponentInChildren<Text>().text = "x" + hp.needPoint.ToString();
                }
            }
            else{
                if(player.hp < player.maxHp){
                    player.hp = player.maxHp;
                    player.hpContainer.GetComponent<HpContainer>().Relocation();

                    player.nowPoint -= hp.needPoint;
                }
            }
            
        }        
    }

    public void OnSpeedEnhanceButton()
    {
        float speedIncreaseAmount = 5.0f / (speed.maxLevel - 1.0f);

        if(player.nowPoint >= speed.needPoint){
            player.defaultMoveSpeed += speedIncreaseAmount;
            player.moveSpeed = player.defaultMoveSpeed;

            player.nowPoint -= speed.needPoint;
            speed.needPoint += 3 ;  

            ++speed.level;
            speed.levelText.text = "Speed Lv." + speed.level.ToString();
        }
    }

    public void OnStaminaEnhanceButton()
    {
        float staminaIncreaseAmount = 50.0f / (energy.maxLevel - 1.0f);

        if(player.nowPoint >= energy.needPoint){
            player.maxEnergy += staminaIncreaseAmount;
            player.energy = player.maxEnergy;

            player.nowPoint -= energy.needPoint;
            energy.needPoint += 3;

            ++energy.level;
            energy.levelText.text = "Energy Lv." + energy.level.ToString();
        }
    }
    
}