#include "ev3api.h"
#include "app.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//チーム名の設定
#define TEAMNAME    "SYAMU GAME"

//モーターポートの設定
#define A_motor     EV3_PORT_A
#define B_motor     EV3_PORT_B
#define Left_motor  EV3_PORT_C
#define Right_motor EV3_PORT_D

//ここから下はいじらないこと！！
//ソフトウェアのバージョン
#define VERSION     "2.0"

FILE *bt = NULL;

void config_EV3(void) {
    //モーターポートの割当設定
    ev3_motor_config (A_motor, LARGE_MOTOR);
    ev3_motor_config (B_motor, LARGE_MOTOR);
    ev3_motor_config (Left_motor, LARGE_MOTOR);
    ev3_motor_config (Right_motor, LARGE_MOTOR);
    //LCDの設定
    ev3_lcd_set_font(EV3_FONT_MEDIUM);
    //LEDの設定
    ev3_led_set_color(LED_OFF);
    //Bluetoothシリアル通信の設定
    bt = ev3_serial_open_file(EV3_SERIAL_BT);
    assert(bt != NULL);
}

void send_teamname(void) {
    static int flag = 1;
    if(flag) {
        fprintf(bt, "%s\r\n", TEAMNAME); //チーム名送信
    }
    flag = 0;
}

int connect(void) {
    while(!ev3_bluetooth_is_connected()) {
        tslp_tsk(100U * 1000U);
        memfile_t memfile;
        ev3_memfile_load("/ev3rt/res/syamu.bmp", &memfile);
        image_t image;
        ev3_image_load(&memfile, &image);
        ev3_lcd_draw_image(&image, 0, 10);   //画像描画
        ev3_lcd_draw_string("EV3", 0, 30);
        ev3_lcd_draw_string(VERSION, 0, 50); //バージョン描画
        //接続切れたら止める
        ev3_motor_stop(A_motor, true);
        ev3_motor_stop(B_motor, true);
        ev3_motor_stop(Left_motor, true);
        ev3_motor_stop(Right_motor, true);
        ev3_lcd_draw_string("disconnect        ", 0, 0);
    }
    send_teamname();
    lcd_xy name = {0, 110};
    teamname_draw(name, TEAMNAME);
    ev3_lcd_draw_string("connect TOKUFIGHT!", 0, 0);
    return 1;
}

//メイン関数
void main_task(intptr_t unused) {
    controller horipad;
    config_EV3();
    
    while(1) {
        connect();        
        receive(&horipad, bt);
        //ここから上はイジらないこと
        //ボタンの値描画
        lcd_xy button = {38, 20};
        button_draw(button, horipad);
        //スティックの値描画
        lcd_xy stick = {0, 70};
        stick_draw(stick, horipad);

        //ボタンの動作
        if(horipad.button[TRIANGLE]) {
            //△のとき
            ev3_motor_set_power(A_motor, 50);
        }
        else {
            ev3_motor_stop(A_motor, true);
        }

        //スティックの動作
        //ノーマルモード
        if(horipad.d_pad == 90) {
            ev3_motor_set_power(Left_motor, -50);
            ev3_motor_set_power(Right_motor, 50);
        }
        else if(horipad.d_pad == 270) {
            ev3_motor_set_power(Left_motor, 50);
            ev3_motor_set_power(Right_motor, -50);
        }
        else {
            ev3_motor_steer(Left_motor, Right_motor, horipad.left_stick_y / 2, horipad.right_stick_x);
        }

        //タンクモード
        //ev3_motor_set_power(Left_motor, horipad.left_stick_y);
        //ev3_motor_set_power(Right_motor, horipad.right_stick_y);

        //ラジコンモード
        //ev3_motor_steer(Left_motor, Right_motor, horipad.left_stick_y, horipad.right_stick_x);

        //グランツーリスモモード
        //ev3_motor_steer(Left_motor, Right_motor, horipad.right_stick_y, horipad.left_stick_x);

        //ニードフォースピードモード
        //(horipad.right_trigger != 0)? ev3_motor_steer(Left_motor, Right_motor, horipad.right_trigger, horipad.left_stick_x) : ev3_motor_steer(Left_motor, Right_motor, -horipad.left_trigger, horipad.left_stick_x)
    }
}