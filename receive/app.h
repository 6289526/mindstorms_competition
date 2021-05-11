#include "target_test.h"
#include "ev3api.h"
#include <stdio.h>
#include <stdlib.h>

#ifndef STACK_SIZE
#define	STACK_SIZE	4096 //タスクのスタックサイズ
#endif //STACK_SIZE

#ifndef TOPPERS_MACRO_ONLY

extern void	task(intptr_t exinf);
extern void	main_task(intptr_t exinf);

#endif

#ifndef _TOKUDAI_
#define _TOKUDAI_

//ボタン数
#define buttonnum 14

//ボタン番号
#define SQUARE      0
#define CROSS       1
#define CIRCLE      2
#define TRIANGLE    3
#define L1          4
#define R1          5
#define L2          6
#define R2          7
#define SHARE       8
#define OPTIONS     9
#define L_STICK     10
#define R_STICK     11
#define PS          12
#define PAD         13
//L2･R2押込圧
#define LT          14
#define RT          15
//スティック番号
#define LSX         16
#define LSY         17
#define RSX         18
#define RSY         19
//十字キー番号
#define DPAD        20

//ボタン構造体
typedef struct controller {
    int button[buttonnum];    
    int left_stick_x;
    int left_stick_y;
    int right_stick_x;
    int right_stick_y;
    int left_trigger;
    int right_trigger;
    int d_pad; 
} controller;

//LCD座標構造体
typedef struct lcd_xy {
    int x;
    int y;
} lcd_xy;

static void button(char *str, controller* con);         //ボタン押下判定関数
static int char_to_int(char s);                         //型変換関数
extern void button_draw(lcd_xy plot, controller con);   //ボタン値LCD描画関数
extern void stick_draw(lcd_xy plot, controller con);    //スティック値LCD描画関数
extern void teamname_draw(lcd_xy plot, char* teamname); //チームネームLCD描画関数
extern int receive(controller* con, FILE *bt);          //シリアル受信関数
#endif