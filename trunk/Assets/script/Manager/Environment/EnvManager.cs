using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class EnvManager
    {

        public static float player_moveSpeed = 10.0f;
        public static float player_runSpeed = 20.0f;
        public static float player_jumpSpeed = 10.0f;
        public static float gravity = 20.0f;
        public static GravityLevel currentGLevel = GravityLevel.Level2;


        public static float[] GravityLevelArray = new float[6]{
            EnvConstants.G_LEVEL_0,
            EnvConstants.G_LEVEL_1,
            EnvConstants.G_LEVEL_2,
            EnvConstants.G_LEVEL_3,
            EnvConstants.G_LEVEL_4,
            EnvConstants.G_LEVEL_5
        };

        // 设置当前的g等级
        public static void SetGravityLevel(int gravityLevel) {
            if (gravityLevel < EnvConstants.G_LEVEL_MIN || gravityLevel > EnvConstants.G_LEVEL_MAX) {
                Debug.Log("in SetGravityLevel : gravityLevel out of range.");
                return;
            }

            gravity = GravityLevelArray[gravityLevel];
            currentGLevel = (GravityLevel)gravityLevel;
        }

        // 获取当前的g等级
        public static int GetCurrentGLevel() {
            return (int)currentGLevel;
        }

        // 提高g等级，成功返回当前g等级，失败返回-1
        public static int raiseGLevel() {
            if((int)currentGLevel != EnvConstants.G_LEVEL_MAX){
                currentGLevel++;
                return (int)currentGLevel;
            } else
                return -1;
        }

        // 降低g等级，成功返回当前g等级，失败返回-1
        public static int lowerGLevel() {
            if ((int)currentGLevel != EnvConstants.G_LEVEL_MIN) {
                currentGLevel--;
                return (int)currentGLevel;
            }
            else
                return -1;
        }
    }

    public enum GravityLevel{
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5
    };
}
